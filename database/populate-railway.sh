#!/bin/bash

# Script para popular dados iniciais no Railway MySQL
echo "🎵 Executando dados iniciais no Railway MySQL..."

# Conectar e executar o script SQL
mysql -h mainline.proxy.rlwy.net -u root -p"jYFqsjMdBZJGWfEMrukyftRgcEYazGKq" --port 49986 --protocol=TCP railway < seed-data.sql

if [ $? -eq 0 ]; then
    echo "✅ Dados iniciais inseridos com sucesso!"
else
    echo "❌ Erro ao inserir dados iniciais"
fi
