using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

namespace maintis_tests
{

    [TestFixture]
    public class AccountCreationsTests : TestBase
    {
        [TestFixtureSetUp]
        public void setUpConfig()
            {
            app.Ftp.BackupFile("/config_inc.php");
            using (Stream localFile = File.Open("config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config_inc.php", localFile);
            }
         
        }

        [Test]
        public void TesAccountRegistration()
        {

            AccountData account = new AccountData()
            {
                Name = "testuser5",
                Password = "password",
                Email = "testuser5@localhost.localdomain"
            };

            List<AccountData> accounts = app.Admin.GetAllAccounts();
            AccountData ExistingAccount= accounts.Find(x => x.Name == account.Name);

            if (ExistingAccount != null)
            {
                app.Admin.DeleteAccount(ExistingAccount);
            }
          
            //app.James.Delete(account);
            //app.James.Add(account);
            app.Registration.Register(account);
        }

        [TestFixtureTearDown]
        public void restoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config_inc.php");
        }


    }  
}
