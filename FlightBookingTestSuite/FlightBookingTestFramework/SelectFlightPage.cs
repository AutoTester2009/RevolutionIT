using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace FlightBookingTestFramework
{
    public class SelectFlightPage
    {
        private IWebDriver driver;
 
        public SelectFlightPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
 
        [FindsBy(How = How.XPath, Using = "//input[contains(@src, 'continue')]")]
        private IWebElement continueBtn;

        private IWebElement GetDepartureFlightRadioButton(int flightNum)
        {           
           return driver.FindElement(By.XPath("//b[contains(text(),'" + flightNum + "')]/../../../td/input[@type='radio']"));
        }

        private IWebElement GetArrivalFlightRadioButton(int flightNum)
        {
            return driver.FindElement(By.XPath("//b[contains(text(),'" + flightNum + "')]/../../../td/input[@type='radio']"));
        }

        public void SelectFlightNumbers(int departure, int arrival)
        {
            GetDepartureFlightRadioButton(departure).Click();
            GetArrivalFlightRadioButton(arrival).Click();
            continueBtn.Click();
        }
    }
}
