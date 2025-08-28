-- Script para popular dados iniciais do PediMix
-- Execute após rodar as migrations
-- Comando para conectar: mysql -h mainline.proxy.rlwy.net -u root -p jYFqsjMdBZJGWfEMrukyftRgcEYazGKq --port 49986 --protocol=TCP railway

-- Inserir gêneros musicais básicos
INSERT INTO Genres (Id, Name, Color, Description, CreatedAt, UpdatedAt) VALUES
    (UUID(), 'Rock', '#FF6B6B', 'Rock and Roll, Classic Rock, Alternative Rock', NOW(), NOW()),
    (UUID(), 'Pop', '#4ECDC4', 'Pop Music, Contemporary Hits', NOW(), NOW()),
    (UUID(), 'Sertanejo', '#45B7D1', 'Música Sertaneja, Country Brasileiro', NOW(), NOW()),
    (UUID(), 'MPB', '#96CEB4', 'Música Popular Brasileira', NOW(), NOW()),
    (UUID(), 'Blues', '#FFEAA7', 'Blues, Blues Rock', NOW(), NOW()),
    (UUID(), 'Jazz', '#DDA0DD', 'Jazz, Smooth Jazz, Bossa Nova', NOW(), NOW()),
    (UUID(), 'Reggae', '#98D8C8', 'Reggae, Ska, Dub', NOW(), NOW()),
    (UUID(), 'Funk', '#FDA7DF', 'Funk, Funk Carioca, Soul', NOW(), NOW()),
    (UUID(), 'Samba', '#F7DC6F', 'Samba, Pagode, Chorinho', NOW(), NOW()),
    (UUID(), 'Eletrônica', '#BB8FCE', 'Electronic Music, House, Techno', NOW(), NOW());

-- Inserir comodidades para locais
INSERT INTO Amenities (Id, Name, Icon, Category, CreatedAt, UpdatedAt) VALUES
    (UUID(), 'Sistema de Som Profissional', 'speaker', 'Audio', NOW(), NOW()),
    (UUID(), 'Microfones', 'microphone', 'Audio', NOW(), NOW()),
    (UUID(), 'Palco', 'stage', 'Infrastructure', NOW(), NOW()),
    (UUID(), 'Iluminação Profissional', 'lightbulb', 'Lighting', NOW(), NOW()),
    (UUID(), 'Estacionamento', 'car', 'Facilities', NOW(), NOW()),
    (UUID(), 'Bar/Bebidas', 'glass', 'Services', NOW(), NOW()),
    (UUID(), 'Ar Condicionado', 'air-conditioner', 'Comfort', NOW(), NOW()),
    (UUID(), 'WiFi Grátis', 'wifi', 'Connectivity', NOW(), NOW()),
    (UUID(), 'Camarim', 'dressing-room', 'Artist', NOW(), NOW()),
    (UUID(), 'Área Externa', 'outdoor', 'Space', NOW(), NOW());

-- Inserir usuário administrador padrão
SET @admin_id = UUID();
INSERT INTO Users (Id, Username, Email, FirstName, LastName, PasswordHash, PhoneNumber, Role, IsActive, IsEmailVerified, CreatedAt, UpdatedAt) VALUES
    (@admin_id, 'admin', 'admin@pedimix.com', 'Administrador', 'Sistema', '$2a$11$dummy.hash.for.default.admin', '+5511999999999', 4, true, true, NOW(), NOW());

-- Inserir algumas músicas populares de exemplo
SET @rock_genre_id = (SELECT Id FROM Genres WHERE Name = 'Rock' LIMIT 1);
SET @pop_genre_id = (SELECT Id FROM Genres WHERE Name = 'Pop' LIMIT 1);
SET @mpb_genre_id = (SELECT Id FROM Genres WHERE Name = 'MPB' LIMIT 1);
SET @sertanejo_genre_id = (SELECT Id FROM Genres WHERE Name = 'Sertanejo' LIMIT 1);

INSERT INTO Songs (Id, Title, Artist, GenreId, Duration, Difficulty, `Key`, HasLyrics, Year, IsPopular, CreatedAt, UpdatedAt) VALUES
    (UUID(), 'Bohemian Rhapsody', 'Queen', @rock_genre_id, '05:55', 3, 'Bb', true, 1975, true, NOW(), NOW()),
    (UUID(), 'Hotel California', 'Eagles', @rock_genre_id, '06:30', 2, 'Bm', true, 1976, true, NOW(), NOW()),
    (UUID(), 'Imagine', 'John Lennon', @pop_genre_id, '03:07', 1, 'C', true, 1971, true, NOW(), NOW()),
    (UUID(), 'Aquarela', 'Toquinho', @mpb_genre_id, '04:20', 1, 'G', true, 1983, true, NOW(), NOW()),
    (UUID(), 'Garota de Ipanema', 'Tom Jobim', @mpb_genre_id, '05:26', 2, 'F', true, 1964, true, NOW(), NOW()),
    (UUID(), 'Evidências', 'Chitãozinho & Xororó', @sertanejo_genre_id, '05:03', 2, 'Em', true, 1990, true, NOW(), NOW()),
    (UUID(), 'Asa Branca', 'Luiz Gonzaga', @mpb_genre_id, '03:45', 1, 'G', true, 1947, true, NOW(), NOW()),
    (UUID(), 'Como é Grande o Meu Amor Por Você', 'Roberto Carlos', @pop_genre_id, '04:15', 1, 'C', true, 1967, true, NOW(), NOW()),
    (UUID(), 'Sua Cara', 'Major Lazer', @pop_genre_id, '03:18', 2, 'Am', true, 2017, true, NOW(), NOW()),
    (UUID(), 'Ai Se Eu Te Pego', 'Michel Teló', @sertanejo_genre_id, '02:58', 1, 'G', true, 2011, true, NOW(), NOW());

COMMIT;
