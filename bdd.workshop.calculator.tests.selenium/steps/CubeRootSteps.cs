using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.CommonModels;
using Xunit;
using Xunit.Abstractions;

namespace bdd.workshop.calculator.tests.selenium.steps
{
    [Binding]
    public sealed class CubeRootSteps : WebBrowser 
    {
        private readonly ScenarioContext _scenarioContext;

        public CubeRootSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _scenarioContext.Add("Wait", new WebDriverWait(Driver, TimeSpan.FromSeconds(10)));
        }
        [When(@"number (.*) is added for cube root")]
        public void WhenNumberIsAddedForCubeRoot(int number)
        {
            var wait = _scenarioContext.Get<WebDriverWait>("Wait");
            var numberXPath = @"//input[@id='TheNumber']";
            var submitButton = "//input[@type='submit']";
            var url = "https://bdd-workshop-hector-betancourt.azurewebsites.net/";
            Driver.Url = $"{url}CubeRoot";
            var inputA = FindElement(numberXPath, wait);
            var button = FindElement(submitButton, wait);
            inputA.SendKeys(number.ToString());
            button.Click();
        }

        [Then(@"the result of the cube root is (.*)")]
        public void ThenTheResultOfCubeRootIs(double result)
        {
            var wait = _scenarioContext.Get<WebDriverWait>("Wait");
            var resultXPath = "//td[@id='theCubeResult']";
            var outputResultString = FindElement(resultXPath, wait).Text;
            outputResultString = outputResultString.Replace(',', '.');
            Assert.True(double.TryParse(outputResultString, CultureInfo.InvariantCulture, out double outputResult));
            Assert.InRange(outputResult, result - 0.1, result + 0.1);
        }
    }
}

