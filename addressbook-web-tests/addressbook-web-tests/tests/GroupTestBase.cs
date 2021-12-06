﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class GroupTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareGroupsUiDb()
        {
        if (PERFORM_LONG_UI_CHECKS)
             {
                List<GroupData> fromUi = app.Groups.GetGroupList();
                List<GroupData> fromDb = GroupData.GetAll();
                fromUi.Sort();
                fromDb.Sort();
                Assert.AreEqual(fromUi, fromDb);
            }
        }
    }
}
