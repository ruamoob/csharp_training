using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_white
{
    [TestFixture]
    public class GroupRemovingTests : TestBase
    {
        [Test]
        public void TestGroupRemoving()
        {
            if (app.Groups.GetGroupList().Count <=1)
            {
                GroupData newGroup = new GroupData()
                {
                    Name = "white_new"
                };
                app.Groups.Add(newGroup);
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove();
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Remove(oldGroups[0]);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
