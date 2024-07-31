# SmartHint

# Documentação da API em .NET

## Requisitos

- .NET 8
- Entity Framework 8
- SQL Server

## Configuração do Ambiente

Para rodar a aplicação localmente, siga os passos abaixo:

### Clonar o Repositório

Clone o repositório utilizando o comando:

```bash
git clone https://github.com/Gabs1993/SmartHint.git
````

## Configurando Banco de dados

Execute o comando para criar uma nova pasta de migrações com a estrutura atual do banco de dados:

```bash
dotnet ef migrations add NomeDaMigracao
````

e depois: 
```bash
update-database
````




