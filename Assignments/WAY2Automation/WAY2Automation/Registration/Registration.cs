using OpenQA.Selenium;
using System;
using SeleniumBase;

namespace WAY2Automation
{
    internal class Registration : SelActions
    {
        public void start()
        {

            open("https://www.way2automation.com/way2auto_jquery/registration.php#load_box");

            sendName("Pratim");
            sendTitle("Majumder");
            sendMaritalStatus(0);
            sendHobbies();
            selectCountry("India");
            selectDate(1, 1, 2014);
            setPhone("+9103214911100");
            setUserName("tictactoe");
            setEmail("joe@gmail.com");
            setProfilePic();
            setAbout();
            setPassAndConfirmPass("demopass");
            //  submit();

            exit();
        }

        private void submit()
        {
            FindXPath("//input[@type='submit' and @value='submit']").Click();
        }

        private void setProfilePic()
        {
            FindXPath("//fieldset//input[@type='file']")
                .SendKeys("C:\\Users\\" + Environment.UserName + "\\Desktop\\download.png");
        }

        private void setPassAndConfirmPass(string v)
        {
            FindXPath("//fieldset[@class='fieldset']//input[@name='password']").SendKeys(v);

            FindXPath("//fieldset[@class='fieldset']//input[@name='c_password']").SendKeys(v);
        }

        private void setAbout()
        {
            FindXPath("//fieldset//textarea").SendKeys("I'm a student not studying rn.");
        }

        private void setUserName(string v)
        {
            FindXPath("//fieldset[@class='fieldset']//input[@name='username']").SendKeys(v);
        }

        private void setEmail(string v)
        {
            FindXPath("//fieldset[@class='fieldset']//input[@name='email']").SendKeys(v);
        }

        private void setPhone(string v)
        {
            FindXPath("//fieldset[@class='fieldset']//input[@name='phone']").SendKeys(v);
        }

        private void selectDate(int d, int m, int y)
        {
            var date_fields = FindAllBy(By.XPath("//div[@class='time_feild']//select"));

            date_fields[0].Click();
            wait(500);

            switchToActive();

            wait(500);

            var date_fields_total = date_fields[0].FindElements(By.XPath("//option"));
            foreach (IWebElement element in date_fields_total)
            {
                if (element.Text.Equals(d + ""))
                {
                    element.Click();
                    break;
                }
            }

            date_fields[1].Click();
            wait(500);

            switchToActive();

            wait(500);

            var month_fields_total = date_fields[1].FindElements(By.XPath("//option"));
            foreach (IWebElement element in month_fields_total)
            {
                if (element.Text.Trim().Equals(m + ""))
                {
                    element.Click();
                    break;
                }
            }

            date_fields[2].Click();
            wait(500);

            switchToActive();   

            wait(500);

            var year_fields_total = date_fields[0].FindElements(By.XPath("//option"));
            foreach (IWebElement element in year_fields_total)
            {
                if (element.Text.Equals(y + ""))
                {
                    element.Click();
                    break;
                }
            }

            switchToActive().Click();
        }

        private void selectCountry(string v)
        {
            FindXPath("//fieldset//descendant::label[text()='Country:']//following-sibling::select[@name and @id]").Click();

            wait(1000);

            switchToActive();

            var india_sel = FindAllBy(By.XPath("//fieldset//descendant::label[text()='Country:']//following-sibling::select[@name and @id]//option"));
            foreach (IWebElement element in india_sel)
            {
                if (element.Text.Trim().Equals(v))
                {
                    element.Click();
                    break;
                }
            }

            switchToActive().Click();
        }

        private void sendHobbies()
        {
            var elements = FindAllBy(By.XPath("//label[text()='Hobby:']//following::div[@class='radio_wrap']//descendant::input"));
            elements[1].Click();
            elements[2].Click();
        }

        private void sendName(string name)
        {
            FindXPath("//fieldset[@class='fieldset']//descendant::input[@name='name']").SendKeys(name);
        }

        private void sendTitle(string title)
        {
            FindAllBy(By.XPath("//fieldset[@class='fieldset']//descendant::input[@name='name']//following::input[@type='text']"))[0].SendKeys(title);
        }

        private void sendMaritalStatus(int v)
        {
            FindAllBy(By.XPath("//input[@name='m_status']"))[v].Click();
        }

    }
}
