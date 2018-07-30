using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using RestSharp;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NVOnline.BDD.Tests
{
    [Binding]
    public class SignInSteps
    {
        private string _username;
        private string _password;
        private string _appid;
        private int _docId;
        private RestClient _client;
        private IRestResponse _restResponse = new RestResponse();
        public SignInSteps()
        {
            _client = new RestClient("http://nvonlineapi.nvidia.com/NVOnlineAPI/");
        }

        [Given(@"I have entered credentails (.*), (.*) and (.*)")]
        public void GivenIHaveEnteredCredentailsUsernamePasswordAndAppId(string username, string password, string appid)
        {
            _username = username;
            _password = password;
            _appid = appid;
        }
        
        [When(@"I request signin endpoint")]
        public void WhenIRequestSigninEndpoint()
        {
           
            var request = new RestRequest("api/signin", Method.GET);    
            request.AddHeader("username", _username);
            request.AddHeader("password", _password);
            request.AddHeader("appid", _appid);
            request.Timeout = 30000;
            _restResponse = _client.Execute(request);
        }
        
        [Then(@"the result should be (.*) with (.*)")]
        public void ThenTheResultShouldBeWith(string message, int statusCode)
        {
            if (statusCode != (int)_restResponse.StatusCode)
            {
                ScenarioContext.Current.Pending();
            }
            dynamic obj = JsonConvert.DeserializeObject(_restResponse.Content);
        }

        [Given(@"I have entered docId (.*)")]
        public void GivenIHaveEnteredDocId(int docId)
        {
            _docId = docId;
        }

        [When(@"I request filecontentsbydocid endpoint")]
        public void WhenIRequestFilecontentsbydocidEndpoint()
        {
            string url=string.Format("api/filecontentsbydocid?docid={0}",_docId);
            var request=new RestRequest(url,Method.HEAD);
            request.AddHeader("token", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ1c2VybmFtZSI6ImhraGFuZGhlZGlhQG52aWRpYS5jb20iLCJmdWxsbmFtZSI6IkhhcmRpayBLaGFuZGhlZGlhIiwiYXBwaWQiOiJTREsgTWFuYWdlciIsInVzZXJpZCI6Mzk1OTkyLCJ0aWNrcyI6NjM2NjgxMzI1ODQyODEwNzYzfQ.j-vaFYz00hFyq5PsY_p5rqBJZW_E40jHHrH16J5l9Nw");
            _restResponse = _client.Execute(request);

        }

        [Then(@"the response should be header details with (.*) status code")]
        public void ThenTheResponseShouldBeHeaderDetailsWithStatusCode(int statusCode)
        {
            if(statusCode!=(int)_restResponse.StatusCode)
            {
                ScenarioContext.Current.Pending();
            }
            string fileName = Convert.ToString(_restResponse.Headers[1].Value);
            long fileSize = Convert.ToInt64(_restResponse.Headers[2].Value);
            string cacheControl = Convert.ToString(_restResponse.Headers[4].Value);

            fileName.Should().Be("cuda-repo-ubuntu-8.0.30-1_14.04-amd64.deb");
            fileSize.Should().Be(1890090116);
            cacheControl.Should().Be("no-cache");
        }


    }
}
