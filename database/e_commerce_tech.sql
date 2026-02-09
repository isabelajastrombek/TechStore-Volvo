CREATE DATABASE e_commerce_tech;
GO

USE e_commerce_tech;
GO

CREATE SCHEMA Client;
GO

CREATE TABLE Client.Client_tb(
    IdClient INT PRIMARY KEY IDENTITY(1,1),
    CpfClient VARCHAR(255) NOT NULL UNIQUE,
    NameClient VARCHAR(100),
    BirthDateClient DATE,
    PhoneClient VARCHAR(16),
    EmailClient VARCHAR(254) UNIQUE,
    PasswordClient VARCHAR(255)
);
GO

CREATE TABLE Client.Address_tb(
    IdAddress INT PRIMARY KEY IDENTITY(1,1),
    StreetAddress VARCHAR(60),
    NumberAddress VARCHAR(6),
    ComplementAddress VARCHAR(20),
    CityAddress VARCHAR(60),
    StateAddress VARCHAR(2),
    TypeAddress VARCHAR(20),
    IdClient INT NOT NULL,
    CONSTRAINT FK_Address_Client FOREIGN KEY (IdClient) REFERENCES Client.Client_tb(IdClient)
);
GO



CREATE SCHEMA Catalog;
GO

CREATE TABLE Catalog.Category_tb(
    IdCategory INT PRIMARY KEY IDENTITY(1,1),
    NameCategory VARCHAR(100)
);
GO

CREATE TABLE Catalog.Product_tb(
    IdProduct INT PRIMARY KEY IDENTITY(1,1),
    NameProduct VARCHAR(200) NOT NULL,
    PriceProduct MONEY NOT NULL,
    StockProduct INT NOT NULL DEFAULT 0,
    IdCategory INT NOT NULL,
    DescriptionProduct VARCHAR(500),
    SpecsProduct NVARCHAR(MAX),
    BrandProduct VARCHAR(50),
    CONSTRAINT FK_Product_Category FOREIGN KEY (IdCategory) REFERENCES Catalog.Category_tb(IdCategory),
    CONSTRAINT CHK_JSON_Valid CHECK (ISJSON(SpecsProduct) > 0)

);
GO





CREATE SCHEMA Sales;
GO

CREATE TABLE Sales.Card_tb(
    IdCard INT PRIMARY KEY IDENTITY(1,1),
    MaskedNumber VARCHAR(20),  
    PaymentToken VARCHAR(MAX),  
    CpfCard VARCHAR(255) NOT NULL,
    ExpDateCard DATE NOT NULL,
    TypeCard VARCHAR(10) NOT NULL,
    NicknameCard VARCHAR(20),
    NameOnCard VARCHAR(50) NOT NULL,
    IdClient INT NOT NULL,
    CONSTRAINT FK_Card_Client FOREIGN KEY (IdClient) REFERENCES Client.Client_tb(IdClient)

);
GO

CREATE TABLE Sales.Order_tb(
    IdOrder INT PRIMARY KEY IDENTITY(1,1),
    DateOrder DATETIME2 DEFAULT GETDATE(),
    IdClient INT,
    StatusOrder VARCHAR(50),
    DeliveryDate DATE,
    idCard INT,
    idAddress INT,
    TotalPrice MONEY,
    TotalShipping MONEY,
    CONSTRAINT FK_Order_Client FOREIGN KEY (IdClient) REFERENCES Client.Client_tb(IdClient),
    CONSTRAINT FK_Order_Address FOREIGN KEY (IdAddress) REFERENCES Client.Address_tb(IdAddress),
    CONSTRAINT FK_Order_Card FOREIGN KEY (IdCard) REFERENCES Sales.Card_tb(IdCard)
);
GO

CREATE TABLE Sales.ItemOrder_tb(
    IdItemOrder INT PRIMARY KEY IDENTITY(1,1),
    IdProduct INT,
    QtyItemOrder INT,
    PriceUnitItem MONEY,
    IdOrder INT,
    CONSTRAINT FK_Item_Order FOREIGN KEY (IdOrder) REFERENCES Sales.Order_tb(IdOrder),
    CONSTRAINT FK_Item_Product FOREIGN KEY (IdProduct) REFERENCES Catalog.Product_tb(IdProduct)
);
GO

