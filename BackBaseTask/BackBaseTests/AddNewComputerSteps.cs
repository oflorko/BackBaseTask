using System;
using System.Net;
using TechTalk.SpecFlow;
using Computers;
using RestSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BackBaseTask.BackBaseTests
{
    [Binding]
    public class AddNewComputerSteps : ApiSteps
    {
        private readonly RestClient client;
        private readonly RestRequest request;
        public NewComputer newComputer;

        public AddNewComputerSteps(BaseContext baseContext) : base(baseContext)
        {
            client = new RestClient("http://computer-database.herokuapp.com/");
            request = new RestRequest("computers", Method.POST);
            newComputer = new NewComputer();
        }

        [Given(@"I set the computer name to ""(.*)""")]
        public void GivenISetTheComputerNameTo(string computerName)
        {
            newComputer.ComputerName = computerName;
        }
        
        [Given(@"I set the Introduced date to ""(.*)""")]
        public void GivenISetTheIntroducedDateTo(string introducedDate)
        {
            newComputer.IntroducedDate = introducedDate;
        }
        
        [Given(@"I set the Discontinued date to ""(.*)""")]
        public void GivenISetTheDiscontinuedDateTo(string discontinuedDate)
        {
            newComputer.DiscontinuedDate = discontinuedDate;
        }
        
        [Given(@"I set the Company to ""(.*)""")]
        public void GivenISetTheCompanyTo(string company)
        {
            newComputer.Company = company;
        }

        // This function is owerloaded to use in other classes
        [When(@"I press Create this computer")]
        public void WhenIPressCreateThisComputer()
        {
            request.AddParameter("name", newComputer.ComputerName);
            request.AddParameter("introduced", newComputer.IntroducedDate);
            request.AddParameter("discontinued", newComputer.DiscontinuedDate);
            request.AddParameter("company", newComputer.Company);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            BaseContext.response = client.Execute(request);
        }
        public void WhenIPressCreateThisComputer(NewComputer newComputer)
        {
            request.AddParameter("name", newComputer.ComputerName);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            BaseContext.response = client.Execute(request);
        }
       
    }
}
