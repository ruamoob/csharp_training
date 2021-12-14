using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;


namespace maintis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }

                Logout();
            }
            Type(By.Name("username"), account.Name);
            driver.FindElement(By.XPath("//input[@name='username']")).Click();
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();

            Type(By.Name("password"), account.Password);    
            driver.FindElement(By.XPath("//input[@name='password']")).Click();
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.CssSelector("span.user-info")).Click();
                driver.FindElement(By.LinkText("Выход")).Click();
            }
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.ClassName("user-info"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggedUsername() == account.Name;
        }

        public string GetLoggedUsername()
        {
            string text = driver.FindElement(By.ClassName("user-info")).Text;
            return text;
        }
    }
}
