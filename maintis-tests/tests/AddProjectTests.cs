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
                ProjectData project = new ProjectData("AddTest");
                List<ProjectData> oldProjects = app.Projects.GetProjectsList();
                app.Projects.Create(project);

                Assert.AreEqual(oldProjects.Count + 1, app.Projects.GetProjectsCount());

                List<ProjectData> newProjects = app.Projects.GetProjectsList();
                oldProjects.Add(project);
                oldProjects.Sort();
                newProjects.Sort();
                Assert.AreEqual(oldProjects, newProjects);
            }
        }

}
