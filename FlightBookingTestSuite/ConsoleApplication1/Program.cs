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

        static void Main(string[] args)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            LoginPage LoginPage = new LoginPage(driver);
            FlightFinderPage FlightFinderPage = new FlightFinderPage(driver);
            SelectFlightPage SelectFlightPage = new SelectFlightPage(driver);
            BookFlightPage BookFlightPage = new BookFlightPage(driver);
            FlightCongirmationPage FlightConfirmationPage = new FlightCongirmationPage(driver);

            driver.Navigate().GoToUrl("http://newtours.demoaut.com/");

            Thread.Sleep(3000);

            LoginPage.Login("mercury", "mercury");
            FlightFinderPage.FindFlights(true, "Sydney", "London", "First");
            SelectFlightPage.SelectFlightNumbers(363, 630);
            BookFlightPage.EnterDetails("James", "Do", "1234897");
            FlightConfirmationPage.VerifyDepartureDetails("Sydney", "London", 363, "First");
            FlightConfirmationPage.VerifyArrivalDetails("London", "Sydney", 630, "First");

        }
    }
}
