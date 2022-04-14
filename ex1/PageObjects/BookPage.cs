using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ex1.PageObjects
{
    class BookPage :GeneralPage
    {
        private By ProfileMenu = By.XPath("//div[@class='element-group']//li/span[contains(text(),'Profile')]/..");
        //private By bookStoreBtn = By.Id("gotoStore");
        private By addBookBtn = By.XPath("//button[contains(@id,'addNewRecordButton') and contains(text(),'Add To Your Collection')]");
        private By nameBookLabel = By.XPath("//label[contains(text(),'Title')]/../following-sibling::div/label[contains(@id,'userName-value')]");
        private By searchBox = By.Id("searchBox");
        private By bookInTable = By.XPath("//div[contains(@class,'rt-td')]//span[starts-with(@id,'see-book')]/a");
        private By deletePopup = By.XPath("//div[contains(@class,'modal-header')]/div[contains(text(),'Delete Book')]");
        private By acceptPopup = By.XPath("//button[contains(@id,'closeSmallModal-ok') and contains(text(),'OK')]");

        // Find Element
        public IWebElement getBook (String bookName)
        {
            return WaitForElementIsVisible(By.XPath("//span/a[contains(text(),'" + bookName + "')]"));
        }
        public IWebElement getDeleteBookIcon_Prof (String bookName)
        {
            return WaitForElementIsVisible(By.XPath("//span[starts-with(@id,'see-book')]/a[contains(text(),'" + bookName + "')]/ancestor::div[contains(@class,'rt-td')]/following-sibling::div//span[contains(@title,'Delete')]"));
        }
        public IWebElement getProfileMenuBtn()
        {
            return WaitForElementIsVisible(ProfileMenu);
        }
        public IWebElement getAddBookBtn()
        {
            return WaitForElementIsVisible(addBookBtn);
        }
     
        public IWebElement getNameBookLabel()
        {
            return WaitForElementIsVisible(nameBookLabel);
        }
        public IWebElement getSearchBox()
        {
            return WaitForElementIsVisible(searchBox);
        }
        public IList<IWebElement> getbookInTable()
        {
            return Constant.Constant.WEBDRIVER.FindElements(bookInTable);
        }
        public IWebElement getDeletePopup()
        {
            return WaitForElementIsVisible(deletePopup);
        }
        public IWebElement getAcceptDeletePopup()
        {
            return Constant.Constant.WEBDRIVER.FindElement(acceptPopup);
        }

        /// Actions in element
        public void pickBook (string namebook)
        {
            ScrollElementAndClick(getBook(namebook));
        }
        public void gotoProfile()
        {
            ScrollElementAndClick(getProfileMenuBtn());
        }
        public void addBookToCollection()
        {
            ScrollElementAndClick(getAddBookBtn());
        }
        public string getTextNameBookLabel()
        {
            return this.getNameBookLabel().Text;
        }
        public string checkMessAlert()
        {
            string mess = "";
            if (isAlertPresent() == true)
            {
                Console.WriteLine("Alert is displayed!");
                mess = alert().Text;
                alert().Accept();
            }
            else
            {
                Console.WriteLine("Alert is not displayed!");
            }
            Console.WriteLine("---mess Alert : " + mess);
            return mess;

        }
        public void inputSearhBox (string text)
        {
            this.getSearchBox().Click();
            this.getSearchBox().Clear();
            this.getSearchBox().SendKeys(text);
        }
        public bool checkResultSearch (string text)
        {
            int numbook = 0;
            if(getbookInTable().Count > 0) {
                foreach (IWebElement book in getbookInTable())
                {
                    if (book.Text.ToLower().Contains(text.ToLower()))
                    {
                        numbook++;
                        Console.WriteLine(numbook + "- " + book.Text);
                    }

                }
                if (numbook > 0 && numbook == getbookInTable().Count) return true;
                else return false;
            }
            else return false;
                
            Console.WriteLine("Found " + numbook + " books contains :" + text + " in " + getbookInTable().Count + " row book displayed!");

          
            
        }
        
        public void deleteBook (string bookName)
        {
           this.getDeleteBookIcon_Prof(bookName).Click();
        }
        public bool isDeletePopupPresent()
        {
            return getDeletePopup()!=null;
        }
        public void clickAcceptDeletePopup()
        {
            this.getAcceptDeletePopup().Click();
        }
    }
}
