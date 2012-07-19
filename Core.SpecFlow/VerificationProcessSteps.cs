﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Core.SpecFlow
{
    [Binding]
    public class VerificationProcessSteps
    {
        private VerificationProcessor<string> _processor;

        [Given("I have a new EnvironmentVerificationProcessor")]
        public void GivenIHaveANewEnvironmentVerificationProcessor()
        {
            _processor = new VerificationProcessor<string>(new StringTypeResourceVerifierFactory());
        }

        [When("I add items for processing")]
        public void WhenIAddItemsForProcessing(Table items)
        {

            foreach (var row in items.Rows)
            {
                _processor.AddResourceItems(new List<IResourceItem<string>>
                                                {
                                                    new ResourceItem
                                                        {
                                                            ItemType = row["type"],
                                                            Identifier = row["name"],
                                                            Location = row["location"]
                                                        }
                                                });
            }
        }

        [Then("the Environment Verification Processor result should be")]
        public void ThenTheResultShouldBe(Table items)
        {
            var expected = new List<VerificationResult>(items.CreateSet<VerificationResult>());
            var actual = _processor.ProcessResources();

            Assert.AreEqual(actual.Count(x => x.Type == ResultType.Success), expected.Count(x => x.Type == ResultType.Success));
            Assert.AreEqual(actual.Count(x => x.Type == ResultType.Failure), expected.Count(x => x.Type == ResultType.Failure));
        }


        [Then("the Environment Verification Processor result count should be (.*)")]
        public void ThenTheResultCountShouldBe(int result)
        {
            var actual = _processor.ProcessResources().Count;
            Assert.AreEqual(actual, result);
        }
    }
}