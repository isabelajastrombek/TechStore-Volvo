# TechStore API

API REST desenvolvida em .NET, C#, SQL Server e Entity Framework Core para gerenciamento de um e-commerce de produtos de tecnologia. A aplicação permite cadastro e consulta de categorias, produtos, clientes, endereços, cartões, cupons e pedidos, incluindo controle de estoque e geração de relatórios.

---

## Tecnologias Utilizadas

- .NET
- C#
- [ASP.NET](http://asp.net/) Web API
- Entity Framework Core
- SQL Server
- Swagger (OpenAPI)

---

## Arquitetura do Projeto

O projeto segue arquitetura em camadas para melhor organização, manutenção e escalabilidade.

TechStore.API

TechStore.Application

TechStore.Domain

TechStore.Infrastructure

### API

Responsável pelos Controllers, configuração do Swagger e Injeção de Dependência.

### Application

Responsável pelos Services, DTOs e Interfaces.

### Domain

Responsável pelas Entidades e regras de negócio.

### Infrastructure

Responsável pelo DbContext, Repositories e Mapeamentos do Entity Framework.

---

## Modelagem do Banco de Dados

### Diagrama ER


---

## Estrutura das Tabelas

### Schema Catalog

### Category_tb

| Campo | Tipo |
| --- | --- |
| IdCategory | INT (PK) |
| NameCategory | VARCHAR |

---

### Product_tb

| Campo | Tipo |
| --- | --- |
| IdProduct | INT (PK) |
| NameProduct | VARCHAR |
| PriceProduct | MONEY |
| StockProduct | INT |
| IdCategory | INT (FK) |
| DescriptionProduct | VARCHAR |
| WeightProduct | DECIMAL |
| SpecsProduct | NVARCHAR |
| BrandProduct | VARCHAR |

---

### Schema Client

### Client_tb

| Campo | Tipo |
| --- | --- |
| IdClient | INT (PK) |
| CpfClient | VARCHAR |
| NameClient | VARCHAR |
| BirthDateClient | DATE |
| PhoneClient | VARCHAR |
| EmailClient | VARCHAR |
| PasswordClient | VARCHAR |

---

### Address_tb

| Campo | Tipo |
| --- | --- |
| IdAddress | INT (PK) |
| StreetAddress | VARCHAR |
| NumberAddress | VARCHAR |
| ComplementAddress | VARCHAR |
| CityAddress | VARCHAR |
| StateAddress | VARCHAR |
| Cep | VARCHAR |
| IdClient | INT (FK) |
| TypeAddress | VARCHAR |

---

### Card_tb

| Campo | Tipo |
| --- | --- |
| IdCard | INT (PK) |
| MaskedNumber | VARCHAR |
| PaymentToken | VARCHAR |
| CpfCard | VARCHAR |
| ExpDateCard | DATE |
| TypeCard | VARCHAR |
| NicknameCard | VARCHAR |
| NameOnCard | VARCHAR |
| IdClient | INT (FK) |

---

### Schema Sales

### Order_tb

| Campo | Tipo |
| --- | --- |
| IdOrder | INT (PK) |
| DateOrder | DATETIME2 |
| StatusOrder | VARCHAR |
| DeliveryDate | DATE |
| IdAddress | INT (FK) |
| IdClient | INT (FK) |
| IdCard | INT (FK) |
| IdCoupon | INT (FK) |
| TotalPrice | MONEY |
| TotalShipping | MONEY |

---

### ItemOrder_tb

| Campo | Tipo |
| --- | --- |
| IdItemOrder | INT (PK) |
| IdProduct | INT (FK) |
| QtyItemOrder | INT |
| PriceUnitItem | MONEY |
| IdOrder | INT (FK) |

---

### Coupon_tb

| Campo | Tipo |
| --- | --- |
| IdCoupon | INT (PK) |
| Code | VARCHAR |
| DiscountPercentage | DECIMAL |
| ExpirationDate | DATETIME2 |
| IsActive | BIT |

---

## Funcionalidades Implementadas

### Cadastro

Validação de existência de categoria antes de cadastrar produtos.

### Paginação

Endpoint:

GET /products?skip=0&take=10

### Pedidos

Ao criar um pedido:

- Verifica estoque disponível
- Subtrai a quantidade do estoque
- Salva pedido e itens
- Executa transação no banco

### Relatórios

Endpoint que retorna o total vendido agrupado por categoria.

### Filtros

Busca de produtos com filtros opcionais:

- Nome
- Preço mínimo
- Preço máximo

---

## Documentação da API

Disponível via Swagger após rodar o projeto:

/swagger

---

## Testes

A API pode ser testada via Swagger ou ferramentas como Postman.

---

## Boas Práticas Aplicadas

- Injeção de Dependência
- Repository Pattern
- DTO Pattern
- Separação de Camadas
- Tratamento de Exceptions
- Uso correto de Status Codes HTTP

---

## Observações

Projeto desenvolvido para fins acadêmicos e prática de desenvolvimento backend com arquitetura em camadas e boas práticas de mercado.
