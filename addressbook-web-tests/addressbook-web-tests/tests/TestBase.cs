using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
   public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            //driver = new FirefoxDriver();
            //baseURL = "http://localhost/addressbook";
            //verificationErrors = new StringBuilder();

            //loginHelper = new LoginHelper(driver);
            //navigator = new NavigationHelper(driver,baseURL);
            //groupHelper = new GroupHelper(driver);

            app = new ApplicationManager();
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }
             
      
    }
}
