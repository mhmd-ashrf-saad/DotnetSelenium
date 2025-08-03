using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DotnetSelenium
{
    public class SeleniumCustomMethods
    {
        public static void Click(IWebDriver driver, By locator)
        {
            driver.FindElement(locator).Click();
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
