using AutomationWeb.Core.Cesar.Utils;
using AutomationWeb.Core.Cesar.Model;
using OpenQA.Selenium;
using AutomationWeb.Core.Cesar.OnboardingPF;

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
        public CheckData selectCurrentWindow()
        {
            string currentWindowHandle = driver.CurrentWindowHandle;
            string newWindowHandle = string.Empty;

            foreach (string handle in driver.WindowHandles)
            {
                if (handle != currentWindowHandle)
                {
                    newWindowHandle = handle;
                    break;
                }
            }
            driver.SwitchTo().Window(newWindowHandle);
            return this;
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
            System.Threading.Thread.Sleep(100);
            var text = get.GetInnerTextByCssSelector(idField.alerMessage);
            return text;
        }
    }
}
