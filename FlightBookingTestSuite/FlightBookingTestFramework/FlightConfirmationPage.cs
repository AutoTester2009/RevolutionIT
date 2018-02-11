using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlightBookingTestFramework
{
    public class FlightCongirmationPage
    {
        private IWebDriver driver;

        public FlightCongirmationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // Remove the trailing \r character
        private string Clean(string str)
        {
            return str.Replace("\r","");
        }
 

        private void VerifyDetails(string actualFlightDetails, string expectedFrom, string expectedTo, int expectedFlightNum, string expectedClass)
        {
            var lines = actualFlightDetails.Split('\n');
            string actualFrom = Clean(lines[0]).Split(' ')[0];
            string actualTo = Clean(lines[0]).Split(' ')[2];
            string actualFlightNum = Regex.Replace(Clean(lines[1]), "^.*Airlines ", "");
            string actualClass = Clean(lines[2]);

            Assert.AreEqual(expectedFrom, actualFrom);
            Assert.AreEqual(expectedTo, actualTo);
            Assert.AreEqual(expectedFlightNum.ToString(), actualFlightNum);
            Assert.AreEqual(expectedClass, actualClass);           
        }

        public void VerifyDepartureDetails(string expectedFrom, string expectedTo, int expectedFlightNum, string expectedClass)
        {
            IList<IWebElement> elems = driver.FindElements(By.XPath("//td[@class='frame_header_info']"));
            VerifyDetails(elems[2].Text, expectedFrom, expectedTo, expectedFlightNum, expectedClass);
        }

        public void VerifyArrivalDetails(string expectedFrom, string expectedTo, int expectedFlightNum, string expectedClass)
        {
            IList<IWebElement> elems = driver.FindElements(By.XPath("//td[@class='frame_header_info']"));
            VerifyDetails(elems[4].Text, expectedFrom, expectedTo, expectedFlightNum, expectedClass);
        }

    }
}
