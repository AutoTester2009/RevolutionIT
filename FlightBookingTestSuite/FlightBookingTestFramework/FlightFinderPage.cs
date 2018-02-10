using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace FlightBookingTestFramework
{
    public class FlightFinderPage
    {
        private IWebDriver driver;

        public FlightFinderPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@value='roundtrip']")]
        private IWebElement typeRoundTrip;

        [FindsBy(How = How.XPath, Using = "//input[@value='oneway']")]
        private IWebElement typeOneWay;
 
        [FindsBy(How = How.Name, Using = "fromPort")]
        private IWebElement fromCity;

        [FindsBy(How = How.Name, Using = "toPort")]
        private IWebElement toCity;

        [FindsBy(How = How.XPath, Using = "//input[@value='Coach']")]
        private IWebElement serviceEconomyClass;

        [FindsBy(How = How.XPath, Using = "//input[@value='Business']")]
        private IWebElement serviceBusinessClass;

        [FindsBy(How = How.XPath, Using = "//input[@value='First']")]
        private IWebElement serviceFirstClass;

        [FindsBy(How = How.XPath, Using = "//input[contains(@src, 'continue')]")]
        private IWebElement continueBtn;

        private void SelectTripType(bool oneway)
        {
            if (oneway)
                typeOneWay.Click();
            else
                typeRoundTrip.Click();
        }

        private void SelectFromCity(string city)
        {
            SelectElement selector = new SelectElement(fromCity);
            selector.SelectByText(city);
        }

        private void SelectToCity(string city)
        {
            SelectElement selector = new SelectElement(toCity);
            selector.SelectByText(city);
        }

        private void SelectServiceClass(string sclass)
        {
            switch (sclass) {

                case "First":
                    serviceFirstClass.Click();
                    break;
                case "Business":
                    serviceBusinessClass.Click();
                    break;
                case "Economy":
                    serviceEconomyClass.Click();
                    break;
                default:
                    serviceEconomyClass.Click();
                    break;
            }
        }

        public void FindFlights(bool oneway, string fromCity, string toCity, string serviceClass)
        {
            SelectTripType(oneway);
            SelectFromCity(fromCity);
            SelectToCity(toCity);
            SelectServiceClass(serviceClass);
            continueBtn.Click();
        }


    }
}
