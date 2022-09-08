Used Page object model when designing framework
Added common step ( which is Given I am on plan a journey ) under Background so that it isn’t duplicated in every scenario.
Used Bodi Object container to register JourneyPlanner page class instance.This means that instance is created once and can be reused.
Used Constructor Injection in JourneyPlannerSteps class - this way the injected component can be used anywhere in that class.
Added common used methods in BasePage class - this way the methods can be reused any where in the project just by inheriting BasePage class.
Used Selenium.Interactions.Actions to move to a particular element and perform the action, below is the code: 
Actions actions = new Actions(Driver);
            actions.MoveToElement(element);
            actions.Perform();
            ClickElement(element);
To locate elements,used Id/Classname/Cssselector as that is the best approach instead of XPath.
 
