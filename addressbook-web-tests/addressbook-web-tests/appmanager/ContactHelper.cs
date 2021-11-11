using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.CssSelector("td:nth-child(1)")).Count;
        }

        public ContactHelper NullElement()
        {
            if (IsElementPresent(By.Name("selected[]")))
           {
             return this;
           }
            else
            {
               Create(new ContactData("Тихонов", "Иван"));
               return this;

           }
        }
        public ContactHelper Modify(int p, ContactData newData)
        {
            manager.Navigator.GoToContactsPage();                    
            InitContactModification(p);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToContactsPage();
            return this;
        }

        public ContactHelper Remove(int p)
        {
            manager.Navigator.GoToContactsPage();
            SelectContact(p);
            RemoveContact();
            ReturnToContactsPage();
            return this;
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToContactsPage();
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToContactsPage();
            return this;
        }
        public ContactHelper RemoveContact()
        {            
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            driver.SwitchTo().Alert().Accept();          
            return this;
        }
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            int index_edit = index + 2;
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index_edit + "]/td[8]/a/img")).Click();
            return this;
        }
        public ContactHelper SelectContact(int index)
        {
            int index_checkbox = index + 2;
            driver.FindElement(By.XPath("/ html / body / div / div[4] / form[2] / table / tbody / tr[" + index_checkbox + "] / td[1] / input")).Click();
            return this;
        }
        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToContactsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("td:nth-child(1)"));
                
                foreach (IWebElement element in elements)
                {

                //int index = element.GetEnumerator();
                    //string lastName = element.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index + "]/td[2]")).Text;
                    // string firstName = element.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index + "]/td[3]")).Text;


                    //string lastName = element.FindElement(By.TagName("input")).GetAttribute("alt");
                    //string firstName = element.FindElement(By.TagName("input")).GetAttribute("alt");

                    string firstName= element.FindElement(By.CssSelector("td:nth-child(3)")).Text;
                    string lastName = element.FindElement(By.CssSelector("td:nth-child(2)")).Text;

                    contactCache.Add(new ContactData(firstName, lastName)
                        {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                        });

                }
            }
            return new List<ContactData>(contactCache);
        }

     

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("middlename"), contact.MiddleName);
            Type(By.Name("nickname"), contact.NickName);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.Work);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            Type(By.Name("ayear"), contact.Ayear);
           // TypeByText(By.Name("amonth"), contact.Amonth);
           // TypeByText(By.Name("aday"), contact.Aday);
            Type(By.Name("byear"), contact.Byear);
           // TypeByText(By.Name("bmonth"), contact.Bmonth);
          //  TypeByText(By.Name("bday"), contact.Bday);
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Enter']")).Click();
            contactCache = null;
            return this;
        }
        public ContactHelper ReturnToContactsPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }
    }
}
