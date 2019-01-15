using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Tests.PageObject
{
    class PageObjectIDs
    {
        /// <summary>First element on the search page</summary>
        [FindsBy(How = How.Id, Using = "rso")]
        public IWebElement FirstElementOnThePage { get; set; }
    }
}

