using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace BackBaseTask
{
    public class BaseContext
    {
        // Objects to store requests and response
        // In case if there are many sets of tests for different functoins we can share results 
        // between different test classes using context
        public RestClient client { get; set; }
        public RestRequest request { get; set; }
        public IRestResponse response { get; set; }

        public string uniqueCompName { get; set; }

        public void VerifyStatusCode(HttpStatusCode statusCode)
        {
            if (response.StatusCode == 0)
            {
                Assert.Fail("There was no status code. Error message: {0}", response.ErrorMessage);
            }
            else
            {
                HttpStatusCode expectedResponseCode = statusCode;
                Assert.AreEqual(expectedResponseCode, response.StatusCode, string.Format("The status code was {0}, but it should be {1}", response.StatusCode, expectedResponseCode));
            }
        }
    }
}
