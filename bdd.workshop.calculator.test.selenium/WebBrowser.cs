﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bdd.workshop.calculator.test.selenium
{
    public abstract class WebBrowser : IDisposable
    {
        public static string Route()
        {
            string res;
            string os = Environment.OSVersion.Platform.ToString();
            if (os.StartsWith("Win"))
            {
                res = "C:\\ChromeDriver\\";
            }
            else if (os.StartsWith("Linux"))
            {
                res = "/usr/bin/";
            }
            else
            {
                throw new NotSupportedException("Unsupported operating system.");
            }
            return res;
        }
        protected IWebDriver Driver { get; set; } = new ChromeDriver(Route());
        public void Dispose()
        {
            Driver.Close();
            GC.SuppressFinalize(this);
        }
        protected IWebElement FindElement(string xpath, WebDriverWait wait)
        {
            wait.Until(driver => driver.FindElement(By.XPath(xpath)));
            return Driver.FindElement(By.XPath(xpath));
        }
    }
}
