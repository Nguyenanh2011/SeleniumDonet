using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ex1.PageObjects
{
    class LoginPage : GeneralPage
    {
        private By usernameTextbox = By.Id("userName");
        private By passwordTextbox = By.Id("password");

        protected IWebElement getUsernameTextbox()
        {
            return Constant.Constant.WEBDRIVER.FindElement(usernameTextbox);
        }
        protected IWebElement getPasswordTextbox()
        {
            return Constant.Constant.WEBDRIVER.FindElement(passwordTextbox);
        }

        public void inputNameAndPass(String username, String password)
        {
            this.getUsernameTextbox().SendKeys(username);
            this.getPasswordTextbox().SendKeys(password);
        }
        public void clickLogin()
        {
           ScrollElementAndClick(getLoginBtn());
        }
    }
}
