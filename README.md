# RedeSocial

Sistema didático de rede social desenvolvido para demonstrar arquitetura de software, separação de responsabilidade e boas práticas no ecossistema .NET.

## Objetivo do Projeto

Este projeto tem como propósito educacional ilustrar:
- **Separação de Responsabilidade:** Divisão clara entre regras de negócio (Core) e portas de entrada (Web API, UI).
- **Modelagem de Domínio:** Criação de entidades puras e encapsuladas.
- **Teste de Software:** Aplicação de Code-First (Código Primeiro) combinado com Testes Pós-Desenvolvimento (Test-Last Development).
- **Autenticação e Autorização:** Controle de acesso a recursos da API baseado em perfis de usuário.

## Estrutura da Solução

A solução será divida nos seguintes projetos:

1. **RedeSocial.Core (Class Library):**
	- Coração da aplicação. Não possui dependencias externas (como o Entity Framework ou ASP.NET).
	- Contém as **Entidades** do domínio (`Usuario`, `Postagem`, `Comentario`, `Curtida`).
	- Contém as interfaces (contratos) de repositórios e serviços de domínio.
	- *Por que separar o Core?* Para garantir que as regras de negócio possam ser reutilizadas por diferentes intefaces (API, Blazor, Console) sem acoplamento com a tecnologia de entrega.

2. **RedeSocial.WebApi (ASP.NET Core Web API):**
	- Ponto de entrada HTTP. 
	- Responsável por receber as requisições (Controllers/Endpoints), autenticar o usuário, delegar o processamento para o Core e retornar os dados em formato de JSON.

3. **RedeSocial.Tests (MSTest / xUnit):**
	- Projeto de testes de unidade focados no Core.
	- Escritos seguindo a estrutura Given-When-Then (BDD).

4. **[Futuro] RedeSocial.Web (Blazor):**
	- Interface de usuário (Front-end) que consumirá a Web API.

## Entidades Principais

- `Usuario`: Mantém os dados de acesso e o perfil de atorização (ex.: Admin, Comum).
- `Postagem`: Representa a publicação central feita por um usuário.
- `Comentario`: Resposta em texto atrelada a uma postagem e a um usuário.
- `Curtida`: Interação binária atrelada a uma postagem ou comentário.

## Padrões de Desenvolvimento

- **Commits:** O histórico seguirá o padrão *Conventional Commits* (ex.: `feat:`, `fix:`, `docs:`).
- **Testes:** Regras de negócio do Core devem ser cobertas por testes unitários antes da implementação da API.
