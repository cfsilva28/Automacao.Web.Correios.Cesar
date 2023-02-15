using AutomationWeb.Core.Cesar.OnboardingPF;
using AutomationWeb.Core.Cesar.Utils;
using NUnit.Core;
using NUnit.Framework;
using AutomationWeb.Core.Cesar.Pages;
using AutomationWeb.Core.Cesar.Model;
using Teste.AutomacaoWeb.Correios.Cesar.Pages;

namespace AutomationWeb.Core.Cesar.Tests
{
    [TestFixture]
    public class StartTestsCorreios : Initialize
    {
        HomeCorreiosModel idField;
        public StartTestsCorreios()
        {
            idField = util.ConvertJsonToObject<HomeCorreiosModel>(Constants.ELEMENTSDIRECTORY + @"\homeCorreiosPage.json");
        }

        [TestCase(TestName = "Avaliação Busca CEP Incorreto")]
        public void IniciarTesteBuscaCepCorreiosCepIncorreto()
        {
            new HomeCorreiosPage(driver)
            .searchForZipCode(Constants.CEP_INVALIDO, idField.fieldSeachButtonZip)
            .selectCurrentWindow();
            var message = new CheckData(driver).checkReturnTxtInvalidZip();
            Assert.AreEqual(Constants.TXT_CEP_NAO_EXISTE, message, "Verificação se o CEP existe");
        }

        [TestCase(TestName = "Avaliação Busca CEP Correto")]
        public void IniciarTesteBuscaCepCorreto()
        {
            new HomeCorreiosPage(driver)
                .searchForZipCode(Constants.CEP_VALIDO, idField.fieldSeachButtonZip)
                .selectCurrentWindow();
            var messageZipCode = new CheckData(driver).checkReturnTxtValidZip();
            Assert.IsTrue(messageZipCode.Contains(Constants.TXT_CEP_LOGRADOURO), "Confirma o endereço");
            var messageState = new CheckData(driver).checkReturnTxtState();
            Assert.AreEqual(Constants.TXT_LOCALIDADE_UF, messageState, "Confirma que o Estado existe");
        }

        [TestCase(TestName = "Avaliação Busca Código Rastreamento")]
        public void IniciarTesteBuscaCodigoRastreamento()
        {
            var cr = new CheckData(driver);
            cr.selectCurrentWindow();
            new HomeCorreiosPage(driver)
            .searchTrackingCode(Constants.CODIGO_RASTREIO, idField.fieldSeachButtonTrack)
            .selectCurrentWindow();
            new TrackingPage(driver)
                .trackingNextPage();
            var message = cr.getValueMessageSearchResult();
            Assert.AreEqual(Constants.TXT_DADOS_NAO_ENCONTRADOS, message, "Confirma que o código de rastreio não existe");
        }
    }
}
