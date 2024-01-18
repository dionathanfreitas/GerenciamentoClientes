# Gerenciamento de Clientes

Bem-vindo ao projeto Gerenciamento de Clientes! Este projeto oferece um sistema de CRUD simples para clientes, permitindo a criação, leitura, atualização e exclusão de registros.

## Índice

1. [Sobre](#sobre)
2. [Requisitos do Sistema](#requisitos-do-sistema)
3. [Configuração do Ambiente](#configuração-do-ambiente)
   - [Configuração do Banco de Dados](#configuração-do-banco-de-dados)
   - [Migrações do Entity Framework](#migrações-do-entity-framework)
   - [Instalação de Dependências](#instalação-de-dependências)
4. [Instalação](#instalação)
5. [Uso](#uso)
6. [Estrutura do Projeto](#estrutura-do-projeto)
7. [Contribuição](#contribuição)
8. [Licença](#licença)
9. [Contato](#contato)

## Sobre

O projeto Gerenciamento de Clientes fornece uma solução fácil e eficiente para a gestão de informações de clientes. Com funcionalidades de CRUD, você pode criar, visualizar, editar e excluir registros de clientes de forma intuitiva.

## Requisitos do Sistema

- .NET Core 6.0
- SQL Server (ou SQL Server LocalDB)

## Configuração do Ambiente

### Configuração do Banco de Dados

1. Abra o arquivo `appsettings.json` localizado na pasta `GerenciamentoClientes`.
2. Encontre a seção `ConnectionStrings` e ajuste a string de conexão do SQL Server conforme necessário.

Exemplo:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=SEU-SERVIDOR-SQL;Initial Catalog=SUA-BASE-DE-DADOS;Integrated Security=True;"
  },
  ...
}
```

### Migrações do Entity Framework

Para aplicar migrações e criar ou atualizar o banco de dados, utilize o seguinte comando:

```bash
dotnet ef database update
```

### Instalação de Dependências

Restaure as dependências do projeto com os seguintes comandos:

```bash
# Restaurar Dependências
dotnet restore

# Instalar Pacotes do npm (se aplicável)
npm install
```

## Instalação

Siga estes passos para configurar e executar o projeto em seu ambiente local:

```bash
# Clonar o Repositório
git clone https://github.com/seu-usuario/GerenciamentoClientes.git
cd GerenciamentoClientes

# Configurar o Ambiente (seguindo as instruções acima)

# Instalar Dependências
dotnet restore

# Aplicar Migrações
dotnet ef database update

# Iniciar o Projeto
dotnet run
```

## Uso

Após a instalação, acesse a aplicação em `http://localhost:5000` e comece a gerenciar seus clientes!

## Estrutura do Projeto

A estrutura do projeto é organizada da seguinte forma:

```plaintext
GerenciamentoClientes/
|-- GerenciamentoClientes/
|   |-- Controllers/
|   |-- Models/
|   |-- Views/
|-- Migrations/
|-- wwwroot/
|-- README.md
|-- ...
```

## Contribuição

Sinta-se à vontade para contribuir! Se encontrar problemas ou melhorias, abra uma [issue](https://github.com/seu-usuario/GerenciamentoClientes/issues) ou envie um pull request.

## Licença

Este projeto é licenciado sob a Licença MIT - veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## Contato

Para dúvidas ou informações adicionais, entre em contato conosco:

- Nome: Dionathan Freitas
- Email: diocsfreitas@gmail.com
- Linkedin: linkedin.com/in/dionathan-freitas-286668149/
