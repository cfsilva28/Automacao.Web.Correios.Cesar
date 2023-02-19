# Introduçãoo 
Este projeto visa executar a automaçãoo de testes do projeto Automação Web Correios Cesar 

# Pré-requisitos
Ter instalado as aplicaçõeses abaixo:
- Visual Studio 2022
- Git

# Executando os testes
Para executar os testes do projeto via prompt com a configuraçãoo padrãoo, basta executar o comando abaixo(é necessário estar com o prompt no diretório da solution):

	$ dotnet test

Caso queira executar os testes do projeto com uma configuraçãoo específica, basta chamar o arquivo de configuraçãoo(extensão `.runsettings`) no comando:

	$ dotnet test -s <arquivo de configuraçãoo>

Ex: dotnet test -s appChrome.runsettings

# Resultado dos testes
Um report dos testes é gerado no formato HTML dentro da pasta "TestResults" existente dentro da Solution.
