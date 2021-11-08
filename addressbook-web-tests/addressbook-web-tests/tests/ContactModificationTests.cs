using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests: AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Тихон2", "Тихонов2");
            newData.MiddleName = "Тихонович2";
            newData.NickName = "Nick2";
            newData.Title = "СС2";
            newData.Company = "НПО Мир2";
            newData.Address = "ул.Успешная2";
            newData.Home = "51/2";
            newData.Mobile = "8905922222";
            newData.Work = "88822";
            newData.Fax = "99922";
            newData.Email = "qqq22@yandex.ru";
            newData.Email2 = "qqq222@yandex.ru";
            newData.Email3 = "qqq333@yandex.ru";
            newData.Homepage = "2222";
            newData.Bday = "12";
            newData.Bmonth = "January";
            newData.Byear = "2000";
            newData.Aday = "22";
            newData.Amonth = "February";
            newData.Ayear = "2020";
            newData.Address2 = "ул.Успешная 52/2";
            newData.Phone2 = "77722";
            newData.Notes = "Big notes2";

           // List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(0, newData);

            //List<ContactData> newContacts = app.Contacts.GetContactList();
            //oldContacts[0].LastName = newData.LastName;
            //oldContacts.Sort();
            //newContacts.Sort();
            //Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
