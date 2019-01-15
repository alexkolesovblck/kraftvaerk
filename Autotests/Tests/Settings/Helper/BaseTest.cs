using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace Tests.Settings.Helper
{
    public class BaseTest
    {
        protected string GetDownloadPath()
        {
            string downloadPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Downloads");
            return downloadPath;
        }

        protected IWebDriver driver
        {
            [BeforeScenario]
            get
            {
                if (!ScenarioContext.Current.ContainsKey("browser"))
                {
                    var options = new ChromeOptions();
                    var downloadPath = GetDownloadPath();
                    Directory.CreateDirectory(downloadPath);

                    options.AddUserProfilePreference("download.default_directory", downloadPath);
                    options.AddUserProfilePreference("download.prompt_for_download", false);
                    options.AddUserProfilePreference("savefile.default_directory", downloadPath);

                    ScenarioContext.Current["browser"] = new ChromeDriver(options);

                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                    driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(20);
                    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);

                    driver.Manage().Cookies.DeleteAllCookies();
                }
                return (IWebDriver)ScenarioContext.Current["browser"];
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var path = GetDownloadPath();
            if (Directory.Exists(path))
            {
                DirectoryInfo di = new DirectoryInfo(path);

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
            }

            if (driver != null)
                driver.Quit();
        }

        public IWebElement WaitForElement(By locator)
        {
            WebDriverWait waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            return waitForElement.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public IWebElement FindElementFromCssSelector(string path)
        {
            return driver.FindElement(By.CssSelector(path));
        }

        public IWebElement FindElementFromTagName(string path)
        {
            return driver.FindElement(By.TagName(path));
        }

        public IWebElement FindElementFromXpath(string path)
        {
            return driver.FindElement(By.XPath(path));
        }

        public IWebElement FindElementFromClassName(string path)
        {
            return driver.FindElement(By.ClassName(path));
        }

        public IWebElement FindElementFromId(string path)
        {
            return driver.FindElement(By.Id(path));
        }

        public IWebElement FindElementFromLinkText(string path)
        {
            return driver.FindElement(By.LinkText(path));
        }

        public IWebElement FindElementFromName(string path)
        {
            return driver.FindElement(By.Name(path));
        }

        /// <summary>
        /// Убедиться в том, что элемент присутствует на странице
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        /// <exception cref="NoSuchElementException"></exception>
        public bool ElementIsVisible(IWebElement element)
        {
            return element.Displayed && element.Enabled;
        }

        /// <summary>
        /// Получить видимость элемента, если элемент отсутствует возвращает false
        /// </summary>
        /// <param name="element"></param>
        /// <returns>true если элемент найден и видимый</returns>
        public bool CheckElementIsVisibleSafe(IWebElement element)
        {
            try
            {
                return element.Displayed && element.Enabled;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
