using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace maintis_tests
{
  public  class ManagementMenuHelper : HelperBase
    {
        private string baseURL;

        public ManagementMenuHelper(ApplicationManager manager, string baseURL)
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void GoToHomePage()
        {
            if (driver.Url == baseURL)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }

        public void GoToProjectsPage()
        {
            if (driver.Url == (baseURL + "manage_proj_page.php")
                && IsElementPresent(By.XPath("//button[@type='submit']")))
            {
                return;
            }

            driver.FindElement(By.XPath("//li/a/span[contains(text(),'Управление')]")).Click();           
            driver.FindElement(By.LinkText("Управление проектами")).Click();

            // driver.FindElement(By.ClassName("fa fa-gears menu-icon")).Click();
            // driver.FindElement(By.XPath("//i[@class='fa fa-gears menu - icon']")).Click(); 
        }

    }
}
