using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.IO;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {

        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            //ContactData contact = new ContactData("Тихонов", "Семен");
            //contact.MiddleName = "Тихонович";
            //contact.NickName = "Nick";
            //contact.Title = "СС";
            //contact.Company = "НПО Мир";
            //contact.Address = "ул.Успешная";
            //contact.Home = "51";
            //contact.Mobile = "8905922";
            //contact.Work = "888";
            //contact.Fax = "999";
            //contact.Email = "qqq@yandex.ru";
            //contact.Email2 = "qqq2@yandex.ru";
            //contact.Email3 = "qqq3@yandex.ru";
            //contact.Homepage = "22";
            //contact.Bday = "1";
            //contact.Bmonth = "January";
            //contact.Byear = "2000";
            //contact.Aday = "2";
            //contact.Amonth = "February";
            //contact.Ayear = "2020";
            //contact.Address2 = "ул.Успешная 52";
            //contact.Phone2 = "777";
            //contact.Notes = "Big notes";
            // List<ContactData> oldContacts = app.Contacts.GetContactList();

            List<ContactData> contacts = new List<ContactData>();

            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    MiddleName = GenerateRandomString(30),
                    Notes = GenerateRandomString(30),
                    Address = GenerateRandomString(30),
                    Home = GenerateRandomString(20),
                    Mobile = GenerateRandomString(20),
                    Work = GenerateRandomString(20),
                    Fax = GenerateRandomString(20)
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)
                 new XmlSerializer(typeof(List<ContactData>))
                 .Deserialize(new StreamReader(@"contact.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contact.json"));
        }

         [Test, TestCaseSource("RandomContactDataProvider")]       
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test, TestCaseSource("ContactDataFromXmlFile")]
        public void ContactCreationTestXml(ContactData contact)
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void ContactCreationTestJson(ContactData contact)
        {
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