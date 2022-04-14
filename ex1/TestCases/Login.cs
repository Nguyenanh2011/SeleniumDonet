using ex1.PageObjects;
using ex1.TestCases;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace ex1.TestCases
{
    class Login
    {
        [SetUp]
        public void SetUp()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            Constant.Constant.WEBDRIVER = new ChromeDriver();
            Constant.Constant.WEBDRIVER.Manage().Window.Maximize();
            Constant.Constant.WEBDRIVER.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            Constant.Constant.WEBDRIVER.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void TearDown()
        {
            Constant.Constant.WEBDRIVER.Quit();
        }

        [Test]
        public void LoginTest()
        {

            Homepage homePage = new Homepage();
            homePage.openHomepage();
            homePage.goToLoginPage();

            //LoginPage loginPage = new LoginPage();
            ////loginPage.login(Constant.Constant.USERNAME, Constant.Constant.PASSWORD);

            //String headerText = homePage.getUsernameLabelValue();
            //Assert.AreEqual(headerText, Constant.Constant.USERNAME, "Username is not displayed as expected.");
        }
    }

    
}
