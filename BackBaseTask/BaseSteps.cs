using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BackBaseTask
{
    [Binding]
    public class BaseSteps
    {
        // Here we have steps that are common for all test cases

        private readonly BaseContext baseContext;

        public BaseSteps(BaseContext baseContext)
        {
            this.baseContext = baseContext;
        }

        [Then(@"response code should be ""(.*)""")]
        public void ThenResponseCodeShouldBe(string responseCode)
        {
            this.baseContext.VerifyStatusCode((HttpStatusCode) Enum.Parse(typeof(HttpStatusCode), responseCode));
        }

        [Then(@"response message should contain ""(.*)""")]
        public void ThenResponseMessageShouldContain(string message)
        {
            Assert.IsTrue(baseContext.response.Content.Contains(message), string.Format("The response should contain: {0}", message));
        }

    }
}
