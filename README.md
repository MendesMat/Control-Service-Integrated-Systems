# API de Gestão de Clientes e Propostas Comerciais

Esta API foi desenvolvida em **ASP.NET 9** para gerenciar informações de clientes e propostas comerciais, com funcionalidades completas de CRUD (Create, Read, Update, Delete). Ela oferece uma solução para registro de clientes e propostas, com uma relação de **1 cliente para N propostas**.

## Tecnologias Utilizadas

- **ASP.NET Core 9**
- **Entity Framework Core**
  - `EntityFrameworkCore.SqlServer` (para integração com banco de dados SQL Server)
  - `EntityFrameworkCore.Tools` (para configuração e manipulação de dados)
- **Automapper** (para mapeamento de DTOs e entidades)
- **FluentValidation** (para validação de dados de entrada)
- **AspNetCore.OpenApi** (para geração de documentação OpenAPI)
- **Swagger** (para documentação da API)

## Funcionalidades

- **Clientes**
  - CRUD completo para manipulação de clientes.
  - Validação das informações essenciais dos clientes, como CPF, CNPJ, email, entre outros.

- **Propostas Comerciais**
  - CRUD completo para manipulação de propostas comerciais.
  - Relacionamento de propostas com clientes, com a regra de 1 cliente para múltiplas propostas (1-N).
  - Validação das informações essenciais das propostas, garantindo que o cliente e o cliente pagador sejam entidades distintas.

## Endpoints

- **Clientes (Pessoa Física e Jurídica)**

  - `POST /managementApi/individualcustomer` - Cria um novo cliente pessoa física.
  - `PUT /managementApi/individualcustomer` - Atualiza um cliente pessoa física.
  
  - `POST /managementApi/companycustomer` - Cria um novo cliente pessoa jurídica.
  - `PUT /managementApi/companycustomer` - Atualiza um cliente pessoa jurídica.
  
  - `GET /managementApi/allcustomers` - Lista todos os clientes.
  - `GET /managementApi/allcustomers/{id}` - Obtém os detalhes de um cliente específico.
  - `DELETE /managementApi/allcustomers/{id}` - Remove um cliente.

- **Propostas Comerciais**

  - `POST /managementApi/proposal` - Cria uma nova proposta.
  - `GET /managementApi/proposal` - Lista todas as propostas.
  - `GET /managementApi/proposal/{id}` - Obtém os detalhes de uma proposta específica.
  - `PUT /managementApi/proposal/{id}` - Atualiza uma proposta existente.
  - `DELETE /managementApi/proposal/{id}` - Remove uma proposta.
