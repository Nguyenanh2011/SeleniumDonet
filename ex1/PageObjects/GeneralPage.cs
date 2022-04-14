using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ex1.PageObjects
{
    class GeneralPage 
    {
        private By usernameLabel = By.Id("userName-value");
        private By loginBtn = By.Id("login");
        protected IWebElement getLoginBtn()
        {
            return Constant.Constant.WEBDRIVER.FindElement(loginBtn);
        }       
        protected IWebElement getUsernameLabel()
        {
            return Constant.Constant.WEBDRIVER.FindElement(usernameLabel);
        }

        public void goToLoginPage()
        {
            this.getLoginBtn().Click();
        }
        public String getUsernameLabelValue()
        {
            return this.getUsernameLabel().Text;
        }


        public static WebDriverWait wait = new WebDriverWait(Constant.Constant.WEBDRIVER, TimeSpan.FromSeconds(5));
        public static Actions actions = new Actions(Constant.Constant.WEBDRIVER);
        // ------------------- Wait ------------------------------
        public static IWebElement WaitForElementIsVisible(By locator)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
        //------------------ Scroll ------------------
        //public static void ScrollElementAndClick(IWebElement element)
        //{
        //    actions.MoveToElement(element);
        //    actions.Perform();
        //    element.Click();
        //}
        public static void ScrollElementAndClick(IWebElement element)
        {
            ((IJavaScriptExecutor)Constant.Constant.WEBDRIVER).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Click();
        }
        // --------------Alert ----------------------
        
        public static bool isAlertPresent()
        {
            try
            {
                return wait.Until(ExpectedConditions.AlertIsPresent()) != null;
            } catch (UnhandledAlertException e)
            {
                return wait.Until(ExpectedConditions.AlertIsPresent()) != null;
            }
            
        }
        public static IAlert alert()
        {
          return Constant.Constant.WEBDRIVER.SwitchTo().Alert();
        }
        
    }

}
