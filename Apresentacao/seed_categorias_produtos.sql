USE e_commerce_tech;

INSERT INTO Catalog.Category_tb (NameCategory)
VALUES 
('Processadores'),
('Placas de Vídeo'),
('Armazenamento'),
('Periféricos');
GO

INSERT INTO Catalog.Product_tb 
(NameProduct, PriceProduct, StockProduct, IdCategory, DescriptionProduct, WeightProduct, SpecsProduct, BrandProduct)
VALUES 
(
    'Intel Core i9-13900K', 
    3500.00, 
    15, 
    1, 
    'Processador de alta performance para jogos.', 
    1, 
    '{"Cores": 24, "Threads": 32, "Socket": "LGA1700", "BaseClock": "3.0GHz"}', 
    'Intel'
),
(
    'NVIDIA RTX 4090', 
    12000.00, 
    5, 
    2, 
    'Placa de vídeo muito potente.', 
    3, 
    '{"Memory": "24GB GDDR6X", "Interface": "384-bit", "Power": "450W"}', 
    'NVIDIA'
),
(
    'SSD NVMe 1TB Kingston', 
    450.00, 
    50, 
    3, 
    'Alta velocidade para carregamento de sistema e jogos.', 
    1, 
    '{"ReadSpeed": "3500MB/s", "WriteSpeed": "2100MB/s", "Format": "M.2"}', 
    'Kingston'
);
GO


INSERT INTO Catalog.Product_tb 
(NameProduct, PriceProduct, StockProduct, IdCategory, DescriptionProduct, WeightProduct, SpecsProduct, BrandProduct)
VALUES 
-- Categoria 1: 
('AMD Ryzen 7 5800X', 1600.00, 20, 1, 'Excelente para multitasking e games.', 1, '{"Cores": 8, "Threads": 16, "Socket": "AM4", "BaseClock": "3.8GHz"}', 'AMD'),
('Intel Core i5-13600K', 1900.00, 12, 1, 'Equilíbrio perfeito entre preço e performance.', 1, '{"Cores": 14, "Threads": 20, "Socket": "LGA1700", "BaseClock": "3.5GHz"}', 'Intel'),
('AMD Ryzen 5 5600G', 950.00, 30, 1, 'Processador com vídeo integrado Vega 7.', 1, '{"Cores": 6, "Threads": 12, "Socket": "AM4", "IntegratedGraphics": "Yes"}', 'AMD'),

-- Categoria 2: 
('NVIDIA RTX 3060 Ti', 2800.00, 8, 2, 'Ótima para jogar em 1080p e 1440p.', 2, '{"Memory": "8GB GDDR6", "Interface": "256-bit", "Fans": 2}', 'ASUS'),
('AMD Radeon RX 6750 XT', 2600.00, 10, 2, 'Alta taxa de quadros e ótimo custo-benefício.', 2, '{"Memory": "12GB GDDR6", "Interface": "192-bit", "TDP": "250W"}', 'MSI'),
('NVIDIA RTX 4070 Super', 4500.00, 5, 2, 'Performance de elite com baixo consumo.', 2, '{"Memory": "12GB GDDR6X", "DLSS": "3.5", "Architecture": "Ada Lovelace"}', 'Gigabyte'),
('AMD Radeon RX 7600', 1800.00, 15, 2, 'Ideal para setups de entrada e streaming.', 1, '{"Memory": "8GB GDDR6", "Interface": "128-bit", "Fans": 2}', 'PowerColor'),

-- Categoria 3:
('SSD NVMe 2TB Samsung 980 Pro', 980.00, 25, 3, 'O SSD mais rápido para entusiastas.', 1, '{"ReadSpeed": "7000MB/s", "WriteSpeed": "5000MB/s", "Gen": "PCIe 4.0"}', 'Samsung'),
('HD Externo 2TB Seagate Expansion', 400.00, 40, 3, 'Leve seus arquivos para qualquer lugar.', 1, '{"Interface": "USB 3.0", "Format": "2.5 inch", "RPM": 5400}', 'Seagate'),
('SSD SATA 480GB Crucial BX500', 220.00, 60, 3, 'Upgrade ideal para notebooks antigos.', 1, '{"ReadSpeed": "540MB/s", "WriteSpeed": "500MB/s", "Format": "SATA III"}', 'Crucial'),

-- Categoria 4:
('Teclado Mecânico Logitech G Pro', 750.00, 18, 4, 'Compacto e com switches profissionais.', 1, '{"Switch": "GX Blue", "RGB": "Lightsync", "Layout": "TKL"}', 'Logitech'),
('Mouse Gamer Razer DeathAdder V2', 350.00, 25, 4, 'Ergonomia premiada e sensor óptico de 20K DPI.', 1, '{"DPI": 20000, "Buttons": 8, "Weight": "82g"}', 'Razer'),
('Monitor AOC Hero 24" 144Hz', 1100.00, 10, 4, 'Painel IPS e tempo de resposta de 1ms.', 5, '{"RefreshRate": "144Hz", "Panel": "IPS", "Sync": "G-Sync Compatible"}', 'AOC'),
('Headset HyperX Cloud II', 550.00, 22, 4, 'Conforto lendário e som surround 7.1.', 1, '{"Connection": "USB/3.5mm", "Drivers": "53mm", "Mic": "Detachable"}', 'HyperX'),
('Webcam Logitech C920S', 480.00, 15, 4, 'Resolução Full HD 1080p para reuniões e stream.', 1, '{"Resolution": "1080p", "Focus": "Auto", "FPS": 30}', 'Logitech');
GO


ALTER TABLE Catalog.Product_tb ALTER COLUMN WeightProduct DECIMAL(18,2);

ALTER TABLE Sales.Card_tb ALTER COLUMN NicknameCard VARCHAR(100);



INSERT INTO Sales.Coupon_tb (Code, DiscountPercentage, ExpirationDate, IsActive)
VALUES 
('BEMVINDO10', 10.00, '2026-12-31 23:59:59', 1), -- Cupom de boas-vindas
('VOLVO20', 20.00, '2026-06-30 23:59:59', 1),     -- Cupom parceria
('BLACKFRIDAY', 50.00, '2025-11-30 23:59:59', 1), -- Cupom já expirado (bom para testes!)
('TECH5', 5.00, '2027-01-01 00:00:00', 1),        -- Cupom longo prazo
('PROMOOFF', 15.00, '2026-12-31 23:59:59', 0);    -- Cupom desativado manualmente
GO






