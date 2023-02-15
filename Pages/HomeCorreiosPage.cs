using AutomationWeb.Core.Cesar.Model;
using AutomationWeb.Core.Cesar.OnboardingPF;
using AutomationWeb.Core.Cesar.Utils;
using OpenQA.Selenium;

namespace AutomationWeb.Core.Cesar.Pages
{
    public class HomeCorreiosPage : BasePage
    {
        HomeCorreiosModel idField;

        public HomeCorreiosPage(IWebDriver driver) : base(driver)
        {
            idField = util.ConvertJsonToObject<HomeCorreiosModel>(
                Constants.ELEMENTSDIRECTORY + @"\homeCorreiosPage.json");
        }
        public HomeCorreiosPage writeZipCode(string zip)
        {
            write.WriteByCssSelector(idField.fieldZip, zip);
            return this;
        }
        public HomeCorreiosPage writeTrackingCode(string tracking)
        {
            write.WriteByCssSelector(idField.fieldTracking, tracking);
            return this;
        }
        public void screenDown()
        {
            var element = driver.FindElement(By.CssSelector(idField.fieldSeachButtonZip));
            ScrollTo(element);
        }
        public IWebElement ScrollTo(IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            return element;
        }
        public HomeCorreiosPage clickSearchButton(string field)
        {
            screenDown();
            click.ClickByCssSelector(field);
            return this;
        }
        public bool helperCarol()
        {
            try
            {
                driver.FindElement(By.CssSelector(idField.fieldBtnCloseCarol));
                return true;
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
        }
        public HomeCorreiosPage closeIfExist(string field)
        {
            var existe = helperCarol();
            if (existe == true)
            {
                click.ClickByCssSelector(idField.fieldBtnCloseCarol);
                clickSearchButton(field);
            }
            else
            {
                clickSearchButton(field);
            }
            return this;
        }
        public CheckData searchForZipCode(string zipCode,string field)
        {
            writeZipCode(zipCode);
            closeIfExist(field);
            return new CheckData(driver);
        }
        public CheckData searchTrackingCode(string tracking, string field)
        {
            writeTrackingCode(tracking);
            closeIfExist(field);
            return new CheckData(driver);
        }
    }
}
