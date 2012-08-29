using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Core.SpecFlow
{
    [Binding]
    public class VerificationProcessSteps : AbstractSteps<VerificationProcessor<string>>
    {
        [Given("I have a new EnvironmentVerificationProcessor")]
        public void GivenIHaveANewEnvironmentVerificationProcessor()
        {
            Context = new VerificationProcessor<string>(new StringTypeResourceVerifierFactory());
        }

        [When("I add items for processing")]
        public void WhenIAddItemsForProcessing(Table items)
        {
            foreach (var row in items.Rows)
            {
                var actions = new Dictionary<string, string> {{row["key"], row["value"]}};
                if (row.ContainsKey("key1") && !string.IsNullOrEmpty(row["key1"]))
                {
                    actions.Add(row["key1"], row["value1"]);
                }
                Context.AddResourceItems(new List<IResourceItem<string>>
                                                {
                                                    new ResourceItem
                                                        {
                                                            ItemType = row["type"],
                                                            Identifier = row["name"],
                                                            Actions = actions
                                                        }
                                                });
            }
        }

        [Then("the Environment Verification Processor result should be")]
        public void ThenTheResultShouldBe(Table items)
        {
            var expected = new List<VerificationResult>(items.CreateSet<VerificationResult>());
            var actual = Context.ProcessResources();

            Assert.AreEqual(expected.Count(x => x.Type == ResultType.Success), actual.Count(x => x.Type == ResultType.Success));
            Assert.AreEqual(expected.Count(x => x.Type == ResultType.Failure), actual.Count(x => x.Type == ResultType.Failure));
        }


        [Then("the Environment Verification Processor result count should be (.*)")]
        public void ThenTheResultCountShouldBe(int result)
        {
            var actual = Context.ProcessResources().Count;
            Assert.AreEqual(actual, result);
        }
    }
}
