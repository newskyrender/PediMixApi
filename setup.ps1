# Script de inicialização do PediMix Backend API para Windows
# Execute este script para configurar o ambiente de desenvolvimento

Write-Host "🎵 PediMix Backend API - Script de Inicialização" -ForegroundColor Cyan
Write-Host "================================================" -ForegroundColor Cyan

# Verificar se o .NET 8 está instalado
Write-Host "📋 Verificando pré-requisitos..." -ForegroundColor Yellow

try {
    $dotnetVersion = dotnet --version
    $majorVersion = [int]($dotnetVersion.Split('.')[0])
    
    if ($majorVersion -lt 8) {
        Write-Host "❌ .NET 8.0 ou superior é necessário. Versão atual: $dotnetVersion" -ForegroundColor Red
        Write-Host "🌐 Download: https://dotnet.microsoft.com/download" -ForegroundColor Blue
        exit 1
    }
    
    Write-Host "✅ .NET SDK $dotnetVersion encontrado" -ForegroundColor Green
}
catch {
    Write-Host "❌ .NET SDK não encontrado. Instale o .NET 8 SDK primeiro." -ForegroundColor Red
    Write-Host "🌐 Download: https://dotnet.microsoft.com/download" -ForegroundColor Blue
    exit 1
}

# Verificar se o MySQL está acessível
Write-Host "🐬 Verificando MySQL..." -ForegroundColor Yellow
try {
    $mysqlCheck = Get-Command mysql -ErrorAction SilentlyContinue
    if ($mysqlCheck) {
        Write-Host "✅ MySQL client encontrado" -ForegroundColor Green
    } else {
        Write-Host "⚠️  MySQL client não encontrado. Certifique-se de que o MySQL Server está instalado e rodando." -ForegroundColor Yellow
    }
}
catch {
    Write-Host "⚠️  Não foi possível verificar o MySQL. Certifique-se de que está instalado e rodando." -ForegroundColor Yellow
}

# Instalar dotnet-ef tools se não estiver instalado
Write-Host "🔧 Verificando Entity Framework Tools..." -ForegroundColor Yellow
$efTools = dotnet tool list -g | Select-String "dotnet-ef"
if (-not $efTools) {
    Write-Host "📦 Instalando Entity Framework Tools..." -ForegroundColor Blue
    dotnet tool install --global dotnet-ef
} else {
    Write-Host "✅ Entity Framework Tools já instalado" -ForegroundColor Green
}

# Navegar para o diretório do script
$scriptPath = Split-Path -Parent $MyInvocation.MyCommand.Path
Set-Location $scriptPath

# Restaurar pacotes NuGet
Write-Host "📦 Restaurando pacotes NuGet..." -ForegroundColor Blue
dotnet restore

# Compilar o projeto para verificar se tudo está correto
Write-Host "🔨 Compilando o projeto..." -ForegroundColor Blue
$buildResult = dotnet build
if ($LASTEXITCODE -ne 0) {
    Write-Host "❌ Erro na compilação. Verifique os erros acima." -ForegroundColor Red
    exit 1
}
Write-Host "✅ Compilação bem-sucedida" -ForegroundColor Green

# Configurar banco de dados
Write-Host "" -ForegroundColor White
Write-Host "🗄️  Configurando banco de dados..." -ForegroundColor Yellow
Write-Host "⚠️  IMPORTANTE: Certifique-se de que:" -ForegroundColor Yellow
Write-Host "   - O MySQL Server está rodando" -ForegroundColor Gray
Write-Host "   - A string de conexão em appsettings.json está correta" -ForegroundColor Gray
Write-Host "   - O usuário MySQL tem permissões para criar databases" -ForegroundColor Gray

$runMigrations = Read-Host "🤔 Deseja executar as migrations agora? [y/N]"
if ($runMigrations -match "^[Yy]$") {
    Write-Host "🚀 Executando migrations..." -ForegroundColor Blue
    Set-Location "PediMix.Infrastructure"
    
    $migrationResult = dotnet ef database update
    if ($LASTEXITCODE -eq 0) {
        Write-Host "✅ Migrations executadas com sucesso!" -ForegroundColor Green
        
        # Perguntar sobre dados iniciais
        $seedData = Read-Host "🌱 Deseja popular o banco com dados iniciais? [y/N]"
        if ($seedData -match "^[Yy]$") {
            Set-Location ".."
            if (Test-Path "database\seed-data.sql") {
                Write-Host "📊 Para executar o script de dados iniciais, execute:" -ForegroundColor Blue
                Write-Host "   mysql -u root -p PediMixDB < database\seed-data.sql" -ForegroundColor Gray
            } else {
                Write-Host "⚠️  Arquivo seed-data.sql não encontrado" -ForegroundColor Yellow
            }
        }
    } else {
        Write-Host "❌ Erro ao executar migrations. Verifique a conexão com o MySQL." -ForegroundColor Red
        exit 1
    }
    Set-Location ".."
}

Write-Host "" -ForegroundColor White
Write-Host "🎉 Setup concluído!" -ForegroundColor Green
Write-Host "🚀 Para executar a API:" -ForegroundColor Cyan
Write-Host "   cd PediMix.API" -ForegroundColor Gray
Write-Host "   dotnet run" -ForegroundColor Gray
Write-Host "" -ForegroundColor White
Write-Host "📖 Documentação Swagger estará disponível em:" -ForegroundColor Cyan
Write-Host "   https://localhost:7139/swagger" -ForegroundColor Blue
Write-Host "" -ForegroundColor White
Write-Host "🎵 Boa sorte com o desenvolvimento do PediMix!" -ForegroundColor Magenta
