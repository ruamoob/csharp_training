using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests:TestBase
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

       
        [Test]
        public void ContactCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            InitContactCreation();
            ContactData contact = new ContactData("Тихон", "Тихонов");
            contact.MiddleName = "Тихонович";
            contact.NickName = "Nick";
            contact.Title = "СС";
            contact.Company = "НПО Мир";
            contact.Address = "ул.Успешная";
            contact.Home = "51";
            contact.Mobile = "8905922";
            contact.Work = "888";
            contact.Fax = "999";
            contact.Email = "qqq@yandex.ru";
            contact.Email2 = "qqq2@yandex.ru";
            contact.Email3 = "qqq3@yandex.ru";
            contact.Homepage = "22";
            contact.Bday = "1";
            contact.Bmonth = "January";
            contact.Byear = "2000";
            contact.Aday = "2";
            contact.Amonth = "February";
            contact.Ayear = "2020";
            contact.Address2 = "ул.Успешная 52";
            contact.Phone2 = "777";
            contact.Notes = "Big notes";
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToContactsPage();
        }
    
   
    }
}