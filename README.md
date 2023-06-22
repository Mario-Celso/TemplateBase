<h1 align="center">
    Template Base em .NET 6
</h1>

![GitHub](https://img.shields.io/github/license/Mario-Celso/TemplateBase)
![GitHub release](https://img.shields.io/github/v/release/Mario-Celso/TemplateBase)
![GitHub Release Date](https://img.shields.io/github/release-date/Mario-Celso/TemplateBase)
![GitHub commit activity (branch)](https://img.shields.io/github/commit-activity/w/Mario-Celso/TemplateBase)

🚧 Em Construção... 🚧

Esse projeto tem como finalidade aplicar os conceitos que estou adquirindo através da Pós Graduação em Software Architecture da FIAP. 

 <br />

------------------

## ✍️ Descrição do projeto
 <br />

Nesta primeira etapa estou aplicando os seguintes módulos vistos:
- **Domain Driven Design (DDD)**
- **Docker**
- **Arquitetura de Software**
    
Com estes conhecimentos adquiridos até o momento, estou construindo essa API em .NET 6, já está com o Docker configurado para rodar um container junto com o banco de dados que está sendo utilizado o PostgreSQL. O propósito dessa API alem de aplicar os conhecimentos e a experiência de alguns anos ja como desenvolvedor, é de criar um **Template** basico em .NET em que as pessoas possam clonar e criar seu próprio projeto com uma Arquitetura Hexagonal, Docker, entre outras coisas que serão acrescentadas no decorrer do projeto. 

Para o versionamento do banco de dados estou fazendo o uso de Migration, para saber mais utilize a documentação disponivel no site da **[Microsoft](https://learn.microsoft.com/pt-br/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)**.

 <br />

------------------

## 🛠️ Tecnologias utilizadas
 <br />

- **[.NET 6.0](https://learn.microsoft.com/pt-br/dotnet/fundamentals/)**
- **[PostgreSQL](https://www.postgresql.org/)**
- **[xUnit.net](https://xunit.net/)**
- **[Docker](https://www.docker.com/)**

 <br />

------------------

## 💻 Requisitos
<br />

Para executar este projeto, você precisará ter instalado em sua máquina (Windows, Mac, Linux):
- **[.NET 6 SDK](https://dotnet.microsoft.com/en-us/download)**
- **[Docker Desktop](https://docs.docker.com/desktop/windows/install/)**
- **[Visual Studio 2022](https://visualstudio.microsoft.com/downloads/)** - ou qualquer outra IDE de sua escolha
- **[DataGrip](https://www.jetbrains.com/pt-br/datagrip/)** - ou um Sistema Gerenciador de Banco de Dados de sua escolha

 <br />

------------------

## 🚀 Rodando a API
 <br />

Para iniciar o desenvolvimento, é necessário clonar o projeto do GitHub num diretório de sua preferência:

```shell
cd "diretorio"
git clone https://github.com/Mario-Celso/TemplateBase.git
```
 <br />

Segundo passo conferir se está no diretorio correto e executar o comando docker para que ele execute aplicativos de vários contêineres do Docker, que estão configurados no arquivo **docker-compose.yml**. 
Com isso você criará e iniciará todos os serviços com base na configuração com apenas um comando.

```shell
docker-compose up -d --build
```
 <br />

Sua API esta no ar 

```shell
[+] Running 2/2
 ✔ Container postgres_container  Started                                                                                                             
 ✔ Container templatebase-api-1  Started
```
 <br />

Utilize a url
``` http://localhost:5000/swagger/index.html ```

<br />

E por fim rode as migration ja criadas para gerar as tabelas no banco de dados.
```shell
cd .\Infra\
dotnet ef database update
```

 <br />

------------------

## ✅ Funcionalidades do projeto
<br />

Até o momento o projeto possui como funcionalidades:

- Cadastro de um usuário
- Login do usuário utilizando autenticação com token JWT

<br />

------------------

## 📑 Licença
<br />
Este projeto esta sobe a licença MIT. Veja a **[LICENÇA](https://opensource.org/licenses/MIT)** para saber mais.

 <br />

------------------
## 🧑🏻‍🚀 Autor 
<br />

Desenvolvido por **[Mario Celso](https://www.linkedin.com/in/mario-celso-almeida-ab3317164/)**.

<br />

------------------
