using System;
using System.Globalization;
using OpenQA.Selenium;

namespace AutomationTest.PageObject
{
    public class Cart : PageObjectBase
    {
        public Cart(IWebDriver driver) : base(driver)
        { }
        public double GetCartTotalSum()
        {
            IWebElement totalProducts = Driver.FindElement(By.XPath("//tr[@class='cart_total_price']//td[@class='price']"));
            Console.WriteLine(Convert.ToDouble(totalProducts.Text.Trim('$'), CultureInfo.InvariantCulture));
            return Convert.ToDouble(totalProducts.Text.Trim('$'), CultureInfo.InvariantCulture);
        }
    }
}