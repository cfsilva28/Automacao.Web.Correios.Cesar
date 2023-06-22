# Introdução 
Este projeto visa executar a automação de testes do projeto automação correios

# Pré-requisitos
Ter instalado as aplica��es abaixo:
- Visual Studio 2019
- Git

# Executando os testes
Para executar os testes do projeto via prompt com a configuração padrão, basta executar o comando abaixo(é necessário estar com o prompt no diretório da solution):

	$ dotnet test

Caso queira executar os testes do projeto com uma configuração específica, basta chamar o arquivo de configuração(extensão `.runsettings`) no comando:

	$ dotnet test -s <arquivo de configuração>

Ex: dotnet test -s appChrome.runsettings

# Resultado dos testes
Um report dos testes é gerado no formato HTML dentro da pasta "TestResults" existente dentro da Solution.
