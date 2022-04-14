using System;
using System.Collections.Generic;
using System.Text;

namespace ex1.PageObjects
{
    class Homepage : GeneralPage
    {
        public void openHomepage()
        {
            Constant.Constant.WEBDRIVER.Navigate().GoToUrl(Constant.Constant.APP_URL);
        }
    }
}
