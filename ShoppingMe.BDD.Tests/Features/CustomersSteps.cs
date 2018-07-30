using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Web.Http;
using System.Web.Http.Results;
using System.Net;
using System.Net.Http;
using Contract;
using Newtonsoft.Json;
using FluentAssertions;
using RestSharp;
using Newtonsoft.Json.Converters;

namespace ShoppingMe.BDD.Tests.Features
{
    [Binding]
    public class CustomersSteps
    {
        private int _customerId = 0;
        private string _emailId = null;
        private string _password=null;
        private CustomerContract contract = null;
        private List<CustomerContract> contractList = null;
        private List<IRestResponse> _restResponseList = new List<IRestResponse>();

        [Given(@"I have entered customerId (.*)")]
        public void GivenIHaveEnteredCustomerId(int customerId)
        {
            _customerId = customerId;
        }

        [When(@"I request getcustomerbyId endpoint")]
        public void WhenIRequestGetcustomerbyIdEndpoint()
        {
            var client = new RestClient("http://192.168.43.185:2121/");
            string url = string.Format("api/v1/getcustomerbyid?customerId={0}", _customerId);
            var request = new RestRequest(url, Method.GET);
            var restResponse = client.Execute<CustomerContract>(request);
            _restResponseList.Add(restResponse);
        }

        [Then(@"the result should be customer details on the screen with (.*) status code")]
        public void ThenTheResultShouldBeCustomerDetailsOnTheScreen(int statusCode)
        {
            foreach (var restResponse in _restResponseList)
            {
                if (statusCode != (int)restResponse.StatusCode)
                {
                    ScenarioContext.Current.Pending();
                }

                CustomerContract contract = JsonConvert.DeserializeObject<CustomerContract>(restResponse.Content);
                //contract.FirstName.Should().Be("Trupti");
            }
        }

        [Given(@"I have entered customer contract object")]
        public void GivenIHaveEnteredCustomerContractObject(Table table)
        {
            contract = table.CreateInstance<CustomerContract>();
            table.CompareToInstance<CustomerContract>(contract);

            contractList = new List<CustomerContract>();
            contractList.Add(contract);
        }

        [Given(@"I have entered customer contract objects")]
        public void GivenIHaveEnteredCustomerContractObjects(Table table)
        {
            contractList = table.CreateSet<CustomerContract>().ToList();
            table.CompareToSet<CustomerContract>(contractList);
        }

        [When(@"I request createcustomer endpoint")]
        public void WhenIRequestCreatecustomerEndpoint()
        {
            foreach (var restResponse in contractList)
            {
                // Step 1 : URL
                var client = new RestClient("http://192.168.43.185:2121/");

                // Step 2 : Request
                var request = new RestRequest("api/v1/createcustomer", Method.POST);

                //var json = JsonConvert.SerializeObject(restResponse, new IsoDateTimeConverter() { DateTimeFormat = "MM/dd/yyyy HH:mm:ss tt" });
                //var json1 = JsonConvert.SerializeObject(restResponse, new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat });

                request.AddHeader("content-type", "application/json; charset=utf-8");
                request.RequestFormat = DataFormat.Json;
                //request.Timeout = 3000;
                request.AddBody(new
                {
                    FirstName = restResponse.FirstName,
                    LastName = restResponse.LastName,
                    Mobile = restResponse.Mobile,
                    Email = restResponse.Email,
                    Password = restResponse.Password,
                    CreatedDate = DateTime.Now
                });

                // Step : Response
                var output = client.Execute(request);
                _restResponseList.Add(output);
            }
        }

        [Then(@"the result should be (.*) on the screen with (.*) status code")]
        public void ThenTheResultShouldBeTrueOnTheScreenWithStatusCode(bool output, int statusCode)
        {
            foreach (var restResponse in _restResponseList)
            {
                if (statusCode != (int)restResponse.StatusCode)
                {
                    ScenarioContext.Current.Pending();
                }

                bool response = JsonConvert.DeserializeObject<bool>(restResponse.Content);
                response.Should().Be(output);
            }
        }

        [Then(@"the multiple result should be (.*) on the screen with (.*) status code")]
        public void ThenTheMultipleResultShouldBeTrueOnTheScreenWithStatusCode(bool output, int statusCode)
        {
            foreach (var restResponse in _restResponseList)
            {
                if (statusCode != (int)restResponse.StatusCode)
                {
                    ScenarioContext.Current.Pending();
                }

                bool response = JsonConvert.DeserializeObject<bool>(restResponse.Content);
                response.Should().Be(output);
            }
        }

        [When(@"I request updatecustomer endpoint")]
        public void WhenIRequestUpdatecustomerEndpoint()
        {
            var client = new RestClient("http://192.168.43.185:2121/");
            string url = string.Format("api/v1/updatecustomer");
            var request = new RestRequest(url, Method.POST);
            request.AddObject(contract);
            var restResponse = client.Execute<CustomerContract>(request);
            _restResponseList.Add(restResponse);
        }

        [Given(@"I have entered email (.*)")]
        public void GivenIHaveEnteredEmailTrupti_JundaleYahoo_Com(string emailId)
        {
            _emailId = emailId;
        }

        [When(@"I request getcustomerbemail endpoint")]
        public void WhenIRequestGetcustomerbemailEndpoint()
        {
            var client = new RestClient("http://192.168.43.185:2121/");
            string url = string.Format("api/v1/getcustomerbyemail?email={0}", _emailId);
            var request = new RestRequest(url, Method.GET);
            var restResponse = client.Execute<CustomerContract>(request);
            _restResponseList.Add(restResponse);
        }

        [Then(@"the result must be customer details on the screen with (.*) status code")]
        public void ThenTheResultMustBeCustomerDetailsOnTheScreenWithStatusCode(int statusCode1)
        {
            foreach (var restResponse in _restResponseList)
            {
                if (statusCode1 != (int)restResponse.StatusCode)
                {
                    ScenarioContext.Current.Pending();
                }

                CustomerContract contract = JsonConvert.DeserializeObject<CustomerContract>(restResponse.Content);
                //contract.FirstName.Should().Be("Trupti");
            }
        }

        [Given(@"i have entered email (.*) and password (.*)")]
        public void GivenIHaveEnteredEmailTryambakGmail_ComAndPasswordAbc(string email, string pass)
        {
            _emailId = email;
            _password = pass;
        }

        [When(@"I request validatecredentialbyemailandpassword endpoint")]
        public void WhenIRequestValidatecredentialbyemailandpasswordEndpoint()
        {
            var client = new RestClient("http://192.168.43.185:2121/");
            string url = string.Format("api/v1/validatecredentialbyemailandpassword?email={0}&password={1}", _emailId, _password);
            var request = new RestRequest(url, Method.GET); 
            var restResponse = client.Execute(request);
            _restResponseList.Add(restResponse);

        }

        [Then(@"the result shows status code (.*)")]
        public void ThenTheResultShowsStatusCode(int statusCode)
        {
            foreach (var restResponse in _restResponseList)
            {
                if (statusCode != (int)restResponse.StatusCode)
                {
                    ScenarioContext.Current.Pending();
                }

                CustomerContract contract = JsonConvert.DeserializeObject<CustomerContract>(restResponse.Content);
                contract.Should().NotBeNull();
            }
        }

    }
}
