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
    [NUnit.Framework.DescriptionAttribute("Database Verfication")]
    public partial class DatabaseVerficationFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "DatabaseVerification.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Database Verfication", "In order to verify if a database exists in a system\r\nAs a system user\r\nI want to " +
                    "be told if the database exists", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("For an existing database check the result string")]
        public virtual void ForAnExistingDatabaseCheckTheResultString()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("For an existing database check the result string", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("I have a new DatabaseVerifier");
#line 8
 testRunner.When("I add the DataBase connection name: Nirvana, connection: Data Source=.\\CDR;Initia" +
                    "l Catalog=nirvana_small;Integrated Security=SSPI");
#line 9
 testRunner.Then("the first result message on the screen should be Success connecting to Nirvana, c" +
                    "onnection string : Data Source=.\\CDR;Initial Catalog=nirvana_small;Integrated Se" +
                    "curity=SSPI");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("For an existing database check if result type")]
        public virtual void ForAnExistingDatabaseCheckIfResultType()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("For an existing database check if result type", ((string[])(null)));
#line 11
this.ScenarioSetup(scenarioInfo);
#line 12
 testRunner.Given("I have a new DatabaseVerifier");
#line 13
 testRunner.When("I add the DataBase connection name: Nirvana, connection: Data Source=.\\CDR;Initia" +
                    "l Catalog=nirvana_small;Integrated Security=SSPI");
#line 14
 testRunner.Then("the first result verification on the screen should be Success");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("For an existing database check the result count")]
        public virtual void ForAnExistingDatabaseCheckTheResultCount()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("For an existing database check the result count", ((string[])(null)));
#line 16
this.ScenarioSetup(scenarioInfo);
#line 17
 testRunner.Given("I have a new DatabaseVerifier");
#line 18
 testRunner.When("I add the DataBase connection name: Nirvana, connection: Data Source=.\\CDR;Initia" +
                    "l Catalog=nirvana_small;Integrated Security=SSPI");
#line 19
 testRunner.Then("the count of messages should be 1");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("For a non existent database check the result string")]
        public virtual void ForANonExistentDatabaseCheckTheResultString()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("For a non existent database check the result string", ((string[])(null)));
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
 testRunner.Given("I have a new DatabaseVerifier");
#line 23
 testRunner.When("I add the DataBase connection name: NirvanaNotExists, connection: Data Source=.\\C" +
                    "DR;Initial Catalog=nirvana_notExists;Integrated Security=SSPI");
#line 24
 testRunner.Then("the first result message on the screen should be Failure connecting to NirvanaNot" +
                    "Exists, connection string : Data Source=.\\CDR;Initial Catalog=nirvana_notExists;" +
                    "Integrated Security=SSPI");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("For a non existent database check if result type")]
        public virtual void ForANonExistentDatabaseCheckIfResultType()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("For a non existent database check if result type", ((string[])(null)));
#line 26
this.ScenarioSetup(scenarioInfo);
#line 27
 testRunner.Given("I have a new DatabaseVerifier");
#line 28
 testRunner.When("I add the DataBase connection name: NirvanaNotExists, connection: Data Source=.\\C" +
                    "DR;Initial Catalog=nirvana_notExists;Integrated Security=SSPI");
#line 29
 testRunner.Then("the first result verification on the screen should be Failure");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("For a non existent database check the result count")]
        public virtual void ForANonExistentDatabaseCheckTheResultCount()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("For a non existent database check the result count", ((string[])(null)));
#line 31
this.ScenarioSetup(scenarioInfo);
#line 32
 testRunner.Given("I have a new DatabaseVerifier");
#line 33
 testRunner.When("I add the DataBase connection name: NirvanaNotExists, connection: Data Source=.\\C" +
                    "DR;Initial Catalog=nirvana_notExists;Integrated Security=SSPI");
#line 34
 testRunner.Then("the count of messages should be 1");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("3 Database connections added check the result count")]
        public virtual void _3DatabaseConnectionsAddedCheckTheResultCount()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("3 Database connections added check the result count", ((string[])(null)));
#line 36
this.ScenarioSetup(scenarioInfo);
#line 37
 testRunner.Given("I have a new DatabaseVerifier");
#line 38
 testRunner.When("I add the DataBase connection name: Nirvana, connection: Data Source=.\\CDR;Initia" +
                    "l Catalog=nirvana_small;Integrated Security=SSPI");
#line 39
 testRunner.When("I add the DataBase connection name: Nirvana, connection: Data Source=.\\CDR;Initia" +
                    "l Catalog=nirvana_small;Integrated Security=SSPI");
#line 40
 testRunner.When("I add the DataBase connection name: NirvanaNotExists, connection: Data Source=.\\C" +
                    "DR;Initial Catalog=nirvana_notExists;Integrated Security=SSPI");
#line 41
 testRunner.Then("the count of messages should be 3");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion