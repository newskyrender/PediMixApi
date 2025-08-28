# 🚀 PediMix API - Configuração Railway

## ✅ Configuração Concluída

A API PediMix foi configurada com sucesso para usar o banco de dados **Railway MySQL**.

### 🔗 Conexão Railway
- **Host**: mainline.proxy.rlwy.net
- **Port**: 49986
- **Database**: railway
- **User**: root
- **Password**: jYFqsjMdBZJGWfEMrukyftRgcEYazGKq

### ✅ Status do Projeto

- ✅ **String de conexão** configurada no `appsettings.json`
- ✅ **DbContextFactory** atualizado para Railway
- ✅ **Migrations aplicadas** no banco Railway
- ✅ **API rodando** em `http://localhost:5062`
- ✅ **Swagger disponível** em `http://localhost:5062/swagger`

### 🎯 Como Usar

#### 1. Executar a API
```bash
cd backend-api/PediMix.API
dotnet run
```

#### 2. Acessar Documentação
- **Swagger UI**: http://localhost:5062/swagger
- **API Base URL**: http://localhost:5062

#### 3. Popular Dados Iniciais
```bash
# Windows PowerShell
cd database
.\populate-railway.ps1

# Ou comando direto
mysql -h mainline.proxy.rlwy.net -u root -p"jYFqsjMdBZJGWfEMrukyftRgcEYazGKq" --port 49986 --protocol=TCP railway < database/seed-data.sql
```

### 🔌 Endpoints Principais

#### Usuários
- `GET /api/users/{id}` - Buscar usuário
- `POST /api/users` - Criar usuário

#### Músicas  
- `GET /api/songs/search?query=rock` - Buscar músicas
- `GET /api/songs/genre/{genreId}` - Músicas por gênero

#### Eventos
- `GET /api/events/upcoming` - Próximos eventos
- `POST /api/events` - Criar evento

#### Pedidos de Música
- `GET /api/songrequests/event/{eventId}` - Pedidos por evento
- `POST /api/songrequests` - Fazer pedido

### 🧪 Exemplo de Teste

```bash
# Buscar músicas com termo "rock"
curl http://localhost:5062/api/songs/search?query=rock

# Listar próximos eventos
curl http://localhost:5062/api/events/upcoming?count=10
```

### 📊 Dados de Exemplo

O script `seed-data.sql` inclui:
- **10 gêneros musicais** (Rock, Pop, Sertanejo, MPB, etc.)
- **10 comodidades** para locais (Som, Microfone, Palco, etc.)
- **10 músicas populares** (Bohemian Rhapsody, Hotel California, etc.)
- **1 usuário admin** padrão

### 🎵 API Pronta para Integração!

A API está **100% funcional** e pronta para ser integrada com o frontend React. Todas as funcionalidades mapeadas do frontend foram implementadas no backend.

---

**Desenvolvido para a plataforma PediMix** 🎵🇧🇷
