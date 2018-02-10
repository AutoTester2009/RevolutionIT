using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace FlightBookingTestFramework
{
    public class BookFlightPage
    {
        private IWebDriver driver;
 
        public BookFlightPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
 
        [FindsBy(How = How.Name, Using = "passFirst0")]
        private IWebElement firstName;
 
        [FindsBy(How = How.Name, Using = "passLast0")]
        private IWebElement lastName;

        [FindsBy(How = How.Name, Using = "creditnumber")]
        private IWebElement creditCardNum;

        [FindsBy(How = How.Name, Using = "buyFlights")]
        private IWebElement securePurchase;

        public void EnterDetails(string firstname, string lastname, string creditnum)
        {
            firstName.SendKeys(firstname);
            lastName.SendKeys(lastname);
            creditCardNum.SendKeys(creditnum);
            securePurchase.Click();
        }
    }
}
