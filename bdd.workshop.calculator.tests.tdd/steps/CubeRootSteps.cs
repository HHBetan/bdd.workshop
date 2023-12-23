using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.CommonModels;
using Xunit;
using Xunit.Abstractions;

namespace bdd.workshop.calculator.tests.selenium.steps
{
    [Binding]
    public sealed class CubeRootSteps
    {
        private readonly ScenarioContext _scenarioContext;
        
        public CubeRootSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [When(@"number (.*) is added for cube root")]
        public void WhenNumberIsAddedForCubeRoot(int number)
        {
            _scenarioContext.Add("CubeRoot", Operator.CubeRoot(number));

        }

        [Then(@"the result of the cube root is (.*)")]
        public void ThenTheResultOfCubeRootIs(double result)
        {
            var res = _scenarioContext.Get<double>("CubeRoot");
            Assert.InRange(res, result - 0.1, result + 0.1);
        }
    }
}

