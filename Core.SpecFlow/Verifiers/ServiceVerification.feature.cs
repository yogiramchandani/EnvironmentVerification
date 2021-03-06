﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.8.1.0
//      SpecFlow Generator Version:1.8.0.0
//      Runtime Version:4.0.30319.269
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Core.SpecFlow.Verifiers
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.8.1.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Service Verfication")]
    public partial class ServiceVerficationFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ServiceVerification.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Service Verfication", "In order to verify if a service exists in a system\r\nAs a system user\r\nI want to b" +
                    "e told if the service exists", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
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
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("For an existing service, check the result message")]
        public virtual void ForAnExistingServiceCheckTheResultMessage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("For an existing service, check the result message", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("I have a new ServiceVerifier");
#line 8
 testRunner.When("I add a service with status, connection name: DHCP Service, connection: Dhcp, sta" +
                    "tus: Running");
#line 9
 testRunner.Then("the result message should be Success verifying DHCP Service, Key: ServiceName, Va" +
                    "lue: DhcpKey: ServiceStatus, Value: Running");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("For an existing service, check the result type")]
        public virtual void ForAnExistingServiceCheckTheResultType()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("For an existing service, check the result type", ((string[])(null)));
#line 11
this.ScenarioSetup(scenarioInfo);
#line 12
 testRunner.Given("I have a new ServiceVerifier");
#line 13
 testRunner.When("I add a service with status, connection name: DHCP Service, connection: Dhcp, sta" +
                    "tus: Running");
#line 14
 testRunner.Then("the result status should be Success");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("For an existing service, check the result count")]
        public virtual void ForAnExistingServiceCheckTheResultCount()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("For an existing service, check the result count", ((string[])(null)));
#line 16
this.ScenarioSetup(scenarioInfo);
#line 17
 testRunner.Given("I have a new ServiceVerifier");
#line 18
 testRunner.When("I add a service with status, connection name: Levy WCF Service, connection: PPF.L" +
                    "evy.WCFHost, status: Running");
#line 19
 testRunner.Then("the result count should be 1");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("For a non existent service, check the result message")]
        public virtual void ForANonExistentServiceCheckTheResultMessage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("For a non existent service, check the result message", ((string[])(null)));
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
 testRunner.Given("I have a new ServiceVerifier");
#line 23
 testRunner.When("I add a service with status, connection name: Invalid Service, connection: PPF.Le" +
                    "vy.Invalid, status: Running");
#line 24
 testRunner.Then("the result message should be Failure verifying Invalid Service, Error Message: Se" +
                    "rvice not found, Key: ServiceName, Value: PPF.Levy.InvalidKey: ServiceStatus, Va" +
                    "lue: Running");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("For a non existent service, check the result type")]
        public virtual void ForANonExistentServiceCheckTheResultType()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("For a non existent service, check the result type", ((string[])(null)));
#line 26
this.ScenarioSetup(scenarioInfo);
#line 27
 testRunner.Given("I have a new ServiceVerifier");
#line 28
 testRunner.When("I add a service with status, connection name: Invalid Service, connection: PPF.Le" +
                    "vy.Invalid, status: Running");
#line 29
 testRunner.Then("the result status should be Failure");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("For a non existent service, check the result count")]
        public virtual void ForANonExistentServiceCheckTheResultCount()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("For a non existent service, check the result count", ((string[])(null)));
#line 31
this.ScenarioSetup(scenarioInfo);
#line 32
 testRunner.Given("I have a new ServiceVerifier");
#line 33
 testRunner.When("I add a service with status, connection name: Invalid Service, connection: PPF.Le" +
                    "vy.Invalid, status: Running");
#line 34
 testRunner.Then("the result count should be 1");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("3 services are added, check the result count")]
        public virtual void _3ServicesAreAddedCheckTheResultCount()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("3 services are added, check the result count", ((string[])(null)));
#line 36
this.ScenarioSetup(scenarioInfo);
#line 37
 testRunner.Given("I have a new ServiceVerifier");
#line 38
 testRunner.When("I add a service with status, connection name: Levy WCF Service, connection: PPF.L" +
                    "evy.WCFHost, status: Running");
#line 39
 testRunner.When("I add a service with status, connection name: Invalid Service, connection: PPF.Le" +
                    "vy.Invalid, status: Running");
#line 40
 testRunner.When("I add a service connection name: Invalid Service, connection: PPF.Levy.Invalid");
#line 41
 testRunner.Then("the result count should be 3");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
