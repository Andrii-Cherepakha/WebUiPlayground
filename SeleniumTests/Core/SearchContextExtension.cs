using System.Diagnostics;
using OpenQA.Selenium;

namespace SeleniumTests.Core
{
    public static class SearchContextExtension
    {
        public static IWebElement GetElement(this ISearchContext search, By locator) => search.GetElements(locator).FirstOrDefault();

        public static IReadOnlyCollection<IWebElement> GetElements(this ISearchContext search, By locator)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            IReadOnlyCollection<IWebElement> elements = null;

            while (elements == null || elements.Count == 0)
            {
                elements = search.FindElements(locator);
                if (stopwatch.Elapsed > WaitForElementTimeout && elements.Count == 0)
                    throw new NoSuchElementException($"Locator: {locator}");

                Thread.Sleep(SleepInterval);
            }

            return elements;
        }

        private static readonly TimeSpan WaitForElementTimeout = TimeSpan.FromSeconds(15);
        private static readonly TimeSpan SleepInterval = TimeSpan.FromMilliseconds(500);
    }
}
