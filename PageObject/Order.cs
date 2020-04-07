using OpenQA.Selenium;

namespace AutomationTest.PageObject
{
    public class Order : PageObjectBase
    {
        private static readonly By ConfirmOrder = By.Id("add_to_cart");
        private static readonly By CloseWindow = By.ClassName("cross");
        public Order(IWebDriver driver) : base(driver)
        { }
        public void AddToCart()
        {
            Driver.FindElement(ConfirmOrder).Click();
            Driver.FindElement(CloseWindow).Click();
        }
    }
}