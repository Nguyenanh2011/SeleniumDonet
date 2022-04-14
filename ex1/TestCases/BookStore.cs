using ex1.PageObjects;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace ex1.TestCases
{
    class BookStore
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
        public void BookStoreTest()
        {
            //variable
            String namebook = "Git Pocket Guide";
            String messAlertSuccess = "Book added to your collection.";
            String messAlertDublicate = "Book already present in the your collection!";

            // page 
            Homepage homePage = new Homepage();
            BookPage bookPage = new BookPage();
            GeneralPage generalPage = new GeneralPage();
            LoginPage loginPage = new LoginPage();

            // check Login is sucess with right name
            homePage.openHomepage();
            homePage.goToLoginPage(); 
            loginPage.inputNameAndPass(Constant.Constant.USERNAME, Constant.Constant.PASSWORD);
            loginPage.clickLogin();
            String headerText = homePage.getUsernameLabelValue();
            Assert.AreEqual(headerText, Constant.Constant.USERNAME, "Username is not displayed as expected.");

            // choose book
            if (bookPage.getBook(namebook).Displayed)
            {
                Console.WriteLine("book present!");
                bookPage.pickBook(namebook);
                Assert.AreEqual(namebook.ToLower(), bookPage.getTextNameBookLabel().ToLower());

                // check mess alert.
                bookPage.addBookToCollection();
                Assert.IsTrue(bookPage.checkMessAlert().ToLower().Contains(messAlertSuccess.ToLower()));

            }
            else
            {
                Console.WriteLine("Book Not present");
            }
           
        }
        [Test]
        public void SearchBookTest() 
        {
            // variable
            String searchText = "Design";
           
            // page 
            Homepage homePage = new Homepage();
            BookPage bookPage = new BookPage();

            //go to homepage
            homePage.openHomepage();
            bookPage.inputSearhBox(searchText);
            Assert.IsTrue(bookPage.checkResultSearch(searchText));
        }

        [Test]
        public void DeleteBookTest()
        {
            // variable
            String bookName = "Git Pocket Guide";
            String messAlert = "book deleted.";
            // page 
            Homepage homePage = new Homepage();
            BookPage bookPage = new BookPage();
            LoginPage loginPage = new LoginPage();

            // check Login is sucess with right name
            homePage.openHomepage();
            homePage.goToLoginPage();
            loginPage.inputNameAndPass(Constant.Constant.USERNAME, Constant.Constant.PASSWORD);
            loginPage.clickLogin();
            String headerText = homePage.getUsernameLabelValue();
            Assert.AreEqual(headerText, Constant.Constant.USERNAME, "Username is not displayed as expected.");

            //go to profile and check delete book.
            bookPage.gotoProfile();
            bookPage.inputSearhBox(bookName);
            if (bookPage.checkResultSearch(bookName))
            {
                Console.WriteLine(bookName + " is available!");
                bookPage.deleteBook(bookName);
                Assert.IsTrue(bookPage.isDeletePopupPresent());
                bookPage.clickAcceptDeletePopup();
                Assert.IsTrue(bookPage.checkMessAlert().ToLower().Contains(messAlert.ToLower()));
                Assert.IsFalse(bookPage.checkResultSearch(bookName));
            }
            else
            {
                Console.WriteLine("Your collection don't have this book: " + bookName);
            }
        }
    }
}
