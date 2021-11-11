using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests: AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
        //Проверка на наличие хотя бы одной записи в таблице
            app.Contacts.NullElement();
         
            //List<ContactData> oldContacts = app.Contacts.GetContactList();
            //ContactData toBeRemoved = oldContacts[0];

            app.Contacts.Remove(0);

            //Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            //List<ContactData> newContacts = app.Contacts.GetContactList();

            //oldContacts.RemoveAt(0);
            //Assert.AreEqual(oldContacts, newContacts);

            //foreach (ContactData contact in newContacts)
            //{
            //    Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            //}
        }

        private bool IsElementPresent(By by)
        {
            throw new NotImplementedException();
        }
    }
}
