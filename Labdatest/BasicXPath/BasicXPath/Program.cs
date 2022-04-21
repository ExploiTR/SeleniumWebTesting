using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasicXPath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            basicXPath();
        }

        private static void basicXPath()
        {

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://accounts.lambdatest.com/register/");

            Thread.Sleep(1000);

            /* IWebElement name = driver.FindElement(By.XPath("//input[@name='name']"));
             name.SendKeys("Pratim Majumder");

             Thread.Sleep(1000);

             IWebElement email = driver.FindElement(By.XPath("//input[@name='email']"));
             email.SendKeys("pratimmajumder1@rediffmail.com");

             Thread.Sleep(1000);

             IWebElement password = driver.FindElement(By.XPath("//input[@name='password']"));
             password.SendKeys("demopass");

             Thread.Sleep(1000);

             IWebElement phone = driver.FindElement(By.XPath("//input[@name='phone']"));
             phone.SendKeys("9932616269");

             Thread.Sleep(1000);

             IWebElement org_name = driver.FindElement(By.XPath("//input[@name='org_name']"));
             org_name.SendKeys("None");

             Thread.Sleep(1000);

             IWebElement designation = driver.FindElement(By.XPath("//select[@name='designation']"));
             designation.Click();

             Thread.Sleep(1000);

             driver.SwitchTo().ActiveElement();

             IWebElement desg_sel = driver.FindElement(By.XPath("//option[contains(@value,'Tester')]"));
             desg_sel.Click();

             Thread.Sleep(1000);

             IWebElement checkBox = driver.FindElement(By.XPath("//samp[contains(@class,'customcheckbox')]"));
             checkBox.Click();

             Thread.Sleep(1000);

             containingXpath(driver);*/
            chainedXpath(driver);
        }

        private static void containingXpath(IWebDriver driver)
        {
            IWebElement submit = driver.FindElement(By.XPath("//button[contains(@type,'submit')]"));
            submit.Click();
        }

        private static void logicalXpath(IWebDriver driver)
        {
            IWebElement email_or = driver.FindElement(By.XPath("//input[@name='email' or contains(@placeholder,'Business')]"));
            email_or.SendKeys("pratimmajumder1@rediffmail.com");

            Thread.Sleep(1000);

            IWebElement email_and = driver.FindElement(By.XPath("//input[@name='email' and contains(@placeholder,'email')]"));
            email_and.SendKeys("pratimmajumder1@gfmail.com");

            Thread.Sleep(1000);

            IWebElement sign_in = driver.FindElement(By.XPath("//a[starts-with(text(),'Sign')]"));
            sign_in.Click();
        }

        private static void xpathText(IWebDriver driver)
        {
            IWebElement google_al = driver.FindElement(By.XPath("//span[contains(text(),'Sign up with Google')]"));
            google_al.Click();
        }

        private static void indeXpath(IWebDriver driver)
        {
            IWebElement designation = driver.FindElement(By.XPath("//select[@name='designation']"));
            designation.Click();

            Thread.Sleep(1000);

            driver.SwitchTo().ActiveElement();

            IWebElement design_s = driver.FindElement(By.XPath("(//select[@id='designation']//option)[5]"));

            design_s.Click();
        }

        private static void chainedXpath(IWebDriver driver)
        {
            IWebElement agree_label = driver.FindElement(By.XPath("//label[contains(@class,'i_agree')]"));
            IWebElement agree_check = agree_label.FindElement(By.XPath("//span//a[@data-amplitude='R_pp']"));

            agree_check.Click();
        }

        private static void accessMethod(IWebDriver driver)
        {

            //normal following
            IWebElement password = driver.FindElement(By.XPath("//input[@type='password']"));
            IWebElement phone = password.FindElement(By.XPath("//following::div//input[@name='phone']"));

            phone.SendKeys("1234");

            //just preceding
            IWebElement email = password.FindElement(By.XPath("//preceding::div//input[@name='email']"));

            phone.SendKeys("1234");

        }

        private static void sibling(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//select[@id='country_code']")).Click();
            Thread.Sleep(500);


            //next-item


            IWebElement indian_code = driver.FindElement(By.XPath("//option[@data-countrycode='IS']" +
                  "//following-sibling::option[1]"));

            indian_code.Click();


            //previous-item

            IWebElement green_code = driver.FindElement(By.XPath("//option[@data-countrycode='IS']//preceding-sibling::option[12]"));
            green_code.Click();

        }

        private static void child(IWebDriver driver)
        {
            IWebElement github_sign_up = driver.FindElement(By.XPath("//a[contains(@class,'googleSignInBtn')]" +
                "//span[contains(text(),'Github')]"));

            github_sign_up.Click();
        }

        private static void childToParentToSibling(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.XPath("//input[@type='email']//parent::div//following-sibling::div//input[@type='password']"));
            element.SendKeys("demopass");
        }

        private static void ancestorANDdecendent(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.XPath("//input[@name='password']//ancestor::div//descendant::div//span[text()='Show']"));
            element.Click();
        }


    }
}
