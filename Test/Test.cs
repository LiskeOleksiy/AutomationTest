using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using AutomationTest.Framework;
using AutomationTest.PageObject;
using NUnit.Framework;

namespace AutomationTest.Test
{
    [TestFixture]
    public class Test
    {
        private static readonly TimeSpan ImplicitWait = TimeSpan.FromMilliseconds(Convert.ToInt32("3000"));
        private  IWebDriver _driver;
        private  MainPage _mainPage;
        private double _sum;
        private void DriverSettings()
        {
            _driver = new ChromeDriver(Directory.GetCurrentDirectory());
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = ImplicitWait;
            _driver.Navigate().GoToUrl(Settings.Url);
            _mainPage = new MainPage(_driver);
        }
        [TearDown]
        public void OneTimeTearDown() => _driver.Quit();
        [Test]
        [TestCase(new object []{"Faded Short Sleeve T-shirts","Blouse"})]
        [TestCase(new object []{"Printed Summer Dress","Printed Chiffon Dress"})]
        [TestCase(new object []{"Printed Chiffon Dress","Printed Chiffon Dress"})]
        public void TestTotalProducts(params string[] goodsArray)
        {
            DriverSettings();
            _sum = 0;
            Order order = _mainPage.OpenWomenSite();
            foreach (string goodsName in goodsArray)
            {
                Goods goods = new Goods(_driver, goodsName);
                goods.GetPrice(goodsName);
                order.AddToCart().GetOrderSum(goods.GoodsPrice);
                _mainPage.OpenWomenSite();
            }
            _sum = Math.Round((order.OrderSum),2);
            Cart cart = _mainPage.OpenCart();
            Assert.That(cart.GetCartTotalSum(),Is.EqualTo(_sum), "Order sum is not valid");
        }
        [Test] 
        public void TestLoadFile()
        {
            DriverSettings();
            User user = _mainPage.OpenLoginPage();
            user.OpenUserOrderHistory().LoadFile();
            if (File.Exists(Settings.DownloadFolder+"\\IN175936.pdf"))
            {
                Assert.That(true);
            }
            else
            {
                Assert.Fail("The directory or folder does not exist.");
            } 
        }
    }
}