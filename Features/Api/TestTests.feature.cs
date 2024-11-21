﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:2.0.0.0
//      Reqnroll Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace EnsekTechnicalTest.Features.Api
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Test Tests")]
    public partial class TestTestsFeature
    {
        
        private global::Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private static global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Api", "Test Tests", "The actual tests I\'m required to do for the assessment", global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
        
#line 1 "TestTests.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public static async System.Threading.Tasks.Task FeatureSetupAsync()
        {
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public static async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public async System.Threading.Tasks.Task TestInitializeAsync()
        {
            testRunner = global::Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(featureHint: featureInfo);
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Equals(featureInfo) == false)))
            {
                await testRunner.OnFeatureEndAsync();
            }
            if ((testRunner.FeatureContext == null))
            {
                await testRunner.OnFeatureStartAsync(featureInfo);
            }
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
            global::Reqnroll.TestRunnerManager.ReleaseTestRunner(testRunner);
        }
        
        public void ScenarioInitialize(global::Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        public virtual async System.Threading.Tasks.Task FeatureBackgroundAsync()
        {
#line 4
#line hidden
#line 5
 await testRunner.GivenAsync("the user has logged in and received a valid authorisation token", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User resets the test data")]
        public async System.Threading.Tasks.Task UserResetsTheTestData()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("User resets the test data", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 7
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 4
await this.FeatureBackgroundAsync();
#line hidden
#line 8
 await testRunner.WhenAsync("the user sends a Reset request with a valid authorisation token", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 9
 await testRunner.ThenAsync("the system will return a 200 Success response for the Reset request", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 10
  await testRunner.AndAsync("only the default Energy supply data will be present", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 11
  await testRunner.AndAsync("only the default Order data will be present", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User buys a quantity of each fuel and confirms the number of orders created befor" +
            "e the current date")]
        public async System.Threading.Tasks.Task UserBuysAQuantityOfEachFuelAndConfirmsTheNumberOfOrdersCreatedBeforeTheCurrentDate()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("User buys a quantity of each fuel and confirms the number of orders created befor" +
                    "e the current date", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 13
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 4
await this.FeatureBackgroundAsync();
#line hidden
#line 14
 await testRunner.GivenAsync("the user has reset the test data", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 15
 await testRunner.WhenAsync("the user successfully buys 40 units of Electric", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 16
  await testRunner.AndAsync("the user successfully buys 30 units of Gas", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 17
  await testRunner.AndAsync("the user successfully buys 20 units of Nuclear", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 18
  await testRunner.AndAsync("the user successfully buys 10 units of Oil", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 19
 await testRunner.ThenAsync("the Orders list will display all the newly created orders", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 20
  await testRunner.AndAsync("there will be 5 orders created before the current date", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User buys a quantity of each fuel except nuclear and confirms the number of order" +
            "s created before the current date")]
        public async System.Threading.Tasks.Task UserBuysAQuantityOfEachFuelExceptNuclearAndConfirmsTheNumberOfOrdersCreatedBeforeTheCurrentDate()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("User buys a quantity of each fuel except nuclear and confirms the number of order" +
                    "s created before the current date", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 22
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 4
await this.FeatureBackgroundAsync();
#line hidden
#line 23
 await testRunner.GivenAsync("the user has reset the test data", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 24
 await testRunner.WhenAsync("the user successfully buys 40 units of Electric", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 25
  await testRunner.AndAsync("the user successfully buys 30 units of Gas", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 26
  await testRunner.AndAsync("the user successfully buys 10 units of Oil", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 27
 await testRunner.ThenAsync("the Orders list will display all the newly created orders", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 28
  await testRunner.AndAsync("there will be 5 orders created before the current date", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
    }
}
#pragma warning restore
#endregion