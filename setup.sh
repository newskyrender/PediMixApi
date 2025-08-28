#!/bin/bash

# Script de inicialização do PediMix Backend API
# Execute este script para configurar o ambiente de desenvolvimento

echo "🎵 PediMix Backend API - Script de Inicialização"
echo "================================================"

# Verificar se o .NET 8 está instalado
echo "📋 Verificando pré-requisitos..."
if ! command -v dotnet &> /dev/null; then
    echo "❌ .NET SDK não encontrado. Instale o .NET 8 SDK primeiro."
    echo "🌐 Download: https://dotnet.microsoft.com/download"
    exit 1
fi

# Verificar versão do .NET
DOTNET_VERSION=$(dotnet --version | cut -d'.' -f1)
if [ "$DOTNET_VERSION" -lt "8" ]; then
    echo "❌ .NET 8.0 ou superior é necessário. Versão atual: $(dotnet --version)"
    exit 1
fi
echo "✅ .NET SDK $(dotnet --version) encontrado"

# Verificar se o MySQL está rodando
echo "🐬 Verificando MySQL..."
if ! command -v mysql &> /dev/null; then
    echo "⚠️  MySQL client não encontrado. Certifique-se de que o MySQL Server está instalado e rodando."
else
    echo "✅ MySQL client encontrado"
fi

# Instalar dotnet-ef tools se não estiver instalado
echo "🔧 Verificando Entity Framework Tools..."
if ! dotnet tool list -g | grep -q "dotnet-ef"; then
    echo "📦 Instalando Entity Framework Tools..."
    dotnet tool install --global dotnet-ef
else
    echo "✅ Entity Framework Tools já instalado"
fi

# Navegar para o diretório da API
cd "$(dirname "$0")"

# Restaurar pacotes NuGet
echo "📦 Restaurando pacotes NuGet..."
dotnet restore

# Compilar o projeto para verificar se tudo está correto
echo "🔨 Compilando o projeto..."
if ! dotnet build; then
    echo "❌ Erro na compilação. Verifique os erros acima."
    exit 1
fi
echo "✅ Compilação bem-sucedida"

# Configurar banco de dados
echo "🗄️  Configurando banco de dados..."
echo "⚠️  IMPORTANTE: Certifique-se de que:"
echo "   - O MySQL Server está rodando"
echo "   - A string de conexão em appsettings.json está correta"
echo "   - O usuário MySQL tem permissões para criar databases"

read -p "🤔 Deseja executar as migrations agora? [y/N]: " -n 1 -r
echo
if [[ $REPLY =~ ^[Yy]$ ]]; then
    echo "🚀 Executando migrations..."
    cd PediMix.Infrastructure
    if dotnet ef database update; then
        echo "✅ Migrations executadas com sucesso!"
        
        # Perguntar sobre dados iniciais
        read -p "🌱 Deseja popular o banco com dados iniciais? [y/N]: " -n 1 -r
        echo
        if [[ $REPLY =~ ^[Yy]$ ]]; then
            cd ..
            if [ -f "database/seed-data.sql" ]; then
                echo "📊 Executando script de dados iniciais..."
                echo "💡 Execute o comando abaixo manualmente:"
                echo "   mysql -u root -p PediMixDB < database/seed-data.sql"
            else
                echo "⚠️  Arquivo seed-data.sql não encontrado"
            fi
        fi
    else
        echo "❌ Erro ao executar migrations. Verifique a conexão com o MySQL."
        exit 1
    fi
    cd ..
fi

echo ""
echo "🎉 Setup concluído!"
echo "🚀 Para executar a API:"
echo "   cd PediMix.API"
echo "   dotnet run"
echo ""
echo "📖 Documentação Swagger estará disponível em:"
echo "   https://localhost:7139/swagger"
echo ""
echo "🎵 Boa sorte com o desenvolvimento do PediMix!"
