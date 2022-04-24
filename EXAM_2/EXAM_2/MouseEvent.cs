using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EXAM_2
{
    internal class MouseEvent
    {
        private static IWebDriver driver;
        public void start(bool v)
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.way2automation.com/way2auto_jquery/draggable.php#load_box");
            driver.Manage().Window.Maximize();

            testDefaultMode();
        }

        private void testDefaultMode()
        {
            driver.SwitchTo().Frame(0);

            Thread.Sleep(1000);

            IWebElement cursor = driver.FindElement(By.XPath("//div[@id='draggable']"));

            Actions actions = new Actions(driver);

            actions.DragAndDropToOffset(cursor, 150, 0);
            Thread.Sleep(1000);
            actions.DragAndDropToOffset(cursor, 0, 150);
            Thread.Sleep(1000);
            actions.DragAndDropToOffset(cursor, -150, 0);
            Thread.Sleep(1000);
            actions.DragAndDropToOffset(cursor, 0, -150);
            Thread.Sleep(1000);

            actions.Build().Perform();
        }
    }
}
