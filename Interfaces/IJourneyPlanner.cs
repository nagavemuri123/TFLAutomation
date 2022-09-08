using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tfl_AutomationTest.Interfaces
{
    public interface IJourneyPlanner : IBasePage
    {
        void EnterFromLocation(string fromLocation);
        void EnterToLocation(string toLocation);
        void clickOnJourneyPlannerButton();
        bool IsResultsPageDisplayed();
        bool IsErrorMessageDisplayed();
        bool UpdateJourney(string toLocation);
        void RecentTabClick();
        bool CheckIfTheRecentTabDisplaysResults();
        void ClickChangeTime();
        void ClickArriving();
    }
}
