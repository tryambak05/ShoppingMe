﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.3.0.0
//      SpecFlow Generator Version:2.3.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace ShoppingMe.BDD.Tests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("Customers", Description="\tCustomer having account holder of ShoppingMe website", SourceFile="Customers.feature", SourceLine=0)]
    public partial class CustomersFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Customers.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Customers", "\tCustomer having account holder of ShoppingMe website", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [TechTalk.SpecRun.FeatureCleanup()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        [TechTalk.SpecRun.ScenarioCleanup()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("[GET] : api/v1/getcustomerbyid?customerId=1", new string[] {
                "customers"}, SourceLine=5)]
        public virtual void GETApiV1GetcustomerbyidCustomerId1()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[GET] : api/v1/getcustomerbyid?customerId=1", new string[] {
                        "customers"});
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("I have entered customerId 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.When("I request getcustomerbyId endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
 testRunner.Then("the result should be customer details on the screen with 200 status code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("[POST] : api/v1/createcustomer", new string[] {
                "customers"}, SourceLine=11)]
        public virtual void POSTApiV1Createcustomer()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[POST] : api/v1/createcustomer", new string[] {
                        "customers"});
#line 12
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "FirstName",
                        "LastName",
                        "Email",
                        "Password",
                        "Mobile"});
            table1.AddRow(new string[] {
                        "Pramod",
                        "Swami",
                        "pramod.swami@gmail.com",
                        "Pass$#123",
                        "9890765456"});
            table1.AddRow(new string[] {
                        "Varsha",
                        "Balreddi",
                        "varsh.reddi@yahoo.com",
                        "Sm@rt#4",
                        "9876345654"});
#line 13
 testRunner.Given("I have entered customer contract objects", ((string)(null)), table1, "Given ");
#line 17
 testRunner.When("I request createcustomer endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
 testRunner.Then("the result should be true on the screen with 200 status code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("[POST] : api/v1/createcustomer : while mobile number as string. It shold be bad r" +
            "equest", new string[] {
                "negative"}, SourceLine=20)]
        public virtual void POSTApiV1CreatecustomerWhileMobileNumberAsString_ItSholdBeBadRequest()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[POST] : api/v1/createcustomer : while mobile number as string. It shold be bad r" +
                    "equest", new string[] {
                        "negative"});
#line 21
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "FirstName",
                        "LastName",
                        "Email",
                        "Password",
                        "Mobile"});
            table2.AddRow(new string[] {
                        "Pramod",
                        "Swami",
                        "pramod.swami@gmail.com",
                        "Pass$#123",
                        "hfhf133"});
#line 22
 testRunner.Given("I have entered customer contract object", ((string)(null)), table2, "Given ");
#line 25
 testRunner.When("I request createcustomer endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 26
 testRunner.Then("the result should be false on the screen with 400 status code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("[POST] : api/v1/updatecustomer", new string[] {
                "customers"}, SourceLine=28)]
        public virtual void POSTApiV1Updatecustomer()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[POST] : api/v1/updatecustomer", new string[] {
                        "customers"});
#line 29
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "FirstName",
                        "LastName",
                        "Email",
                        "Password",
                        "Mobile",
                        "CustomerId"});
            table3.AddRow(new string[] {
                        "Sarita",
                        "Swami",
                        "pramod.swami@gmail.com",
                        "Pass$#123",
                        "9890765456",
                        "34"});
#line 30
 testRunner.Given("I have entered customer contract object", ((string)(null)), table3, "Given ");
#line 33
 testRunner.When("I request updatecustomer endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
 testRunner.Then("the multiple result should be true on the screen with 200 status code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("[GET] : api/v1/getcustomerbyemail?email=trupt_jundale@gmail.com", new string[] {
                "customer"}, SourceLine=36)]
        public virtual void GETApiV1GetcustomerbyemailEmailTrupt_JundaleGmail_Com()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[GET] : api/v1/getcustomerbyemail?email=trupt_jundale@gmail.com", new string[] {
                        "customer"});
#line 37
this.ScenarioSetup(scenarioInfo);
#line 38
 testRunner.Given("I have entered email trupt_jundale@gmail.com", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
 testRunner.When("I request getcustomerbemail endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
 testRunner.Then("the result must be customer details on the screen with 200 status code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("[GET]: api/v1/validatecredentialbyemailandpassword?email=tryambak05@gmail.com&pas" +
            "sword=abc@123", new string[] {
                "customer"}, SourceLine=42)]
        public virtual void GETApiV1ValidatecredentialbyemailandpasswordEmailTryambak05Gmail_ComPasswordAbc123()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[GET]: api/v1/validatecredentialbyemailandpassword?email=tryambak05@gmail.com&pas" +
                    "sword=abc@123", new string[] {
                        "customer"});
#line 43
this.ScenarioSetup(scenarioInfo);
#line 44
 testRunner.Given("i have entered email tryambak05@gmail.com and password abc@123", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 45
 testRunner.When("I request validatecredentialbyemailandpassword endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 46
 testRunner.Then("the result shows status code 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.TestRunCleanup()]
        public virtual void TestRunCleanup()
        {
            TechTalk.SpecFlow.TestRunnerManager.GetTestRunner().OnTestRunEnd();
        }
    }
}
#pragma warning restore
#endregion


