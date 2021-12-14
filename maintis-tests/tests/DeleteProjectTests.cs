using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace maintis_tests
{
    [TestFixture]
    public class DeleteProjectTests : AuthTestBase
    {
        [Test]
        public void DeleteProjectTest()
        {          
            app.Projects.CreateProjectNotExist(new ProjectData("123456"));

            List<ProjectData> oldProjects = app.Projects.GetProjectsList();
            ProjectData toBeRemoved = oldProjects[0];
            app.Projects.Remove(toBeRemoved);

            Assert.AreEqual(oldProjects.Count - 1, app.Projects.GetProjectsCount());

            List<ProjectData> newProjects = app.Projects.GetProjectsList();
            oldProjects.RemoveAt(0);
            Assert.AreEqual(oldProjects, newProjects);

            foreach (ProjectData project in newProjects)
            {
                Assert.AreNotEqual(project.Name, toBeRemoved.Name);
            }
        }
    }
}
