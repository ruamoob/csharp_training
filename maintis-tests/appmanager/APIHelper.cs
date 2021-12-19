﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;

namespace maintis_tests
{
   public  class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            //Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient("MantisConnectPort", "http://localhost/mantisbt-2.25.2/api/soap/mantisconnect.php?WSDL");
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_add(account.Name, account.Password, issue);
        }

        public List<ProjectData> GetProjectsList(AccountData account)
        {
           // Maintis.MantisConnectPortTypeClient client = new Maintis.MantisConnectPortTypeClient();
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient("MantisConnectPort", "http://localhost/mantisbt-2.25.2/api/soap/mantisconnect.php?WSDL");
            Mantis.ProjectData[] projects = client.mc_projects_get_user_accessible(account.Name, account.Password);
            List<ProjectData> list = new List<ProjectData>();
            foreach (Mantis.ProjectData project in projects)
            {
                list.Add(new ProjectData(project.name));
            }
            return list;
        }
        public void CreateProjectNotExist(AccountData account, ProjectData projectData)
        {
            if (GetProjectsList(account).Count() == 0)
            {
                Create(account, projectData);
            }
        }

        public void Create(AccountData account, ProjectData projectData)
        {
            //Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient("MantisConnectPort", "http://localhost/mantisbt-2.25.2/api/soap/mantisconnect.php?WSDL");
            Mantis.ProjectData project = new Mantis.ProjectData();
            project.name = projectData.Name;
            client.mc_project_add(account.Name, account.Password, project);
        }
    }
}
