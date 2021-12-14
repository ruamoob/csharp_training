using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace maintis_tests
{
   public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager)
                  : base(manager)
        {
        }
        public ProjectManagementHelper Create(ProjectData project)
        {
            manager.Navigator.GoToProjectsPage();
            InitProjectCreation();
            FillProjectForm(project);
            SubmitProjectCreation();
            ReturnToProjectsPage();
            return this;
        }

        public ProjectManagementHelper CreateProjectNotExist(ProjectData newData)
        {
            manager.Navigator.GoToProjectsPage();
 
            if  (GetProjectsCount()<1)
            {
                Create(newData);
            }
            return this;
        }
 
       
        public ProjectManagementHelper Remove(ProjectData project)
        {
            manager.Navigator.GoToProjectsPage();
            SelectProject(project.Name);
            RemoveProject();
            return this;
        }

        public ProjectManagementHelper ReturnToProjectsPage()
        {
            driver.FindElement(By.LinkText("Продолжить")).Click();
            return this;
        }

        public ProjectManagementHelper SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
            projectCache = null;
            return this;
        }

        public ProjectManagementHelper FillProjectForm(ProjectData project)
        {
            Type(By.Id("project-name"), project.Name);
            return this;
        }

        public ProjectManagementHelper InitProjectCreation()
        {
            // Создать новый проект
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            return this;
        }

        public ProjectManagementHelper RemoveProject()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            projectCache = null;
            return this;
        }

        public ProjectManagementHelper SelectProject(String name)
        {
            driver.FindElement(By.XPath("(//a[contains(text(),'" + name + "')])[2]")).Click();
            return this;
        }

        private List<ProjectData> projectCache = null;

        public List<ProjectData> GetProjectsList()
        {
            if (projectCache == null)
            {
                projectCache = new List<ProjectData>();
                manager.Navigator.GoToProjectsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr/td/a"));
                foreach (IWebElement element in elements)
                {
                    projectCache.Add(new ProjectData(element.Text));
                }
            }
            return new List<ProjectData>(projectCache);
        }

        public int GetProjectsCount()
        {
            return driver.FindElements(By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr")).Count;
        }

    }
}
