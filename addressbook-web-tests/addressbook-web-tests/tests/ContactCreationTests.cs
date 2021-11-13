﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests: AuthTestBase
    {
     
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Тихонов", "Семен");
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


            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }
    
   
    }
}