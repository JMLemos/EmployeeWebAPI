# EmployeeWebAPI
Projeto desenvolvido como atividade final do módulo Web III - Ada

## ▶️ Objetivo do Projeto 💡

Elaborar uma API seguindo alguns requisitos descritos ao longo desse documento, para demonstrar o conhecimento adquirido no módulo WEB III. 

## ▶️Tecnologias utilizadas ⚙️

* .Net 6.0
* ASP.NET Core Web API

## ▶️ DONE ✔️

✔️ `Geração do JWT através do Login do Usuário`

✔️ `Projeto criado em padrão Controller, Model, Repository`

✔️ `Criação dos endpoints com responses válidos e inválidos e o tipo de objeto que retorna`

✔️ `Utilização de um arquivo JSON para simulação de um BD`

### `ENDPOINTS`

✔️ `POST` : Login gerando JWT`;

✔️ `POST (Query)` : Realiza uma busca por Genero dos funcionários;

✔️ `GET` : Retorna a lista (paginada) com as informações dos Funcionários;

✔️ `GET {id}` : Retorna as informações do Id solicitado;

✔️ `POST` : Realiza inserção de um novo funcionário com geração de Id automático;

✔️ `PUT` : Faz a edição das informações do funcionário sem alterar o Id;

✔️ `PATCH` : Realiza edição de login e senha dos funcionários;

✔️ `DELETE` : Remove o id solicitado do banco de dados.

## ▶️TESTES REALIZADOS 🕹️

Os testes realizados nos endpoints tiveram como base as informações do arquivo JSON dataEmployee.json e para login foi utilizado a base de dados dataUsers.Json.

## ▶️Como rodar:

* Clone esse repositório em sua máquina;
* Abra o projeto com a IDE (preferencialmente Visual Studio);
* Rode a aplicação para inicialização do swagger.



