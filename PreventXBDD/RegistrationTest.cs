using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace PreventXBDD
{
    class RegistrationTest
    {

        public void StartApplication()
        {

            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://www.sh.uk/register");

                driver.FindElement(By.Name("ctl00$contentBody$txtFirstName")).SendKeys("testFirstName");
                driver.FindElement(By.Name("ctl00$contentBody$txtLastName")).SendKeys("testLastName");


            }

        }
    }
}
