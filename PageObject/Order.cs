using OpenQA.Selenium;

namespace AutomationTest.PageObject
{
    public class Order : PageObjectBase
    {
        private static readonly By ConfirmOrder = By.Id("add_to_cart");
        private static readonly By CloseWindow = By.ClassName("cross");
        public double OrderSum;
        public Order(IWebDriver driver) : base(driver)
        { }
        public Order AddToCart()
        {
            Driver.FindElement(ConfirmOrder).Click();
            Driver.FindElement(CloseWindow).Click();
            return this;
        }
        public void GetOrderSum(double goodsPrice)
        {
            OrderSum += goodsPrice;
        }
    }
}