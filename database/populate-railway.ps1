# Script PowerShell para popular dados iniciais no Railway MySQL
Write-Host "🎵 Executando dados iniciais no Railway MySQL..." -ForegroundColor Cyan

# Verificar se o mysql client está disponível
if (-not (Get-Command mysql -ErrorAction SilentlyContinue)) {
    Write-Host "❌ MySQL client não encontrado. Instale o MySQL Client ou use MySQL Workbench." -ForegroundColor Red
    Write-Host "💡 Ou execute manualmente:" -ForegroundColor Yellow
    Write-Host "   mysql -h mainline.proxy.rlwy.net -u root -p`"jYFqsjMdBZJGWfEMrukyftRgcEYazGKq`" --port 49986 --protocol=TCP railway < seed-data.sql" -ForegroundColor Gray
    exit 1
}

# Conectar e executar o script SQL
$command = "mysql -h mainline.proxy.rlwy.net -u root -p`"jYFqsjMdBZJGWfEMrukyftRgcEYazGKq`" --port 49986 --protocol=TCP railway"
$scriptPath = Join-Path $PSScriptRoot "seed-data.sql"

Write-Host "📊 Executando script de dados..." -ForegroundColor Blue
try {
    Get-Content $scriptPath | & mysql -h mainline.proxy.rlwy.net -u root -p"jYFqsjMdBZJGWfEMrukyftRgcEYazGKq" --port 49986 --protocol=TCP railway
    Write-Host "✅ Dados iniciais inseridos com sucesso!" -ForegroundColor Green
}
catch {
    Write-Host "❌ Erro ao inserir dados iniciais: $($_.Exception.Message)" -ForegroundColor Red
    Write-Host "💡 Tente executar manualmente:" -ForegroundColor Yellow
    Write-Host "   mysql -h mainline.proxy.rlwy.net -u root -p`"jYFqsjMdBZJGWfEMrukyftRgcEYazGKq`" --port 49986 --protocol=TCP railway < seed-data.sql" -ForegroundColor Gray
}
