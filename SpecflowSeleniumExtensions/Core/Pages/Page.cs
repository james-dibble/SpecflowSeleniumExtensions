namespace Core.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public abstract class Page : IPage
    {
        private readonly IWebDriver _driver;

        protected Page(IWebDriver driver)
        {
            this._driver = driver;
        }

        public abstract string Title { get; }

        public abstract string BaseUrl { get; }

        protected IWebDriver Driver
        {
            get
            {
                return this._driver;
            }
        }

        public void Open()
        {
            this.Open(null);
        }

        public void Open(IDictionary<string, string> postArguments)
        {
            var url = this.BaseUrl;

            if (postArguments != null)
            {
                url += string.Join("&", postArguments.Select(arg => arg.Key + "=" + arg.Value));    
            }

            this.Driver.Navigate().GoToUrl(url);

            var wait = new WebDriverWait(this._driver, TimeSpan.FromSeconds(30));

            var result = wait.Until(driver => driver.Title == this.Title);

            if (!result)
            {
                throw new NotFoundException("Page could not be loaded.");
            }
        }
    }
}