// Selenium Helper Library
using OpenQA.Selenium;

namespace SeleniumHelperLibrary
{
    public static class WebDriverExtension
    {
        public static string ScreenCaptureAsBase64String(this IWebDriver driver)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot s = ts.GetScreenshot();

            return s.AsBase64EncodedString;
        }
    }
}
