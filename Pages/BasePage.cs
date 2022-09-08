using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tfl_AutomationTest.Interfaces;

namespace Tfl_AutomationTest.Pages
{
    class BasePage : IBasePage
    {
        protected IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void NavigateToUrl()
        {
            Driver.Navigate().GoToUrl("https://tfl.gov.uk/plan-a-journey/");
        }

        public void EnterInputValue(IWebElement inputElement, string value)
        {
            inputElement.Clear();
            inputElement.SendKeys(value);
        }

        public void ClickElement(IWebElement element)
        {
            Wait(element);
            element.Click();
        }
        /// <summary>
        /// This method removes cookie banner
        /// </summary>
        public void CookieOverlay()
        {
            var js = (IJavaScriptExecutor)Driver;
            try
            {
                Boolean flag = (Boolean)js.ExecuteScript("return window.jQuery('#cb-cookieoverlay').is(':visible')");
                if (flag == true)
                    js.ExecuteScript("window.jQuery('#cb-cookieoverlay', window.parent.document).remove()");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void Wait(IWebElement element)
        {
            Thread.Sleep(TimeSpan.FromSeconds(60));
            CookieOverlay();
        }

        /// <summary>
        /// Selects value from the drop down
        /// </summary>
        /// <param name="fromLocation"></param>
        public void SelectValue(string fromLocation)
        {
            CookieOverlay();
            IList<IWebElement> stops = Driver.FindElements(By.ClassName("stop-name"));
            foreach (var el in stops)
            {
                var text = el.Text;
                if (text.Contains(fromLocation))
                {
                    try
                    {
                        Thread.Sleep(5000);
                    }
                    catch (Exception e)
                    {
                        Trace.WriteLine(e.Message);
                    }

                    ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", el);
                    break;
                }
            }
        }
    }
}
