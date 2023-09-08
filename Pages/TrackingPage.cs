using AutomationWeb.Core.Cesar.constants;
using AutomationWeb.Core.Cesar.Pages;
using AutomationWeb.Core.Cesar.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Linq;
using Teste.AutomacaoWeb.Correios.Cesar.Model;

namespace Teste.AutomacaoWeb.Correios.Cesar.Pages
{
    internal class TrackingPage : BasePage
    {
        TrackingModel idField;
        public TrackingPage(IWebDriver driver) : base(driver)
        {
            idField = util.ConvertJsonToObject<TrackingModel>(
                Constants.ELEMENTSDIRECTORY + @"\trackingPage.json");
        }
        public string inputCaptcha()
        {
            changeWindow("");
            string caminhoArquivoHtml = Path.Combine(Directory.GetCurrentDirectory(), Constants.INPUTDIRECTORY, "input.html");
            driver.Navigate().GoToUrl(caminhoArquivoHtml);
            IWebElement inputElement = driver.FindElement(By.Id("valor"));

            Func<IWebDriver, bool> atributoAlterado = (driver) =>
            {
                IWebElement okButton = driver.FindElement(By.Id("okButton"));
                string dataClicado = okButton.GetAttribute("data-clicado");
                return dataClicado == "true";
            };
            while (true)
            {
                bool resultado = new WebDriverWait(driver, TimeSpan.FromSeconds(50)).Until(atributoAlterado);
                if (resultado)
                {
                    string valorAtributo = inputElement.GetAttribute("value");
                    string currentWindow = driver.CurrentWindowHandle;
                    driver.Close();
                    driver.SwitchTo().Window(driver.WindowHandles.Last());
                    return valorAtributo;
                }
            }
        }
        public void screenDown()
        {
            var element = driver.FindElement(By.CssSelector(idField.btnSearchCaptcha));
            ScrollTo(element);
        }
        public IWebElement ScrollTo(IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            return element;
        }
        public TrackingPage writeCaptchaCode()
        {
            screenDown();
            TrackingPage trackingPage = new TrackingPage(driver);
            var cr = new CheckData(driver);
            string captchaValue = trackingPage.inputCaptcha();
            write.WriteByCssSelector(idField.fieldCaptcha, captchaValue + Keys.Enter);
            return this;
        }
        public CheckData trackingNextPage()
        {
            writeCaptchaCode();
            return new CheckData(driver);
        }
    }
}
