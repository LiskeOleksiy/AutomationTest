using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
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
        private readonly IWebDriver _driver;
        private readonly MainPage _mainPage;
        private double _sum;
        private readonly List<string> _goods = new List<string>(2) {"Faded Short Sleeve T-shirts","Blouse"};
        public Test()
        {
            _driver = new ChromeDriver(Directory.GetCurrentDirectory());
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = ImplicitWait;
            _driver.Navigate().GoToUrl(Settings.Url);
            _mainPage = new MainPage(_driver);
        }
        [OneTimeTearDown]
        public void OneTimeTearDown() => _driver.Quit();
        [Test] 
        public void TestTotalProducts()
        {
            Order order = _mainPage.OpenWomenSite();
            foreach (string goodsName in _goods)
            {
                Goods goods = new Goods(_driver, goodsName);
                goods.GetPrice(goodsName);
                order.AddToCart();
                goods.GetOrderSum();
                order = _mainPage.OpenWomenSite();
            }
            _sum = Math.Round((Goods.OrderSum),2);
            Cart cart = _mainPage.OpenCart();
            Assert.That(cart.GetCartTotalSum(),Is.EqualTo(_sum));
        }
        [Test] 
        public void TestLoadFile()
        {
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