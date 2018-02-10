using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace FlightBookingTestFramework
{
    public class LoginPage
    {
        private IWebDriver driver;
 
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
 
        [FindsBy(How = How.Name, Using = "userName")]
        private IWebElement userName;
 
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement password;

        [FindsBy(How = How.Name, Using = "login")]
        private IWebElement signIn;

        public void Login(string username, string pwd)
        {
            userName.SendKeys(username);
            password.SendKeys(pwd);
            signIn.Click();
        }
    }
}
