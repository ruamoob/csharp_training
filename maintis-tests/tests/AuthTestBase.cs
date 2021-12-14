using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace maintis_tests
{
    public class AuthTestBase:TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
           //app.Auth.Login(new AccountData("admin", "secret"));
            app.Auth.Login(new AccountData
            {
                Name = "administrator",
                Password = "root"
            });

        }
    }
}
