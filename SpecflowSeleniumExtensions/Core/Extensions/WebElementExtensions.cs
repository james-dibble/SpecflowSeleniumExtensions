namespace Core.Extensions
{
    using System;
    using System.Linq;

    using OpenQA.Selenium;

    public static class WebElementExtensions
    {
        public static bool HasClass(this IWebElement element, string cssClass)
        {
            var classValue = element.GetAttribute("class");
            
            if (string.IsNullOrEmpty(classValue))
            {
                return false;
            }

            var classes = classValue.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            return classes.Any(@class => @class == cssClass);
        }
    }
}