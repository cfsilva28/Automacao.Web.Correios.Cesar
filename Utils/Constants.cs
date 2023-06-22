using System;
using System.IO;

namespace AutomationWeb.Core.Cesar.constants
{
    static class Constants
    {
        public static string ELEMENTSDIRECTORY = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Elements\";        
        public static string INPUTDIRECTORY = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Resources\";        
        public const string TXT_CEP_NAO_EXISTE = "Dados não encontrado";
        public const string TXT_CEP_LOGRADOURO = "Rua Quinze de Novembro";
        public const string TXT_LOCALIDADE_UF = "São Paulo/SP";
        public const string CEP_INVALIDO = "80700000";
        public const string CEP_VALIDO = "01013-001";
        public const string CODIGO_RASTREIO = "SS987654321BR";
        public const string TXT_DADOS_NAO_ENCONTRADOS = "Objeto não encontrado na base de dados dos Correios.";
    }
}
