using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace maintis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;

        protected string baseURL;
        protected const string baseUrl = "http://localhost/mantisbt-2.25.2/";
        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get; set; }
        public JamesHelper James { get;  set; }
        public MailHelper Mail { get; set; }
        public AdminHelper Admin { get; set; }
        public APIHelper API { get; set; }
        public LoginHelper Auth { get; set; }
        public ManagementMenuHelper Navigator { get; set; }
        public ProjectManagementHelper Projects { get; set; }


        private static ThreadLocal<ApplicationManager> app= new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {

            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            baseURL = "http://localhost/mantisbt-2.25.2";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);
            Admin = new AdminHelper(this,baseUrl);
            API = new APIHelper(this);

            Auth = new LoginHelper(this);
            Navigator = new ManagementMenuHelper(this, baseURL);
            Projects = new ProjectManagementHelper(this);

        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {

                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url =baseUrl+ "/login_page.php";
               // newInstance.driver.Url = baseUrl;
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }

        }
    }
}
