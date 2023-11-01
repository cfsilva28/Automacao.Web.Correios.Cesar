using AutomationWeb.Core.Cesar.Utils;
using AutomationWeb.Core.Cesar.Model;
using OpenQA.Selenium;
using AutomationWeb.Core.Cesar.constants;
namespace AutomationWeb.Core.Cesar.Pages
{
    public class CheckData : BasePage
    {
        CheckDataModel idField;
        public CheckData(IWebDriver driver) : base(driver)
        {
            idField = util.ConvertJsonToObject<CheckDataModel>(
                Constants.ELEMENTSDIRECTORY + @"\checkData.json");
        }        
        public string checkReturnTxtInvalidZip()
        {
            IWebElement mensagemResultadoAlerta = driver.FindElement(By.Id(idField.textResultInvalid));
            IWebElement h6 = mensagemResultadoAlerta.FindElement(By.TagName("h6"));
            return h6.Text;
        }
        public string checkReturnTxtValidZip()
        {
            var text = get.GetInnerTextByCssSelector(idField.textResultValid);
            return text;
        }
        public string checkReturnTxtState()
        {
            var text = get.GetInnerTextByCssSelector(idField.textResultState);
            return text;
        }
        public string getValueMessageSearchResult()
        {
            System.Threading.Thread.Sleep(2000);
            var text = get.GetInnerTextByCssSelector(idField.alerMessage);
            return text;
        }
    }
}
