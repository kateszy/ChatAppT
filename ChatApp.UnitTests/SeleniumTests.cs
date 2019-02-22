using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace ChatApp.UnitTests
{
    [TestClass]
    public class SeleniumTests
    {
        IWebDriver driver;

        [TestInitialize]
        public void init()
        {
            this.driver = new FirefoxDriver();
        }

        [TestMethod]
        public void IsRegisterWorkingTest()
        {
            string pass = "hasloO1!";
            string mail = generateMail();
            driver.Navigate().GoToUrl("http://localhost:55661/Account/Register");
            var email = driver.FindElement(By.Id("Email"));
            email.SendKeys(mail);
            var password = driver.FindElement(By.Id("Password"));
            password.SendKeys(pass);
            var confirmpassword = driver.FindElement(By.Id("ConfirmPassword"));
            confirmpassword.SendKeys(pass);
            driver.FindElement(By.Id("rejes")).Click();
            var menu = driver.FindElement(By.Id("logoutForm"));
            NUnit.Framework.Assert.IsTrue(menu.FindElement(By.XPath("//*[@title=\"Manage\"]")).Displayed);
        }

        [TestMethod]
        public void IsLoginAndChatWorkingTest()
        {
            string pass = "hasloO1!";
            string mail = "testAccount@test.com";
            string message = "hello world";
            driver.Navigate().GoToUrl("http://localhost:55661/Account/Login");
            var email = driver.FindElement(By.Id("Email"));
            email.SendKeys(mail);
            var password = driver.FindElement(By.Id("Password"));
            password.SendKeys(pass);
            driver.FindElement(By.XPath("//*[@type=\"submit\"]")).Click();
            driver.Navigate().GoToUrl("http://localhost:55661/Home/Chat");
            Wait(driver => driver.FindElement(By.Id("user")).Displayed, 1000); // wait for user loading in chat subsite
            driver.FindElement(By.Id("txt")).SendKeys(message);
            driver.FindElement(By.Id("send")).Click();
            var parentElement = driver.FindElement(By.Id("message"));
            IList<IWebElement> messages = parentElement.FindElements(By.TagName("li"));
            NUnit.Framework.Assert.NotNull(messages);
            NUnit.Framework.StringAssert.Contains(message,messages[0].Text);
        }

        [TestCleanup]
        public void cleanup()
        {
            driver.Close();
        }

        public void Wait(Func<IWebDriver, bool> condition, double delay)
        {
            var ignoredExceptions = new List<Type>() { typeof(StaleElementReferenceException) };
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(delay));
            wait.IgnoreExceptionTypes(ignoredExceptions.ToArray());
            wait.Until(condition);
        }

        public static string generateMail()
        {
            Random random = new Random();
            int length = 10;
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString() + "@mail.com";
        }




    }
}
