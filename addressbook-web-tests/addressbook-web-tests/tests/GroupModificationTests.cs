using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests: GroupTestBase
    {
        //Через UI
        //[Test]
        //public void GroupModificationTest()
        //{
        ////Проверка на наличие хотя бы одной записи в таблице
        //    app.Groups.NullElement();

        //    GroupData newData = new GroupData("aa2");
        //    newData.Header = "bbbb";
        //    newData.Footer ="cccc";

        //    List<GroupData> oldGroups = app.Groups.GetGroupList();
        //    GroupData oldData = oldGroups[0];

        //    app.Groups.Modify(0, newData);

        //    Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

        //    List<GroupData> newGroups = app.Groups.GetGroupList();
        //    oldGroups[0].Name = newData.Name;
        //    oldGroups.Sort();
        //    newGroups.Sort();
        //    Assert.AreEqual(oldGroups, newGroups);

        //    foreach (GroupData group in newGroups)
        //    {
        //        if (group.Id == oldData.Id)
        //        {
        //            Assert.AreEqual(newData.Name, group.Name);
        //        }
        //    }

        //}


        //Через БД
        [Test]
        public void GroupModificationTestDB()
        {
            //Проверка на наличие хотя бы одной записи в таблице
            GroupData newData = new GroupData("aa2");
            newData.Header = "bbbb";
            newData.Footer = "cccc";

            app.Groups.NullElement();

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeModifyed = oldGroups[0];

            app.Groups.ModifyId(toBeModifyed, newData);

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }

    }
}
