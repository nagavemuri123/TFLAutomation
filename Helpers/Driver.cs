using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tfl_AutomationTest.Helpers
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; } 
        IWebDriver _driver = new ChromeDriver();

        public static void Initialize()
        {
            Instance = new ChromeDriver();
            Instance.Manage().Window.Maximize();
            Console.WriteLine("Opened Chrome");
            Instance.Manage().Cookies.DeleteAllCookies();

        }

        public static void Close()
        {
            Instance.Close();
        }
    }
}
