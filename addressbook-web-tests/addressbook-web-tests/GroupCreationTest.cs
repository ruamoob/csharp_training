using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests: TestBase
    {
       
        [Test]
        public void GroupCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin","secret"));
            GotoGroupsPage();
            InitGroupsCreation();
            GroupData group = new GroupData("aa");
            group.Header = "bb";
            group.Footer = "cc";
            //FillGroupForm(new GroupData("aa", "bb", "cc"));
            SubmitGroupCreation();
            ReturnToGroupsPage();
        }
  

    }
}

