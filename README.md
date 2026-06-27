# QuestTrack

Protótipo funcional de um aplicativo para acompanhamento de sessões de estudo, desenvolvido em `ASP.NET Core MVC` com persistência em `SQLite`.

## Sobre o projeto

O QuestTrack foi criado para ajudar estudantes a registrar e acompanhar o próprio desempenho na resolução de questões. A aplicação permite cadastrar sessões de estudo, visualizar o histórico, editar registros existentes e excluir entradas quando necessário.

O projeto foi estruturado como um protótipo funcional com foco em clareza de navegação, organização do código e demonstração completa do fluxo CRUD. A escolha por `MVC` foi intencional por facilitar a separação entre regras de negócio, interface e controle das requisições, o que torna a solução mais simples de manter e evoluir.

## Problema que o app resolve

Muitos estudantes ainda controlam o desempenho de forma manual, com anotações soltas ou planilhas pouco organizadas. O QuestTrack centraliza essas informações em uma interface única, permitindo:

- registrar matéria, quantidade de questões, acertos e data do estudo
- acompanhar sessões salvas
- atualizar registros
- remover registros com confirmação
- visualizar indicadores gerais de desempenho

## Funcionalidades

- `Create`: cadastro de nova sessão de estudo
- `Read`: listagem e visualização dos dados salvos
- `Update`: edição de sessões já cadastradas
- `Delete`: exclusão de registros com confirmação

## Tecnologias utilizadas

- `ASP.NET Core MVC`
- `C#`
- `Entity Framework Core`
- `SQLite`
- `HTML`, `CSS` e `Razor Views`

## Estrutura do projeto

- `Controllers/`: controle de fluxo e ações HTTP
- `Data/`: contexto do banco e inicialização do SQLite
- `Models/`: entidades e modelos de domínio
- `ViewModels/`: modelos específicos para as telas
- `Views/`: interface com Razor
- `wwwroot/`: arquivos estáticos, estilos e scripts

## Como executar localmente

### Pré-requisitos

- `.NET 8 SDK`

### Passos

```bash
dotnet restore
dotnet run
```

Depois, abra o endereço exibido no terminal.

## Banco de dados

O projeto utiliza `SQLite` como banco local. O arquivo de dados é criado automaticamente na primeira execução com base na configuração em `appsettings.json`.

## Links do projeto

- GitHub: [https://github.com/4vinho/EntregaDispositivosMoveis](https://github.com/4vinho/EntregaDispositivosMoveis)
- Figma: `[inserir link do Figma]`
- Publicação / App funcional: `[inserir link do app ou Make]`

## Contexto acadêmico

Este projeto foi desenvolvido como atividade prática com foco em UI/UX, prototipação e implementação de CRUD. Embora a proposta original envolva app híbrido e integração low-code, a entrega foi organizada como um protótipo funcional em `MVC`, priorizando demonstração clara da solução, persistência real dos dados e estrutura técnica consistente.
