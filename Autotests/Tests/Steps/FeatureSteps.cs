using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using TechTalk.SpecFlow;
using Tests.PageObject;
using Tests.Settings.Helper;

namespace Tests.Steps
{
    [Binding]
    public class FeatureSteps : BaseTest
    {
        PageObjectIDs pageObjectIDs = new PageObjectIDs();

        [Given(@"I open browser and navigate to (.*) page")]
        public void GivenIOpenBrowserAndNavigateToSearchPage(string search)
        {
            driver.Navigate().GoToUrl("https://" + search + ".com");
            driver.Manage().Window.Maximize();

            PageFactory.InitElements(driver, pageObjectIDs);
        }

        [Then(@"I send keys to search form with the text like (.*)")]
        public void ThenISendKeysToSearchFormWithTheSomeText(string website)
        {
            ScenarioContext.Current["website"] = website;
            FindElementFromName("q").SendKeys(website + Keys.Enter);
        }
        
        [Then(@"verify that first result on the page has a correct link")]
        public void ThenVerifyThatFirstResultOnThePageHasACorrectLink()
        {
            Assert.Multiple(() =>
            {
                StringAssert.AreEqualIgnoringCase("https://www." + ScenarioContext.Current["website"].ToString() + ".ru/", pageObjectIDs.FirstElementOnThePage.FindElement(By.TagName("link")).GetAttribute("href"));
                StringAssert.AreEqualIgnoringCase("https://www." + ScenarioContext.Current["website"].ToString() + ".ru/", pageObjectIDs.FirstElementOnThePage.FindElement(By.TagName("a")).GetAttribute("href"));
            });
        }
    }
}
