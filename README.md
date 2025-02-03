## Documentação da API

### Clientes
Existem dois tipos distintos de clientes: **Pessoa Física** e **Pessoa Jurídica**. No entanto, ambos tem propriedades em comum. As propriedades dispostas abaixo pode ser utlizadas em operações de criação e atualização de qualquer tipo de cliente:

| Parâmetro | Requerido | Tipo | Descrição | Validação |
| :- | :- | :- | :- | :- |
| `Id` | **Sim** | `int` | Índice do cliente no banco de dados. | Não ser nulo | 
| `Name` | **Sim** | `string` | O nome identificador do cliente. | Não ser nulo |
| `Telephone1` | Não | `string` | Telefone do cliente | 10 ou 11 digitos numéricos |
| `Telephone2` | Não | `string` | Telefone do cliente | 10 ou 11 digitos numéricos |
| `Email1` | Não | `string` | Email do cliente | Formato de email válido |
| `Email2` | Não | `string` | Email do cliente | Formato de email válido |
| `CEP` | Não | `string` | Código de endereçamento | 8 dígitos numéricos |
| `Address` | Não | `string` | Logradouro do cliente | Não aplicável |
| `Number` | Não | `string` | Número do endereço | Não aplicável |
| `Complement` | Não | `string` | Complemento do cliente | Não aplicável |

### Pessoa Física

#### Cria um cliente do tipo Pessoa Física
```https
POST /managementApi/IndividualCustomer
```
| Parâmetro | Requerido | Tipo | Descrição | Validação |
| :- | :- | :- | :- | :- |
| `CPF` | Não | `string` | Cadastro de pessoa física | 11 caracteres numéricos |


#### Atualiza um cliente - Pessoa Física
```https
PUT /managementApi/IndividualCustomer/{Id}
```

### Pessoa Jurídica
```https
POST /managementApi/CompanyCustomer
```
| Parâmetro | Requerido | Tipo | Descrição | Validação |
| :- | :- | :- | :- | :- |
| `LegalName` | Não | `string` | Razão social | Não aplicável |
| `CNPJ` | Não | `string` | Cadastro de pessoa jurídica | 14 caracteres numéricos |
| `MunicipalRegistration` | Não | `string` | Inscrição municipal | Não aplicável |

#### Atualiza um cliente - Pessoa Jurídica
```https
PUT /managementApi/companyCustomer/{Id}
```

### Requisições comuns a todos os clientes

#### Lista de todos os clientes cadastrados
```https
GET /managementApi/AllCustomers
```

#### Retorna o cliente com id fornecido
```https
GET /managementApi/CompanyCustomer/{Id}
```
