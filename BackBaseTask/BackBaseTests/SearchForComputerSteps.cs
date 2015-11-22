using System;
using TechTalk.SpecFlow;
using Computers;
using RestSharp;
using BackBaseTask.BackBaseTests;

namespace BackBaseTask
{
    [Binding]
    public class SearchForComputerSteps : ApiSteps
    {
        private readonly RestClient client;
        private readonly RestRequest request;
        private NewComputer newComputer;

        private AddNewComputerSteps addNewComputer;

        public SearchForComputerSteps(BaseContext baseContext, AddNewComputerSteps addNewComputer)
            : base(baseContext)
        {
            client = new RestClient("http://computer-database.herokuapp.com/");
            request = new RestRequest("computers", Method.GET);
            newComputer = new NewComputer();

            this.addNewComputer = addNewComputer;

            baseContext.uniqueCompName = "Specflow" + DateTime.Now.ToString();
        }

        [When(@"I create the computer with unique name")]
        public void GivenISetTheComputerNameToUnique()
        {
            // Generate unique name for the computer
            newComputer.ComputerName = BaseContext.uniqueCompName;
            addNewComputer.WhenIPressCreateThisComputer(newComputer);
        }

        [When(@"I search for the computer")]
        public void WhenISearchForTheComputer()
        {
            request.AddParameter("f", BaseContext.uniqueCompName);

            BaseContext.response = client.Execute(request);
        }

    }
}
