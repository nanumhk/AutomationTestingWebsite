using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace WebsiteAutomationSaucedemo
{
    public class Tests
    {
        IWebDriver driver;
        WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"D:\Drivers\chrome\chromedriver_win32");
            driver.Url = "https://www.saucedemo.com/index.html";
            //driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        [Test]
        public void CheckoutWithPersonalInformationAndItemsOnCart()
        {
            IWebElement userNameBox = driver.FindElement(By.Id("user-name"));
            userNameBox.SendKeys("standard_user");

            IWebElement passwordBox = driver.FindElement(By.Id("password"));
            passwordBox.SendKeys("secret_sauce");

            IWebElement loginBox = driver.FindElement(By.Id("login-button"));
            loginBox.Click();

            IWebElement tShirtAddToCartBox = driver.FindElement(By.XPath("//*[@id='inventory_container']/div/div[6]/div[3]/button"));
            tShirtAddToCartBox.Click();

            IWebElement shoppingCartLogo = driver.FindElement(By.Id("shopping_cart_container"));
            shoppingCartLogo.Click();

            IWebElement removeBoxInCart = driver.FindElement(By.CssSelector(".btn_secondary.cart_button"));
            removeBoxInCart.Click();

            IWebElement continueShoppingBox = driver.FindElement(By.ClassName("btn_secondary"));
            continueShoppingBox.Click();

            //IWebElement onesieAddToCartBox = driver.FindElement(By.XPath("//*[@id='inventory_container']/div/div[1]/div[3]/button"));
            IWebElement onesieAddToCartBox = driver.FindElement(By.XPath("//*[@id='inventory_container']/div/div[5]/div[3]/button"));
           // wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='inventory_container']/descendant::div/child::div[5]/child::div[3]/button")));
            //IWebElement onesieAddToCartBox = driver.FindElement(By.XPath("//div[@id='inventory_container']/descendant::div/child::div[5]/child::div[3]/button"));
            onesieAddToCartBox.Click();

            //Trying to overcome the staleElementException
            driver.Navigate().Refresh();
            Thread.Sleep(10000);
            //wait. Until(ExpectedConditions.ElementExists(By.Id("shopping_cart_container")));
            //WebDriverWait wait = new WebDriverWait(driver,30);
            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(),'COMPOSE')]")));
            shoppingCartLogo.Click();

            IWebElement priceBox = driver.FindElement(By.ClassName("inventory_item_price"));
            priceBox.Click();
            Console.WriteLine(priceBox);
            continueShoppingBox.Click();
            tShirtAddToCartBox.Click();
            shoppingCartLogo.Click();

            IWebElement checkOutBox = driver.FindElement(By.CssSelector(".btn_action.checkout_button"));
            checkOutBox.Click();

            IWebElement firstNameBox = driver.FindElement(By.Id("first-name"));
            firstNameBox.SendKeys("Zorba");

            IWebElement lastNameBox = driver.FindElement(By.Id("last-name"));
            lastNameBox.SendKeys("Test");

            IWebElement zipCode = driver.FindElement(By.Id("postal-code"));
            zipCode.SendKeys("12345");

            IWebElement continueBoxOnInformationPage = driver.FindElement(By.CssSelector(".btn_primary.cart_button"));
            continueBoxOnInformationPage.Click();

            IWebElement finishBox = driver.FindElement(By.CssSelector(".btn_action.cart_button"));
            finishBox.Click();

            IWebElement finishMessage = driver.FindElement(By.ClassName("complete-header"));
            Assert.AreEqual(finishMessage.Text , "THANK YOU FOR YOUR ORDER");
        }
    }
}