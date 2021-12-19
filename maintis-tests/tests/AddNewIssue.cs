using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Reflection;
using System.IO;


namespace maintis_tests
{
    [TestFixture]
    public class AddNewIssue
    {
        [TestFixture]
        public class AddNewIssueTests : TestBase
        {
            [Test]
            public void AddNewIssue()
            {
                AccountData account = new AccountData()
                {
                    Name = "administrator",
                    Password = "root"
                };

                //ProjectData project = new ProjectData()
                //{  Id = "1"  };

                ProjectData project = new ProjectData("1");

                IssueData issue = new IssueData()
                {
                    Summary = "some short text",
                    Description = "some long text",
                    Category = "General"
                };

                app.API.CreateNewIssue(account, project, issue);

            }
        }
    }
} 
