using System;
using System.Globalization;
using OpenQA.Selenium;

namespace AutomationTest.PageObject
{
    public class Cart : PageObjectBase
    {
        //public static readonly TimeSpan ImplicitWait = TimeSpan.FromMilliseconds(Convert.ToInt32("3000"));
        public Cart(IWebDriver driver) : base(driver)
        { }
        public double GetCartTotalSum()
        {
            IWebElement totalProducts = Driver.FindElement(By.XPath("//tr[@class='cart_total_price']//td[@class='price']"));
            return Convert.ToDouble(totalProducts.Text.Trim('$'), CultureInfo.InvariantCulture);
        }
    }
}