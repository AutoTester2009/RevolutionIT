using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FlightBookingTestFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

namespace ConsoleApplication1
{
    class Program
    {
        static public IWebDriver driver;

        static public void TestCase1(IWebDriver driver)
        {
            // Test Data
            string Username = "mercury";
            string Password = "mercury";
            bool OneWay = true;
            string CityFrom =  "Sydney";
            string CityTo = "London";
            string Class = "First";
            string FirstName = "James";
            string LastName = "Smith";
            string CCNum = "12345678";
            int DepartureFlightNum = 362;
            int ArrivalFlightNum = 630;

            LoginPage LoginPage = new LoginPage(driver);
            FlightFinderPage FlightFinderPage = new FlightFinderPage(driver);
            SelectFlightPage SelectFlightPage = new SelectFlightPage(driver);
            BookFlightPage BookFlightPage = new BookFlightPage(driver);
            FlightCongirmationPage FlightConfirmationPage = new FlightCongirmationPage(driver);

            driver.Navigate().GoToUrl("http://newtours.demoaut.com/");

            LoginPage.Login(Username, Password);
            FlightFinderPage.FindFlights(OneWay, CityFrom, CityTo, Class);
            SelectFlightPage.SelectFlightNumbers(DepartureFlightNum, ArrivalFlightNum);
            BookFlightPage.EnterDetails(FirstName, LastName, CCNum);
            FlightConfirmationPage.VerifyDepartureDetails(CityFrom, CityTo, DepartureFlightNum, Class);
            FlightConfirmationPage.VerifyArrivalDetails(CityTo, CityFrom, ArrivalFlightNum, Class);
        }

        /// <summary>
        /// Note: I am using Visual Studio 2012 and having problems installing latest version of NUnit. So I just created my own test runner.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            TestCase1(driver);
        }
    }
}
