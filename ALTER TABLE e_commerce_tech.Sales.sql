ALTER TABLE e_commerce_tech.Sales.Card_tb 
ALTER COLUMN CpfCard VARCHAR(255);


DELETE FROM e_commerce_tech.Sales.Card_tb; -- CUIDADO: Isso apaga os cartões de teste


DELETE FROM Sales.Order_tb; 

-- Agora sim, você pode limpar os cartões
DELETE FROM Sales.Card_tb;





-- 1. Primeiro limpamos os itens dos pedidos (são os mais dependentes)
DELETE FROM Sales.ItemOrder_tb;

-- 2. Depois limpamos os pedidos (que dependem do cartão e do cliente)
DELETE FROM Sales.Order_tb;

-- 3. Agora sim, podemos limpar os cartões sem erro de FK
DELETE FROM Sales.Card_tb;


SELECT * FROM e_commerce_tech.Sales.Card_tb;


USE e_commerce_tech;
ALTER TABLE Client.Address_tb ADD Cep VARCHAR(10);

USE e_commerce_tech;
ALTER TABLE Catalog.Product_tb ADD WeightProduct DECIMAL(10,2);

ALTER TABLE Catalog.Product_tb DROP COLUMN WeightProduct;