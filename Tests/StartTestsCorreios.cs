using AutomationWeb.Core.Cesar.constants;
using AutomationWeb.Core.Cesar.Utils;
using NUnit.Core;
using NUnit.Framework;
using AutomationWeb.Core.Cesar.Pages;
using Teste.AutomacaoWeb.Correios.Cesar.Pages;

namespace AutomationWeb.Core.Cesar.Tests
{
    [TestFixture]
    public class StartTestsCorreios : Initialize
    {

        [TestCase(TestName = "Avaliação Busca CEP Incorreto")]
        public void IniciarTesteBuscaCepCorreiosCepIncorreto()
        {
            new HomeCorreiosPage(driver)
            .searchForZipCode(Constants.CEP_INVALIDO)
            .selectCurrentWindow();
            var message = new CheckData(driver).checkReturnTxtInvalidZip();
            Assert.AreEqual(Constants.TXT_CEP_NAO_EXISTE, message, "Verificação se o CEP existe");
        }

        [TestCase(TestName = "Avaliação Busca CEP Correto")]
        public void IniciarTesteBuscaCepCorreto()
        {
            new HomeCorreiosPage(driver)
                .searchForZipCode(Constants.CEP_VALIDO)
                .selectCurrentWindow();
            var check = new CheckData(driver);
            Assert.IsTrue(check.checkReturnTxtValidZip().Contains(Constants.TXT_CEP_LOGRADOURO), "Confirma o endereço");
            Assert.AreEqual(Constants.TXT_LOCALIDADE_UF, check.checkReturnTxtState(), "Confirma que o Estado existe");
        }
        [TestCase(TestName = "Avaliação Busca Código Rastreamento")]
        public void IniciarTesteBuscaCodigoRastreamento()
        {
            HomeCorreiosPage home = new HomeCorreiosPage(driver);
            home.selectCurrentWindow();
            home.searchTrackingCode(Constants.CODIGO_RASTREIO);
            var message = new TrackingPage(driver)
            .trackingNextPage()
            .getValueMessageSearchResult();
            Assert.AreEqual(Constants.TXT_DADOS_NAO_ENCONTRADOS, message, "Confirma que o código de rastreio não existe");

        }

    }
}
