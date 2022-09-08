using BoDi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Tfl_AutomationTest.Helpers;
using Tfl_AutomationTest.Interfaces;
using Tfl_AutomationTest.Pages;

namespace Tfl_AutomationTest.Steps
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private IJourneyPlanner _journeyPlanner;
        private readonly ScenarioContext _scenarioContext;

        public Hooks(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            this._objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void Initialize()
        {
            if (Driver.Instance == null)
                Driver.Initialize();
            else
            {
                Driver.Instance.Manage().Cookies.DeleteAllCookies();
            }
            _journeyPlanner = new JourneyPlanner(Driver.Instance);
            _objectContainer.RegisterInstanceAs(_journeyPlanner);
        }


        [AfterTestRun]
        public static void CloseDriver()
        {
            Driver.Close();
            foreach (var process in Process.GetProcesses())
            {
                if (process.ProcessName == "chromedriver")
                {
                    process.Kill();
                }
            }
        }
    }
}
