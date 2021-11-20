using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToContactsPage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));

            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;
            

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails= allEmails,              
            };
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToContactsPage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        public string GetContactInformationFromDetails(int index)
        {
            manager.Navigator.GoToContactsPage();
            InitContactDetails(index);
            string content = driver.FindElement(By.Id("content")).Text;
            return Regex.Replace(content, "(H:|M:|W:|P:|F:|Homepage:|Birthday|Anniversary|nome|[ ()\r\n-])", ""); 
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToContactsPage();
            InitContactModification(index);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            string middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");

            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");

            string bday = driver.FindElement(By.Name("bday")).GetAttribute("value");
            string bmonth = driver.FindElement(By.Name("bmonth")).GetAttribute("value");
            string byear = driver.FindElement(By.Name("byear")).GetAttribute("value");

            string aday = driver.FindElement(By.Name("aday")).GetAttribute("value");
            string amonth = (driver.FindElement(By.Name("amonth")).GetAttribute("value")).ToUpper();
            string ayear = driver.FindElement(By.Name("ayear")).GetAttribute("value");

            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");            

            return new ContactData(firstName, lastName)
            {
                Address = address,
                Home = homePhone,
                Mobile = mobilePhone,
                Work = workPhone,
                Fax = fax,
                Phone2 = phone2,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                MiddleName = middlename,
                NickName= nickname,
                Title= title,
                Company= company,
                Homepage= homepage,
                Bday= bday,
                Bmonth= bmonth,
                Byear= byear,
                Aday= aday,
                Amonth= amonth,
                Ayear= ayear,
                Address2= address2,
                Notes= notes
            };
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.CssSelector("td:nth-child(1)")).Count;
        }

        public ContactHelper NullElement()
        {
            if (IsElementPresent(By.CssSelector("td:nth-child(1)")))
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
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            int index_edit = index + 2;
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index_edit + "]/td[8]/a/img")).Click();
            return this;
        }

        public ContactHelper InitContactDetails(int index)
        {
            int index_edit = index + 2;
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index_edit + "]/td[7]/a/img")).Click();
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
                manager.Navigator.GoToHomePage();
                //ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("td:nth-child(1)"));
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));

                foreach (IWebElement element in elements)
                {
                    //string lastName = element.FindElement(By.TagName("input")).GetAttribute("alt");
                    //string firstName = element.FindElement(By.TagName("input")).GetAttribute("alt");

                    //firstName = firstName.Remove(0, 8).Trim(new char[] { ')'}).Substring(0, firstName.IndexOf(" ")+1);                   
                    //lastName = lastName.Remove(0, lastName.LastIndexOf(" ")+1).Trim(new char[] { ')' });

                    string lastName = element.FindElement(By.CssSelector("td:nth-child(2)")).Text;
                    string firstName = element.FindElement(By.CssSelector("td:nth-child(3)")).Text;

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
