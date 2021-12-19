using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace maintis_tests
{
        [TestFixture]
        public class AddProjectTests : AuthTestBase
        {
            [Test]
            public void AddProjectTest()
            {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

                ProjectData project = new ProjectData("AddTest "+ DateTime.Now.ToString("hh:mm:ss"));

                List<ProjectData> oldProjects = app.API.GetProjectsList(account);
                app.API.Create(account, project);


                Assert.AreEqual(oldProjects.Count + 1, app.Projects.GetProjectsCount());

               //List<ProjectData> newProjects = app.Projects.GetProjectsList();
               List<ProjectData> newProjects = app.API.GetProjectsList(account);

                oldProjects.Add(project);
                oldProjects.Sort();
                newProjects.Sort();
                Assert.AreEqual(oldProjects, newProjects);
            }
        }

}
