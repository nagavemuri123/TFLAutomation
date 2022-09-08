using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
    class JourneyPlanner : BasePage, IJourneyPlanner
    {
        public JourneyPlanner(IWebDriver driver) : base(driver) { }

        #region PageElements
        private IWebElement FromLocation => Driver.FindElement(By.Id("InputFrom"));
        private IWebElement ToLocation => Driver.FindElement(By.Id("InputTo"));
        private IWebElement EditJourney => Driver.FindElement(By.ClassName("edit-journey"));
        private IWebElement RecentTabElement => Driver.FindElement(By.Id("jp-recent-tab-jp"));
        private IWebElement ChangeTime => Driver.FindElement(By.ClassName("change-departure-time"));
        private IWebElement ArrivingElement => Driver.FindElement(By.CssSelector("label[for='arriving']"));

        #endregion PageElements

        public void EnterFromLocation(string fromLocation)
        {
            EnterInputValue(FromLocation, fromLocation);
            SelectValue(fromLocation);
        }

        public void EnterToLocation(string toLocation)
        {
            EnterInputValue(ToLocation, toLocation);
            SelectValue(toLocation);
        }

        public void clickOnJourneyPlannerButton()
        {
            CookieOverlay();
            var element = Driver.FindElement(By.Id("plan-journey-button"));
            Actions actions = new Actions(Driver);
            actions.MoveToElement(element);
            actions.Perform();
            ClickElement(element);
        }

        public bool IsResultsPageDisplayed()
        {
            Thread.Sleep(10000);
            CookieOverlay();
            Boolean isJqueryUsed = (Boolean)((IJavaScriptExecutor)Driver).ExecuteScript("return (typeof(jQuery) != 'undefined')");
            if (isJqueryUsed)
            {
                while (true)
                {
                    Boolean ajaxIsComplete = (Boolean)(((IJavaScriptExecutor)Driver).ExecuteScript("return jQuery.active == 0"));
                    if (ajaxIsComplete) break;
                    try
                    {
                        Thread.Sleep(100);
                    }
                    catch (Exception e)
                    {
                        Trace.WriteLine(e.Message);
                    }
                }

            }
            var element = Driver.FindElement(By.ClassName("jp-results-headline"));
            Actions actions = new Actions(Driver);
            actions.MoveToElement(element);
            actions.Perform();
            if (Driver.FindElement(By.ClassName("jp-results-headline")).Enabled)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsErrorMessageDisplayed()
        {
            var res = Driver.FindElement(By.ClassName("field-validation-errors"));
            return Driver.FindElement(By.ClassName("field-validation-errors")).Displayed;
        }

        public bool UpdateJourney(string toLocation)
        {
            ClickElement(EditJourney);
            EnterToLocation(toLocation);
            clickOnJourneyPlannerButton();
            return IsResultsPageDisplayed();
        }

        public void RecentTabClick()
        {
            Actions actions = new Actions(Driver);
            actions.MoveToElement(RecentTabElement);
            actions.Perform();
            ClickElement(RecentTabElement);
        }

        public bool CheckIfTheRecentTabDisplaysResults()
        {
            return Driver.FindElement(By.Id("jp-recent-content-jp-")).Displayed;
        }

        public void ClickChangeTime()
        {
            ClickElement(ChangeTime);
        }

        public void ClickArriving()
        {
            var res = ArrivingElement;
            ClickElement(ArrivingElement);
        }


    }
}
