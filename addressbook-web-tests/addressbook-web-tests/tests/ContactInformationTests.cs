using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            //verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }

        [Test]
        public void TestContactInformationDetails()
        {
            string fromDetails = app.Contacts.GetContactInformationFromDetails(0);
            ContactData fromEditForm = app.Contacts.GetContactInformationFromEditForm(0);

            //verification , приведение к верхнему регистру т.к. месяц в поле amonth на форме редактирования контакта
            //считывается в нижнем регистре, а на форме детальной информации amonth с заглавной буквы
            Assert.AreEqual(fromDetails.ToUpper(), fromEditForm.AllDetailContacts.ToUpper()); 

        }
    }
}
