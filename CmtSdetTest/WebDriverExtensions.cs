using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public static class WebDriverExtensions
{
    //Note I default this to 10, meaning there is no need to specify a wait time each usage
    public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds = 10)
    {
        if (timeoutInSeconds > 0)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(drv => drv.FindElement(by));
        }
        return driver.FindElement(by);
    }
}
