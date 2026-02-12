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