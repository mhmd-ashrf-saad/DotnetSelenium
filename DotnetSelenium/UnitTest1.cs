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


            SeleniumCustomMethods.EAWebstie_Login(driver, wait);

            // Assert: Verify login was successful by checking for the logout link
            IWebElement logoutLink = wait.Until(d => d.FindElement(By.LinkText("Log off")));
            Assert.IsTrue(logoutLink.Displayed, "Login was not successful - logout link not found.");
        }

        [Test]
        public void Working_With_Advanced_Controls()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://eaapp.somee.com/Employee/Create");

            var selectElement= new SelectElement(driver.FindElement(By.Name("Grade")));
            selectElement.SelectByText("Middle");

        }

    }
}