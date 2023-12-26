using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace bdd.workshop.calculator.test.selenium
{
    public class CubeRoot : WebBrowser
    {   
        private void CubeRootTest(int number, double result)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var numberXPath = @"//input[@id='TheNumber']";
            var submitButton = "//input[@type='submit']";
            var url = "https://bdd-workshop-hector-betancourt.azurewebsites.net/";
            Driver.Url = $"{url}CubeRoot";
            var inputA = FindElement(numberXPath, wait);
            var button = FindElement(submitButton, wait);
            inputA.SendKeys(number.ToString());
            button.Click();
            var resultXPath = "//td[@id='theCubeResult']";
            var outputResultString = FindElement(resultXPath, wait).Text;
            outputResultString = outputResultString.Replace(',', '.');
            Assert.True(double.TryParse(outputResultString, CultureInfo.InvariantCulture, out double outputResult));
            Assert.InRange(outputResult, result - 0.1, result + 0.1);
        }
        [Theory(DisplayName = "Operations Theory")]
        [Trait("TestType", "Functional Theories")]
        [InlineData(5, 1.71)]
        [InlineData(10, 2.15)]
        [InlineData(20, 2.71)]
        [InlineData(27, 3)]
        [InlineData(49, 3.71)]
        [InlineData(64, 4)]
        public void OperationsTheory(int a, double result)
        {
            CubeRootTest(a, result);
        }
    }
}
