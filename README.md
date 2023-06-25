# API Rest para Cadastramento de Coleções de Roupas

<img script width: 250px height: 250px src="./Fotos/Captura%20de%20tela%202023-06-25%20182814.png">
<img script width: 250px height: 250px src="./Fotos/Captura%20de%20tela%202023-06-25%20182842.png">
<img script width: 250px height: 250px src="./Fotos/Captura%20de%20tela%202023-06-25%20182901.png>

## Introdução ao Projeto

Este projeto é uma API desenvolvido no término do segundo Módulo do Curso DEVinHouse (Lab 365). Ele é utilizado para cadastramento de Coleções, Modelos de Roupas e seus respectivos Usuários, utulizando requizições com os verbos Rest's para cada função da API. Ela foi criada utilizando entity framework Core para conecxão com o Banco de Dados (SQL Server), a criação do projeto foi feita com dotnet 5.

## Como é Utilizado

Para utilizar este projeto você deverá :

- Baixar o Arquivo do Projeto em seu computador;
- Instalar Dotnet Core **(No mínimo a versao 5.0)**;
- Arrumar a String do local onde deseja criar Banco de Dados **(Localizado na Pasta appsettings.json)**;
  Trocar a String na propriedade de **"ConnectionStrings"**;
- Rodar o projeto atravez do Visual Studio;

## Composição de Pastas

<img script width: 250px height: 250px src="./Fotos/ModelosDePastas.png">

O Projeto é composto por diversas pastas sendo elas :

- **Properties** : Possui Propriedades pré definidas ao projeto;
- **Controllers**: Possui todos os Arquivos que gerem os verbos de requisições Rests da Api
  Foram divididas em 3 Controllers sendo uma para cara entidade do Banco de Dados, _Usuarios_, _Coleções_ e _Modelos_;
- **Data**: Pasta que possui o arquivo _Context_ do projeto. Usada para configurar a relação da Api com o Banco de Dados;
- **Enums**: Possui todos os Enuns utilizados para tipar certos dados das entidades da Aplicação;
- **Migration** : Arquivos de criação de entidades no banco, ou novas configurações feitas na _Context_.
  Sempre que modificado a Context deve ser feita uma nova Migration para Atualizar as configurações no banco de dados;
- **Models**: Pasta onde estão localizadas as entidades da aplicação e suas especificações;
- **Services**: Pasta que armazena o arquivo de serviços realizados na Api;
- **appsettings.json**: Arquivo de Configurações gerais da Aplicação;
- **Startup.cs** e **Program.cs**: Arquivos principais da aplicação, criando todas as dependências e fazendo com que rode corretamente o projeto;

## Com que objetivo foi criado

Foi desenvolvida para a consolidação dos conteúdos vidos no Segundo Módulo do Curso DEVinHouse e Finalização do Módulo para avaliação. Foi um modelo desenvolvido para fazer a parte de back end do Projeto.
