using DotnetSelenium.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace DotnetSelenium
{

    [TestFixture("admin", "password")]
    [TestFixture("admin", "password2")]
    [TestFixture("admin", "password3")]
    public class Tests
    {

        private IWebDriver _driver;
        private readonly string userName;
        private readonly string password;

        public Tests(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        [SetUp]
        public void Setup()
        {
            //1. Create a new instance of Selenium Web 
            _driver = new ChromeDriver();

            //2. Navigate to the URL
            _driver.Navigate().GoToUrl("https://www.google.com/");

            //2a. Maximize the browser window
            _driver.Manage().Window.Maximize();
        }



        [Test]
        public void Should_Open_Browser_And_Search_Selenium()
        {



            //3. Find the element
            IWebElement webElement = _driver.FindElement(By.Name("q"));

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

            var selectElement = new SelectElement(driver.FindElement(By.Name("Grade")));
            selectElement.SelectByText("Middle");

        }

        [Test]
        public void TestWithPom()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            //POM initialization
            LoginPage loginPage = new LoginPage(driver);

            loginPage.ClickLogin();

            loginPage.Login("admin", "password");
        }
        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
    }
}