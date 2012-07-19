using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Core.SpecFlow
{
    [Binding]
    public class EnvironmentVerificationProcessSteps
    {
        private EnvironmentVerificationProcessor<string> _processor;

        [Given("I have a new EnvironmentVerificationProcessor")]
        public void GivenIHaveANewEnvironmentVerificationProcessor()
        {
            _processor = new EnvironmentVerificationProcessor<string>(new TypeStringResourceVerifierFactory());
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
            var expected = new List<VerificationResult>(items.RowCount);
            expected.AddRange(items.Rows.Select(row => new VerificationResult {CanConnect = bool.Parse(row["canConnect"]), Message = row["message"]}));

            var actual = _processor.ProcessResources();

            Assert.AreEqual(actual.Count(x => x.CanConnect), expected.Count(x => x.CanConnect));
            Assert.AreEqual(actual.Count(x => !x.CanConnect), expected.Count(x => !x.CanConnect));
        }


        [Then("the Environment Verification Processor result count should be (.*)")]
        public void ThenTheResultCountShouldBe(int result)
        {
            var actual = _processor.ProcessResources().Count;
            Assert.AreEqual(actual, result);
        }
    }
}
