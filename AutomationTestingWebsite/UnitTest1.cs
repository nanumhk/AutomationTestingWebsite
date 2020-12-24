using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace AutomationTestingWebsite
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"D:\Drivers\chrome");
        }
        
        [Test]
        public void SignInForFlight()
        {
            driver.Url = "http://demo.guru99.com/test/newtours/";
            IWebElement userNameBox = driver.FindElement(By.Name("userName"));
            userNameBox.SendKeys("Ztest");

            IWebElement passWordBox = driver.FindElement(By.Name("password"));
            passWordBox.SendKeys("Test1234");

            IWebElement submitButton = driver.FindElement(By.Name("submit"));
            submitButton.Click();

            IWebElement LoginSuccessfullyMessage = driver.FindElement(By.XPath("//*[text()='Login Successfully']"));
            //The above line can also be written as the line below:
            //IWebElement LoginSuccessfullyMessage = driver.FindElement(By.XPath("//tbody/descendant::tr/descendant::td/descendant::h3"));

            string actualMessage = LoginSuccessfullyMessage.Text;
            string expectedMessage = "Login Successfully";
            Assert.AreEqual(actualMessage, expectedMessage);
        }

        [Test]
        public void BuyTicket()
        {
            driver.Url = "http://demo.guru99.com/test/newtours/";
            IWebElement flights = driver.FindElement(By.XPath("//a[@href='reservation.php']"));
            flights.Click();

            IWebElement onewayRadioButton = driver.FindElement(By.XPath("//input[@value='oneway']"));
            onewayRadioButton.Click();

            IWebElement passengersDropdown = driver.FindElement(By.Name("passCount"));
            SelectElement select = new SelectElement(passengersDropdown);
            select.SelectByIndex(1);
            //above line can be coded as below commented line also
            //select.SelectByValue("2");
            Thread.Sleep(2000);

            IWebElement departingFromDropdown = driver.FindElement(By.Name("fromPort"));
            SelectElement select1 = new SelectElement(departingFromDropdown);
            select1.SelectByIndex(6);
            Thread.Sleep(2000);

            IWebElement departingOnMonthDropdown = driver.FindElement(By.XPath("//*[@name='fromMonth']"));
            SelectElement select2 = new SelectElement(departingOnMonthDropdown);
            select2.SelectByIndex(0);
            Thread.Sleep(2000);

            IWebElement departingOnDayDropdown = driver.FindElement(By.Name("fromDay"));
            SelectElement select3 = new SelectElement(departingOnDayDropdown);
            select3.SelectByIndex(11);
            Thread.Sleep(2000);

            IWebElement arrivingInDropdown = driver.FindElement(By.Name("toPort"));
            SelectElement select4 = new SelectElement(arrivingInDropdown);
            select4.SelectByIndex(3);
            Thread.Sleep(2000);

            IWebElement businessClassRadioButton = driver.FindElement(By.XPath("//input[@name='servClass' and @value='Business']"));
            businessClassRadioButton.Click();
            Thread.Sleep(2000);

            IWebElement airlinesDropdown = driver.FindElement(By.Name("airline"));
            SelectElement select5 = new SelectElement(airlinesDropdown);
            select5.SelectByIndex(2);
            Thread.Sleep(2000);

            IWebElement continueButton = driver.FindElement(By.Name("findFlights"));
            continueButton.Click();
            Thread.Sleep(5000);
          
            //IWebElement finalMessageAfterContinue = driver.FindElement(By.XPath("//tbody/descendant::td/following-sibling::td/descendant::td/descendant::td/descendant::td/descendant::b/descendant::br"));            
            IWebElement finalMessageAfterContinue = driver.FindElement(By.XPath("//font[@size='4']"));
            string actualMessage = finalMessageAfterContinue.Text;
 
             string expectedMessage = "After flight finder - No Seats Avaialble  ";
            Assert.AreEqual(actualMessage, expectedMessage);
        }
    }
}