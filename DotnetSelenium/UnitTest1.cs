using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V136.Input;
using OpenQA.Selenium.Support.UI;

namespace DotnetSelenium
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Should_Open_Browser_And_Search_Selenium()
        {
            //sudo code for setting up selenium
            //1. Create a new instance of Selenium Web Driver
            IWebDriver driver = new ChromeDriver();
            //2. Navigate to the URL
            driver.Navigate().GoToUrl("https://www.google.com/");
            //2a. Maximize the browser window
            driver.Manage().Window.Maximize();
            //3. Find the element
            IWebElement webElement = driver.FindElement(By.Name("q"));
            //4. Type in the element
            webElement.SendKeys("Selenium");
            //5. Click on the element
            webElement.SendKeys(Keys.Return);
        }

        [Test]
        public void ShouldLoginToEAppWebsiteSuccessfully()
        {
            // Setup: Create a new instance of ChromeDriver and configure waits
            using IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Window.Maximize();

            // Navigate to the EA App website
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");

            // Click the login link
            wait.Until(d => d.FindElement(By.Id("loginLink"))).Click();

            // Enter username
            wait.Until(d => d.FindElement(By.Name("UserName"))).SendKeys("admin");

            // Enter password
            driver.FindElement(By.Name("Password")).SendKeys("password");

            // Click login button
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();

            // Assert: Verify login was successful by checking for the logout link
            IWebElement logoutLink = wait.Until(d => d.FindElement(By.LinkText("Log off")));
            Assert.IsTrue(logoutLink.Displayed, "Login was not successful - logout link not found.");
        }

    }
}