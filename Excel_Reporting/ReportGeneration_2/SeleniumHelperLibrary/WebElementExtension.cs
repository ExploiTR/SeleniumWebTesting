using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ReportingLibrary;
using WaitHelpers = SeleniumExtras.WaitHelpers;

namespace SeleniumHelperLibrary
{
    public static class WebElementExtension
    {
        public static bool ControlDisplayed(this IWebElement element, IWebDriver driver, ExtentReportsHelper ERH, string elementName, bool displayed = true, uint timeoutInSeconds = 60)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.IgnoreExceptionTypes(typeof(Exception));

            return wait.Until(drv =>
            {
                if(!displayed && !element.Displayed || displayed && element.Displayed)
                {
                    ERH.SetStepStatusPass($"[{elementName}] is displayed on the page");

                    return true;
                }

                ERH.SetStepStatusPass($"[{elementName}] is displayed on the page");

                return false;

            });
        }

        public static void ClearWrapper(this IWebElement element, ExtentReportsHelper ERH, string elementName)
        {
            element.Clear();

            if (element.Text.Equals(string.Empty))
            {
                ERH.SetStepStatusPass($"Clear Element [{elementName}] content");
            }
            else
            {
                ERH.SetStepStatusWarning($"Element [{elementName}] content is not cleared. Element Value is [{element.Text}]");
            }
        }

        public static bool ElementIsClickable(this IWebElement element, IWebDriver driver, ExtentReportsHelper ERH, string elementName, uint timeoutInSeconds = 60)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

                return wait.Until(drv =>
                {
                    if (WaitHelpers.ExpectedConditions.ElementToBeClickable(element) != null)
                    {
                        ERH.SetStepStatusPass($"[{elementName}] is clickable on the page");

                        return true;
                    }

                    ERH.SetStepStatusWarning($"[{elementName}] is not clickable on the page");

                    return false;

                });
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public static void ClickWrapper(this IWebElement element, IWebDriver driver, ExtentReportsHelper ERH, string elementName)
        {
            if (element.ElementIsClickable(driver, ERH, elementName))
            {
                element.Click();

                ERH.SetStepStatusPass($"Clicked on the Element [{elementName}]");
            }
            else
            {
                throw new Exception($"Element [{elementName}] is NOT displayed");
            }
        }

        public static void SendKeysWrapper(this IWebElement element, ExtentReportsHelper ERH, string elementName, string value)
        {
            element.SendKeys(value);

            ERH.SetStepStatusPass($"SendKeys Value [{value}] to element [{elementName}]");
        }

        public static bool ValidatePageTitle(this IWebDriver driver, ExtentReportsHelper ERH, string title, uint timeoutInSeconds = 300)
        {
            bool result = false;

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.IgnoreExceptionTypes(typeof(Exception));

            return result = wait.Until(drv =>
            {
                if (drv.Title.Contains(title))
                {
                    ERH.SetStepStatusPass($"Page Title [{drv.Title}] contains [{title}]");

                    return true;
                }

                ERH.SetStepStatusWarning($"Page Title [{drv.Title}] does not contains [{title}]");

                return false;

            });
        }

        public static bool ValidateURLContain(this IWebDriver driver, ExtentReportsHelper ERH, string urlPart, uint timeoutInSeconds = 120)
        {
            bool result = false;

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.IgnoreExceptionTypes(typeof(Exception));

            return result = wait.Until(drv =>
            {
                if (drv.Url.Contains(urlPart))
                {
                    ERH.SetStepStatusPass($"Page Title [{drv.Url}] contains [{urlPart}]");

                    return true;
                }

                ERH.SetStepStatusWarning($"Page Title [{drv.Url}] does not contains [{urlPart}]");

                return false;

            });
        }
    }
}
