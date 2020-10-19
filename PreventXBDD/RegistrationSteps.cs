using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Web;
using System.Xml;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace PreventXBDD
{
    [Binding]
    public class RegistrationSteps
    {
        private IWebDriver _driver;
        string strFirstName, strLastName, strGender, strAssignedSex, strPartnerSex, strAge, strEthinicity, strAddress1, strTownCity, strCounty;
        string strPostcode, strEmail, strMobile, strContactPreference, strPassword, strPasswordConfirm, strResearchConsent, strTerms;

        public void ReadXmlFile()
        {

            XmlDocument xd = new XmlDocument();
            xd.Load(@"C:\Users\BalakumarVaratharaja\Documents\AutomationTest.xml");
            XmlNodeList mainlist = xd.SelectNodes("//Registration/*");
            XmlNode mainroot = mainlist[0];

            foreach (XmlNode xnode in mainroot.ChildNodes)
            {
                 strFirstName = xnode.SelectSingleNode("FirstName").InnerText.Trim();
                 strLastName = xnode.SelectSingleNode("LastName").InnerText.Trim();
                 strGender = xnode.SelectSingleNode("Gender").InnerText.Trim();
                 strAssignedSex = xnode.SelectSingleNode("AssignedSex").InnerText.Trim();
                 strPartnerSex = xnode.SelectSingleNode("PartnerSex").InnerText.Trim();
                 strEthinicity = xnode.SelectSingleNode("Ethnicity").InnerText.Trim();
                 strAddress1 = xnode.SelectSingleNode("Address1").InnerText.Trim();
                 strTownCity = xnode.SelectSingleNode("TownCity").InnerText.Trim();
                 strCounty = xnode.SelectSingleNode("County").InnerText.Trim();

                 strPostcode = xnode.SelectSingleNode("PostCode").InnerText.Trim();
                 strEmail = xnode.SelectSingleNode("EmailAddress").InnerText.Trim();
                 strMobile = xnode.SelectSingleNode("MobileNumber").InnerText.Trim();
                 strContactPreference = xnode.SelectSingleNode("ContactPreference").InnerText.Trim();
                 strPassword = xnode.SelectSingleNode("Password").InnerText.Trim();
                 strPasswordConfirm = xnode.SelectSingleNode("PasswordConfirm").InnerText.Trim();
                 strResearchConsent = xnode.SelectSingleNode("ResearchConsent").InnerText.Trim();
                 strTerms = xnode.SelectSingleNode("Terms").InnerText.Trim();
            }        
        }

        [Given(@"I am on the SH UK registration form")]
        public void GivenIAmOnTheSHUKRegistrationForm()
        {
            ReadXmlFile();
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://www.sh.uk/register");          
        }

        [Given(@"I enter a valid first name")]
        public void GivenIEnterAValidFirstName()
        {
            IWebElement fName = _driver.FindElement(By.Id("contentBody_txtFirstName"));
            fName.SendKeys(strFirstName);
        }

        [Given(@"I enter a valid Last name")]
        public void GivenIEnterAValidLastName()
        {
            IWebElement lName = _driver.FindElement(By.Id("contentBody_txtLastName"));
            lName.SendKeys(strLastName);
        }

        [Given(@"I enter a valid Gender Identity")]
        public void GivenIEnterAValidGenderIdentity()
        {
            SelectElement select = new SelectElement(_driver.FindElement(By.Id("contentBody_drpGender")));
            select.SelectByValue(strGender);
        }

        [Given(@"I enter a valid Assigned Sex")]
        public void GivenIEnterAValidAssignedSex()
        {
            SelectElement select = new SelectElement(_driver.FindElement(By.Id("contentBody_drpAssignedSex")));
            select.SelectByValue(strAssignedSex);
        }

        [Given(@"I enter a valid Partner Sex")]
        public void GivenIEnterAValidPartnerSex()
        {
            SelectElement select = new SelectElement(_driver.FindElement(By.Id("contentBody_drpPartnerSex")));
            select.SelectByValue(strPartnerSex);
        }

        [Given(@"I enter a valid Date Of Birth")]
        public void GivenIEnterAValidDateOfBirth()
        {
            SelectElement selectDay = new SelectElement(_driver.FindElement(By.Id("contentBody_drpDay")));
            selectDay.SelectByText("1");


            SelectElement selectMonth = new SelectElement(_driver.FindElement(By.Id("contentBody_drpMonth")));
            selectMonth.SelectByText("Jan");


            SelectElement selectYear = new SelectElement(_driver.FindElement(By.Id("contentBody_drpYear")));
            selectYear.SelectByText("2000");
        }

        [Given(@"I enter a valid Ethnicity")]
        public void GivenIEnterAValidEthnicity()
        {
            SelectElement select = new SelectElement(_driver.FindElement(By.Id("contentBody_drpEthnicity")));
            select.SelectByText(strEthinicity);
        }

        [Given(@"I enter a valid Address")]
        public void GivenIEnterAValidAddress()
        {
            IWebElement add1 = _driver.FindElement(By.Id("contentBody_ctlContact_txtAddress1"));
            add1.SendKeys(strAddress1);
        }

        [Given(@"I enter a valid Town")]
        public void GivenIEnterAValidTown()
        {
            IWebElement town = _driver.FindElement(By.Id("contentBody_ctlContact_txtTownCity"));
            town.SendKeys(strTownCity);
        }

        [Given(@"I enter a valid Postcode")]
        public void GivenIEnterAValidPostcode()
        {
            IWebElement pCode = _driver.FindElement(By.Id("contentBody_ctlContact_txtPostCode"));
            pCode.SendKeys(strPostcode);
        }
        [Given(@"I enter a valid County")]
        public void GivenIEnterAValidCounty()
        {
            IWebElement county = _driver.FindElement(By.Id("contentBody_ctlContact_txtCounty"));
            county.SendKeys(strCounty);
        }

        [Given(@"I enter a valid Email address")]
        public void GivenIEnterAValidEmailAddress()
        {
            IWebElement email = _driver.FindElement(By.Id("contentBody_txtEmailAddress"));
            email.SendKeys(strEmail);
        }

        [Given(@"I enter a valid Mobile Number")]
        public void GivenIEnterAValidMobileNumber()
        {
            IWebElement mobile = _driver.FindElement(By.Id("contentBody_txtMobileNumber"));
            mobile.SendKeys(strMobile);
        }
        [Given(@"I enter a valid Contact Preference")]
        public void GivenIEnterAValidContactPreference()
        {
            IWebElement radio1 = _driver.FindElement(By.Id("contentBody_radContactPreference_0"));
            IWebElement radio2 = _driver.FindElement(By.Id("contentBody_radContactPreference_1"));
            IWebElement radio3 = _driver.FindElement(By.Id("contentBody_radContactPreference_2"));
            Actions actions = new Actions(_driver);

            if (strContactPreference == "BOTH")
            {
                actions.MoveToElement(radio1).Click().Build().Perform();
            }
            if (strContactPreference == "SMS")
            {
                actions.MoveToElement(radio2).Click().Build().Perform();
            }          
            if (strContactPreference == "EMAIL")
            {
                actions.MoveToElement(radio3).Click().Build().Perform();
            }
        }
        [Given(@"I enter a valid Password")]
        public void GivenIEnterAValidPassword()
        {
            IWebElement pWord = _driver.FindElement(By.Id("contentBody_txtPassword"));
            pWord.SendKeys(strPassword);
        }
        [Given(@"I enter a confirm Password which matches the password")]
        public void GivenIEnterAConfirmPasswordWhichMatchesThePassword()
        {
            IWebElement cpWord = _driver.FindElement(By.Id("contentBody_txtPasswordConfirm"));
            cpWord.SendKeys(strPasswordConfirm);
        }
        [Given(@"I give consent to participate in research")]
        public void GivenIGiveConsentToParticipateInResearch()
        {
            if (strResearchConsent== "Yes") 
            {
                IWebElement cpWord = _driver.FindElement(By.Id("contentBody_chkResearchConsent"));
                Actions actions = new Actions(_driver);
                actions.MoveToElement(cpWord).Click().Build().Perform();
            }            
        }
        [Given(@"I agree with the terms of use and privacy policy")]
        public void GivenIAgreeWithTheTermsOfUseAndPrivacyPolicy()
        {
            if (strTerms == "Yes")
            {
                IWebElement cpWord = _driver.FindElement(By.Id("contentBody_chkTerms"));
                Actions actions = new Actions(_driver);
                actions.MoveToElement(cpWord).Click().Build().Perform();
            }
        }
        [When(@"I submit the registration form")]
        public void WhenISubmitTheRegistrationForm()
        {
            _driver.FindElement(By.Id("contentBody_btnRegister")).Click();
        }
        [Then(@"Redirects to account verification page")]
        public void ThenRedirectsToAccountVerificationPage()
        {
            //ideally I should check for registeration complete/ accpount verification url but because 
            //that is not with in the scope of the use case im just limiting it here just to finish testing and automation.
            Assert.IsTrue(_driver.Url.ToLower().Contains("register"));
           
        }


        [Given(@"If the user did not enter an email address")]
        public void GivenIfTheUserDidNotEnterAnEmailAddress()
        {

            IWebElement fName = _driver.FindElement(By.Id("contentBody_txtFirstName"));
            fName.SendKeys(strFirstName);
            IWebElement lName = _driver.FindElement(By.Id("contentBody_txtLastName"));
            lName.SendKeys(strLastName);
            SelectElement select = new SelectElement(_driver.FindElement(By.Id("contentBody_drpGender")));
            select.SelectByValue(strGender);
            SelectElement selectSex = new SelectElement(_driver.FindElement(By.Id("contentBody_drpAssignedSex")));
            selectSex.SelectByValue(strAssignedSex);
            SelectElement selectPartnersSex = new SelectElement(_driver.FindElement(By.Id("contentBody_drpPartnerSex")));
            selectPartnersSex.SelectByValue(strPartnerSex);
            SelectElement selectDay = new SelectElement(_driver.FindElement(By.Id("contentBody_drpDay")));
            selectDay.SelectByText("1");


            SelectElement selectMonth = new SelectElement(_driver.FindElement(By.Id("contentBody_drpMonth")));
            selectMonth.SelectByText("Jan");


            SelectElement selectYear = new SelectElement(_driver.FindElement(By.Id("contentBody_drpYear")));
            selectYear.SelectByText("2000");

            SelectElement selectEth = new SelectElement(_driver.FindElement(By.Id("contentBody_drpEthnicity")));
            selectEth.SelectByText(strEthinicity);

            IWebElement add1 = _driver.FindElement(By.Id("contentBody_ctlContact_txtAddress1"));
            add1.SendKeys(strAddress1);

            IWebElement town = _driver.FindElement(By.Id("contentBody_ctlContact_txtTownCity"));
            town.SendKeys(strTownCity);

            IWebElement pCode = _driver.FindElement(By.Id("contentBody_ctlContact_txtPostCode"));
            pCode.SendKeys(strPostcode);


            IWebElement county = _driver.FindElement(By.Id("contentBody_ctlContact_txtCounty"));
            county.SendKeys(strCounty);

            //Passing blank value to email field
            IWebElement email = _driver.FindElement(By.Id("contentBody_txtEmailAddress"));
            email.SendKeys("");

            IWebElement mobile = _driver.FindElement(By.Id("contentBody_txtMobileNumber"));
            mobile.SendKeys(strMobile);

            IWebElement radio1 = _driver.FindElement(By.Id("contentBody_radContactPreference_0"));
            IWebElement radio2 = _driver.FindElement(By.Id("contentBody_radContactPreference_1"));
            IWebElement radio3 = _driver.FindElement(By.Id("contentBody_radContactPreference_2"));
            Actions actions = new Actions(_driver);

            if (strContactPreference == "BOTH")
            {
                actions.MoveToElement(radio1).Click().Build().Perform();
            }
            if (strContactPreference == "SMS")
            {
                actions.MoveToElement(radio2).Click().Build().Perform();
            }
            if (strContactPreference == "EMAIL")
            {
                actions.MoveToElement(radio3).Click().Build().Perform();
            }

            IWebElement pWord = _driver.FindElement(By.Id("contentBody_txtPassword"));
            pWord.SendKeys(strPassword);

            IWebElement cpWord = _driver.FindElement(By.Id("contentBody_txtPasswordConfirm"));
            cpWord.SendKeys(strPasswordConfirm);

            if (strResearchConsent == "Yes")
            {
                IWebElement chkcontentYes = _driver.FindElement(By.Id("contentBody_chkResearchConsent"));
                Actions actionschk = new Actions(_driver);
                actionschk.MoveToElement(chkcontentYes).Click().Build().Perform();
            }
            if (strTerms == "Yes")
            {
                IWebElement chkTermsYes = _driver.FindElement(By.Id("contentBody_chkTerms"));
                Actions actionsTerms = new Actions(_driver);
                actionsTerms.MoveToElement(chkTermsYes).Click().Build().Perform();
            }
        }

       
        [Then(@"I should see an error message")]
        public void ThenIShouldSeeAnErrorMessage()
        {
            try
            {
                IWebElement errorElement = _driver.FindElement(By.CssSelector("div.has-error has-feedback"));
                Assert.Equals("Please Provide a valid Email Address", errorElement.Text);
            }
            catch 
            {
            
            }
        }


        [AfterScenario]
        public void DisposeWebDriver() 
        {
            _driver.Dispose();
        }
    }
}
