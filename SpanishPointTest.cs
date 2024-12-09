using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace SeleniumAutomation
{
    [TestFixture]
    public class MatchingEngineTests
    {
        private IWebDriver driver = null;

         [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); 
        }


        [Test]
        public void VerifySupportedProducts()
        {
            
            driver.Navigate().GoToUrl("https://www.matchingengine.com/");
            
            var modulesMenu = driver.FindElement(By.LinkText("Modules"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(modulesMenu).Perform();
            var repertoireModuleLink = driver.FindElement(By.LinkText("Repertoire Management Module"));
            repertoireModuleLink.Click();
            var additionalFeaturesSection = driver.FindElement(By.XPath("//h2[contains(text(),'Additional Features')]"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", additionalFeaturesSection);

            var productsSupportedButton = driver.FindElement(By.LinkText("Products Supported"));
            productsSupportedButton.Click();
            
            var supportedProductsHeading = driver.FindElement(By.XPath("//h3[contains(text(),'There are several types of Product Supported:')]"));
            Assert.That(supportedProductsHeading.Displayed, "Supported products heading is not displayed.");

            //var supportedProductsList = driver.FindElements(By.XPath("//h3[contains(text(),'There are several types of Product Supported:')]/following-sibling::ul/li"));
            //Assert.That(supportedProductsList.Count, Is.GreaterThan(0), "Supported products list is empty.");


        //     Console.WriteLine("Supported products:");
        //     foreach (var product in supportedProductsList)
        //     {
        //         Console.WriteLine(product.Text);
        //     }
         }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
