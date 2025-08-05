using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DotnetSelenium
{
    public static class SeleniumCustomMethods
    {


        public static void EnterText(this IWebElement locator, string text)
        {
            locator.Clear();
            locator.SendKeys(text);
        }

        public static void EAWebstie_Login(IWebDriver driver, WebDriverWait wait)
        {
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            wait.Until(d => d.FindElement(By.Id("loginLink"))).Click();
            wait.Until(d => d.FindElement(By.Name("UserName"))).SendKeys("admin");
            driver.FindElement(By.Name("Password")).SendKeys("password");
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();

        }

        public static void MultiSelectELements(IWebDriver driver, By locator, string[] values)
        {
            SelectElement multiselect = new SelectElement(driver.FindElement(locator));
            foreach (var value in values)
            {
                multiselect.SelectByValue(value);
            }
        }

        public static List<string> GetAllSelectedLists(IWebDriver driver, By locator)
        {
            List<string> options = new List<string>();
            SelectElement multiSelect = new SelectElement(driver.FindElement(locator));

            IList<IWebElement> selectedOption = multiSelect.AllSelectedOptions;

            foreach (IWebElement option in selectedOption)
            {
                options.Add(option.Text);
            }

            return options;
        }
    }
}
