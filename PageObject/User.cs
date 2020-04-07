using System.Threading.Tasks;
using AutomationTest.Framework;
using OpenQA.Selenium;

namespace AutomationTest.PageObject
{
    public class User : PageObjectBase
    {
        private static readonly By ByEmail = By.Id("email");
        private static readonly By ByPassword = By.Id("passwd");
        private static readonly By Login = By.Id("SubmitLogin");
        private static readonly By PdfFile = By.XPath("//div[@class='block-center']//a[@class='link-button']");
        private static readonly By OrderHistory =
            By.XPath("//div[@class='col-xs-12 col-sm-6 col-lg-4']//i[@class='icon-list-ol']");
        public User(IWebDriver driver) : base(driver)
        {
        }
        private void InputData(By byType, string data)
        {
            Driver.FindElement(byType).SendKeys(data);
        }
        private void InputData(By byType)
        {
            Driver.FindElement(byType).Click();
        }
        public User OpenUserOrderHistory()
        {
            InputData(ByEmail, Settings.Email);
            InputData(ByPassword, Settings.Password);
            InputData(Login);
            InputData(OrderHistory);
            return this;
        }
        public void LoadFile()
        {
            Driver.FindElement(PdfFile).Click();
            Task.Delay(5000).Wait();
        }
    }
}