CREATE DATABASE e_commerce_tech;
GO

USE e_commerce_tech;
GO

CREATE SCHEMA Cliente;
GO

CREATE TABLE Cliente.Cliente_tb(
    IdCliente INT PRIMARY KEY IDENTITY(1,1),
    CpfCliente VARCHAR(11) NOT NULL UNIQUE,
    NomeCliente VARCHAR(100),
    DataNascimentoCliente DATE,
    EmailCliente VARCHAR(254) UNIQUE,
    SenhaCliente VARCHAR(255)
);
GO

CREATE TABLE Cliente.Endereco_tb(
    IdEndereco INT PRIMARY KEY IDENTITY(1,1),
    LogradouroEndereco VARCHAR(60),
    NumeroEndereco VARCHAR(6),
    ComplementoEndereco VARCHAR(20),
    CidadeEndereco VARCHAR(60),
    EstadoEndereco VARCHAR(2),
    TipoEndereco VARCHAR(20),
    IdCliente INT NOT NULL,
    CONSTRAINT FK_Endereco_Cliente FOREIGN KEY (IdCliente) REFERENCES Cliente.Cliente_tb(IdCliente)
);
GO



CREATE SCHEMA Catalogo;
GO

CREATE TABLE Catalogo.Categoria_tb(
    IdCategoria INT PRIMARY KEY IDENTITY(1,1),
    NomeCategoria VARCHAR(100)
);
GO

CREATE TABLE Catalogo.Produto_tb(
    IdProduto INT PRIMARY KEY IDENTITY(1,1),
    NomeProduto VARCHAR(200) NOT NULL,
    PrecoProduto MONEY NOT NULL,
    EstoqueProduto INT NOT NULL DEFAULT 0,
    IdCategoria INT NOT NULL,
    DescricaoProduto VARCHAR(500),
    EspecificacaoProduto NVARCHAR(MAX),
    MarcaProduto VARCHAR(50),
    CONSTRAINT FK_Produto_Categoria FOREIGN KEY (IdCategoria) REFERENCES Catalogo.Categoria_tb(IdCategoria),
    CONSTRAINT CHK_JSON_Valido CHECK (ISJSON(EspecificacaoProduto) > 0)

);
GO





CREATE SCHEMA Vendas;
GO

CREATE TABLE Vendas.Cartao_tb(
    IdCartao INT PRIMARY KEY IDENTITY(1,1),
    NumeroMascarado VARCHAR(20),  
    TokenPagamento VARCHAR(MAX),  
    CpfCartao VARCHAR(11) NOT NULL,
    DataExpiracaoCartao DATE NOT NULL,
    TipoCartao VARCHAR(10) NOT NULL,
    ApelidoCartao VARCHAR(20),
    NomeNoCartao VARCHAR(50) NOT NULL,
    IdCliente INT NOT NULL,
    CONSTRAINT FK_Cartao_Cliente FOREIGN KEY (IdCliente) REFERENCES Cliente.Cliente_tb(IdCliente)

);
GO

CREATE TABLE Vendas.Pedido_tb(
    IdPedido INT PRIMARY KEY IDENTITY(1,1),
    DataPedido DATETIME2 DEFAULT GETDATE(),
    IdCliente INT,
    StatusPedido VARCHAR(50),
    DataDeEntrega DATE,
    idCartao INT,
    idEndereco INT,
    ValorTotal MONEY,
    ValorFrete MONEY,
    CONSTRAINT FK_Pedido_Cliente FOREIGN KEY (IdCliente) REFERENCES Cliente.Cliente_tb(IdCliente),
    CONSTRAINT FK_Pedido_Endereco FOREIGN KEY (IdEndereco) REFERENCES Cliente.Endereco_tb(IdEndereco),
    CONSTRAINT FK_Pedido_Cartao FOREIGN KEY (IdCartao) REFERENCES Vendas.Cartao_tb(IdCartao)
);
GO

CREATE TABLE Vendas.ItemPedido_tb(
    IdItemPedido INT PRIMARY KEY IDENTITY(1,1),
    IdProduto INT,
    QuantidadeItemPedido INT,
    PrecoUnitarioItem MONEY,
    IdPedido INT,
    CONSTRAINT FK_Item_Pedido FOREIGN KEY (IdPedido) REFERENCES Vendas.Pedido_tb(IdPedido),
    CONSTRAINT FK_Item_Produto FOREIGN KEY (IdProduto) REFERENCES Catalogo.Produto_tb(IdProduto)
);
GO












