using OpenQA.Selenium;

namespace AutomationTest.PageObject
{
    public class MainPage : PageObjectBase
    {
        private static readonly By WomanButton = By.LinkText("Women");
        private static readonly By CartButton = By.XPath("//div[@class='shopping_cart']//a[@title='View my shopping cart']");
        private static readonly By SigninButton = By.ClassName("login");
        public MainPage(IWebDriver driver) : base(driver)
        {}
        public Order OpenWomenSite()
        {
            Driver.FindElement(WomanButton).Click();
            return new Order(Driver);
        }
        public Cart OpenCart()
        {
            Driver.FindElement(CartButton).Click();
            return new Cart(Driver);
        }
        public User OpenLoginPage()
                {
                    Driver.FindElement(SigninButton).Click();
                    return new User(Driver);
                }
    }
}