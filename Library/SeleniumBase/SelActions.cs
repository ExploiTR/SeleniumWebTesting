using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading;

namespace SeleniumBase
{
    public class SelActions : IDriverComponents, IElementOperations, IControlFunctions,
        IActionComponents, IConditions, IByWrapper, IJavaScriptComponents
    {
        private IWebDriver driver = null;
        private IWebDriver lastInstance = null;
        private Actions instance = null;
        private void init()
        {
            if (driver == null)
                driver = new ChromeDriver();
        }

        private void init(ChromeOptions options)
        {
            if (driver == null)
                driver = new ChromeDriver(options);
        }

        private void initNewWindow()
        {
            if (driver == null)
                driver = new ChromeDriver();
            else
            {
                lastInstance = driver;
                driver = new ChromeDriver();
            }
        }


        public void setDriver(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebDriver getDriver()
        {
            return driver;
        }

        public void open(string link)
        {
            init();

            DriverConfig config = DriverConfig.Default();

            if (config.FullScreen)
            {
                driver.Manage().Window.FullScreen();
            }
            if (config.Maximize)
            {
                driver.Manage().Window.Maximize();
            }
            driver.Navigate().GoToUrl(link);
        }

        public void open(string link, DriverConfig config)
        {
            init(config.ChromeOptions);
            driver.Navigate().GoToUrl(link);
        }

        public void openWindow(string link)
        {
            initNewWindow();
            driver.Navigate().GoToUrl(link);
        }
        public void refresh()
        {
            driver.Navigate().Refresh();
        }
        public void switchBackToPreviousDriver()
        {
            if (driver != null)
                driver.Quit();
            driver = lastInstance;
        }

        public void close()
        {
            wait(1000);
            if (driver != null)
                driver.Close();
            if (lastInstance != null)
                lastInstance.Close();
        }

        public void exit()
        {
            wait(2000);
            if (driver != null)
                driver.Quit();
            if (lastInstance != null)
                lastInstance.Quit();
        }

        public void exitPrompt()
        {
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            if (driver != null)
                driver.Quit();
            if (lastInstance != null)
                lastInstance.Quit();
        }

        public void click(By by)
        {
            driver.FindElement(by).Click();
        }

        public void click(IWebElement by)
        {
            by.Click();
        }

        public void sendKeys(By by, string key)
        {
            driver.FindElement(by).SendKeys(key);
        }

        public void sendKeys(IWebElement by, string key)
        {
            by.SendKeys(key);
        }

        public IWebElement switchToActive()
        {
            return driver.SwitchTo().ActiveElement();
        }

        public void switchToDefault()
        {
            driver.SwitchTo().DefaultContent();
        }

        public IAlert switchToAlert()
        {
            return driver.SwitchTo().Alert();
        }

        public IWebDriver switchToParentFrame()
        {
            return driver.SwitchTo().ParentFrame();
        }

        public IWebDriver switchToFrame(int index)
        {
            return driver.SwitchTo().Frame(index);
        }

        public void switchToWindow(int index)
        {
            driver.SwitchTo().Window(driver.WindowHandles[index]);
        }

        public IWebElement FindID(string id)
        {
            return driver.FindElement(By.Id(id));
        }
        public IWebElement FindXPath(string xpath)
        {
            return driver.FindElement(By.XPath(xpath));
        }
        public IWebElement FindName(string name)
        {
            return driver.FindElement(By.Name(name));
        }
        public IWebElement FindCSS(string css)
        {
            return driver.FindElement(By.CssSelector(css));
        }

        public IWebElement FindText(string tag, string text)
        {
            return driver.FindElement(By.XPath("//" + tag + "[contains(text(),'" + text + "') or text()='" + text + "']"));
        }

        public IWebElement FindTag(string id)
        {
            return driver.FindElement(By.TagName(id));
        }
        public IWebElement FindClass(string class_)
        {
            return driver.FindElement(By.ClassName(class_));
        }
        public IWebElement FindLinkText(string tlink)
        {
            return driver.FindElement(By.LinkText(tlink));
        }
        public IWebElement FindPartialLinkText(string plt)
        {
            return driver.FindElement(By.PartialLinkText(plt));
        }

        public IWebElement FindWithInElement(By by, IWebElement element)
        {
            return element.FindElement(by);
        }

        public bool textEquals(By by, string verification)
        {
            try
            {
                return driver.FindElement(by).Text.Equals(verification);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool textEquals(IWebElement element, string verification)
        {
            try
            {
                return element.Text.Equals(verification);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool elementExists(By by)
        {
            try
            {
                var x = driver.FindElement(by);
                return x.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string getAttribute(IWebElement element, string attr)
        {
            return element.GetAttribute(attr);
        }

        public string getAttributeXpath(string Xpath, string attr)
        {
            return FindXPath(Xpath).GetAttribute(attr);
        }

        public void wait(int time)
        {
            Thread.Sleep(time);
        }

        public void wait_5()
        {
            wait(500);
        }

        public void execScript(string script, params object[] args)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript(script, args);
        }

        public void clickByJS(IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
        }

        public void scrollPage(int hz, int ver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(" + hz + ", " + ver + ")");
        }

        public void clickWithAction(IWebElement element)
        {
            getAction().Click(element).Perform();
        }

        public void doubleClick(IWebElement element)
        {
            getAction().DoubleClick(element).Perform();
        }

        public void contextClick(IWebElement element)
        {
            getAction().ContextClick(element).Perform();
        }

        public void testHorizontalMovement(IWebElement element, int minPX, int maxPX)
        {
            getAction().MoveToElement(element)
                .ClickAndHold()
                .MoveByOffset(minPX, 0)
                .MoveByOffset(maxPX, 0)
                .Release()
                .Build()
                .Perform();
        }

        public void testVerticalMovement(IWebElement element, int minPY, int maxPY)
        {
            getAction().MoveToElement(element)
                .ClickAndHold()
                .MoveByOffset(0, minPY)
                .MoveByOffset(0, maxPY)
                .Release()
                .Build()
                .Perform();
        }

        public void squareMovement(IWebElement element, int minPX, int maxPX, int minPY, int maxPY)
        {
            getAction().MoveToElement(element)
                .ClickAndHold()
                .MoveByOffset(maxPX, minPY)
                .MoveByOffset(maxPX, maxPY)
                .MoveByOffset(minPX, maxPY)
                .MoveByOffset(minPX, minPY)
                .Release()
                .Build()
                .Perform();
        }

        public void dragAndDrop(IWebElement movable, IWebElement container)
        {
            getAction().DragAndDrop(movable, container).Perform();
        }

        public void dragAndDropOffset(IWebElement movable, int offX, int offY)
        {
            getAction().DragAndDropToOffset(movable, offX, offY).Perform();
        }

        public void sendKeysWithAction(string key)
        {
            getAction().SendKeys(key).Perform();
        }

        public Actions getAction()
        {
            return (instance = new Actions(driver));
        }

        public void PressKeys(IWebElement element, string key)
        {
            getAction().KeyDown(element, key).Perform();
        }

        public void releaseKeys(IWebElement element, string key)
        {
            getAction().KeyUp(element, key).Perform();
        }

        public void keyStroke(IWebElement element, string key)
        {
            getAction()
                .KeyDown(element, key)
                .KeyUp(element, key)
                .Build()
                .Perform();
        }

        public void scrollForElementVisibility(IWebElement element)
        {
            do
            {
                scrollPage(0, 10);
            } while (!element.Displayed || !element.Enabled);
        }

        public ReadOnlyCollection<IWebElement> FindAllBy(By by)
        {
            return driver.FindElements(by);
        }

        public void recordScreen()
        {
            throw new NotImplementedException();
        }

        public void takeScreenShot()
        {
            throw new NotImplementedException();
        }

        public void takeScreenShot(IWebElement webElement)
        {
            throw new NotImplementedException();
        }

        public void stopScreenRecord()
        {
            throw new NotImplementedException();
        }

        public void clear(IWebElement element)
        {
            element.Clear();
            /*  wait(100);
              if (element.Text.Length > 0)
              {
                  string key = Keys.Backspace;
                  for (int i = 0; i < element.Text.Length; i++)
                  {
                      key += Keys.Backspace;
                  }
                  getAction().SendKeys(key);
              }*/

            //test prototype
        }

        public void clearAndSendKeys(IWebElement element, string key)
        {
            clear(element);
            sendKeys(element, key);
        }

        public void clearAndSendKeys(By by, string key)
        {
            var element = driver.FindElement(by);
            clear(element);
            sendKeys(element, key);
        }

        public void acceptAlert()
        {
            switchToAlert().Accept();
        }

        public void rejectAlert()
        {
            switchToAlert().Dismiss();
        }

        public void sendKeysToAlert(string keys)
        {
            switchToAlert().SendKeys(keys);
        }

        public bool testForValidLink(string link)
        {
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(link);
                webRequest.Timeout = 2500;
                webRequest.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

                return response.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool testForValidImage(string link)
        {
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(link);
                webRequest.Timeout = 2500;
                webRequest.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

                return response.StatusCode == HttpStatusCode.OK && response.ContentLength > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Actions moveToElementAndClick(IWebElement webElement)
        {
            if (instance == null)
                throw new NullReferenceException("Action instance is null");
            return instance.MoveToElement(webElement).Click();
        }

        public void hoverOnto(IWebElement webElement)
        {
            getAction().MoveToElement(webElement).Perform();
        }

        public void wait1s()
        {
            wait(1000);
        }

        public void wait2s()
        {
            wait(2000);
        }

        public void wait3s()
        {
            wait(3000);
        }

        public void wait5s()
        {
            wait(5000);
        }

        public void clickAndThenSendKeys(IWebElement element, string combo)
        {
            element.Click();
            wait_5();
            element.SendKeys(combo);
        }

        public IWebElement FindTextTagless(string text)
        {
            return FindText("*", text);
        }

        public void controlClick(IWebElement element)
        {
            getAction()
                .KeyDown(Keys.LeftControl)
                .Click(element)
                .KeyUp(Keys.LeftControl)
                .Release()
                .Build()
                .Perform();
        }

        public IWebElement FindClassesTagLess(string className)
        {
            return FindXPath("//*[@class='" + className + "']");
        }

        public void hoverOntoJS(IWebElement webElement)
        {
            string mouseHoverScript = "if(document.createEvent){var evObj = document.createEvent('MouseEvents');evObj.initEvent('mouseover',true, false);" +
                " arguments[0].dispatchEvent(evObj);} else if(document.createEventObject) { arguments[0].fireEvent('onmouseover');}";

            execScript(mouseHoverScript, webElement);
        }

        public bool isImportantField(IWebElement element)
        {
            try
            {
                var x = element.FindElement(By.XPath("//*[text()='*']"));
                return x.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IWebElement FindTitleTagless(string title)
        {
            return FindXPath("//*[@title='" + title + "']");
        }

        public void waitForPageLoad()
        {
            wait_5();
            IWait<IWebDriver> wait = new WebDriverWait(getDriver(), TimeSpan.FromSeconds(30.00));
            wait.Until(driver1 => ((IJavaScriptExecutor)getDriver()).ExecuteScript("return document.readyState").Equals("complete"));
            wait_5();
            switchToActive();
        }

        public By ClassName(string classNameToFind)
        {
            return By.ClassName(classNameToFind);
        }

        public By CssSelector(string cssSelectorToFind)
        {
            return By.CssSelector(cssSelectorToFind);
        }

        public By Id(string idToFind)
        {
            return By.Id(idToFind);
        }

        public By LinkText(string linkTextToFind)
        {
            return By.LinkText(linkTextToFind);
        }

        public By Name(string nameToFind)
        {
            return By.Name(nameToFind);
        }

        public By PartialLinkText(string partialLinkTextToFind)
        {
            return By.PartialLinkText(partialLinkTextToFind);
        }

        public By TagName(string tagNameToFind)
        {
            return By.TagName(tagNameToFind);
        }

        public By XPath(string xpathToFind)
        {
            return By.XPath(xpathToFind);
        }

        public object execScriptRet(string script, params object[] args)
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript(script, args);
        }

        public string getTextJS(IWebElement element)
        {
            return ((string)execScriptRet("return arguments[0].textContent", element)).Trim();
        }

        public void navigateBack()
        {
            driver.Navigate().Back();
        }

        public void navigateForward()
        {
            driver.Navigate().Forward();
        }
    }
}
