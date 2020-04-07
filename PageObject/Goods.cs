using System;
using System.Globalization;
using OpenQA.Selenium;

namespace AutomationTest.PageObject
{
    public class Goods : PageObjectBase
    {
        private string GoodsName { get; }
        private double GoodsPrice { get; set; }
        public static double OrderSum { get; set; }
        public Goods(IWebDriver driver, string goodsName) : base(driver)
        {
            GoodsName = goodsName;
        }
        public void GetPrice(string goodsName)
        {
            Driver.FindElement(By.LinkText(goodsName)).Click();
            IWebElement priceText = Driver.FindElement(By.XPath("//p[@class='our_price_display']"));
            double price = Convert.ToDouble(priceText.Text.Trim('$'), CultureInfo.InvariantCulture);
            GoodsPrice = price;
        }
        public void GetOrderSum()
        {
            OrderSum += GoodsPrice;
        }
    }
}