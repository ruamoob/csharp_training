﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace maintis_tests
{
    public  class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager) { }

        internal void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();
  
            //String url = GetConfirmationUrl(account);
            //FillPasswordForm(url, account);
            //SubmitPasswordForm();
        }

        private void OpenRegistrationForm()
        {
            driver.FindElement(By.CssSelector("a.back-to-login-link")).Click();

        }

        private void SubmitRegistration()
        {
           // driver.FindElement(By.CssSelector("input.button")).Click();
            driver.FindElement(By.CssSelector("input.width-40")).Click();
        }

        private void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }

        private void OpenMainPage()
        {
           manager.Driver.Url = "http://localhost/mantisbt-2.25.2/login_page.php";
        }
    }
}
