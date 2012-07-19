using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Core.SpecFlow
{
    [Binding]
    public class ProcessVerificationItemsSteps
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

    public class EnvironmentVerificationProcessor<T>
    {
        private List<IResourceItem<T>> _resourceItems;
        private IResourceVerifierFactory<T> _factory;

        public EnvironmentVerificationProcessor(IResourceVerifierFactory<T> factory)
        {
            _factory = factory;
            _resourceItems = new List<IResourceItem<T>>();
        }

        public void AddResourceItems(List<IResourceItem<T>> resourceItems)
        {
            _resourceItems.AddRange(resourceItems);
        }

        public List<VerificationResult> ProcessResources()
        {
            var resourceVerifiers = new Dictionary<T, IResourceVerifier>();
            foreach (IResourceItem<T> item in _resourceItems)
            {
                IResourceVerifier verifier;
                if (!resourceVerifiers.TryGetValue(item.ItemType, out verifier))
                {
                    verifier = _factory.GetVerifier(item.ItemType);
                    resourceVerifiers.Add(item.ItemType, verifier);
                }
                verifier.AddConnectionToVerify(item.Identifier, item.Location);
            }

            var result = new List<VerificationResult>();
            resourceVerifiers.Values.ToList().ForEach(x => result.AddRange(x.GetVerificationStatus()));

            return result;
        }
    }

    public class TypeStringResourceVerifierFactory : IResourceVerifierFactory<string>
    {
        public IResourceVerifier GetVerifier(string type)
        {
            if (type == "File")
            {
                return new FileVerifier();
            }
            if (type == "Directory")
            {
                return new DirectoryVerifier();
            }
            if (type == "Database")
            {
                return new DatabaseVerifier();
            }
            if (type == "WindowsService")
            {
                return new ServiceVerifier();
            }
            return new UnknownVerifier();
        }
    }

    public class UnknownVerifier : ResourceVerifier
    {
        protected override bool Verify(Tuple<string, string> tuple)
        {
            return false;
        }

        protected override string ConstructMessage(Tuple<string, string> tuple, bool canConnect)
        {
            return string.Format("Failed, Could not find a valid verifier for name: {0}, location: {1}", tuple.Item1, tuple.Item2);
        }
    }

    public interface IResourceVerifierFactory<in T>
    {
        IResourceVerifier GetVerifier(T type);
    }

    public class ResourceItem : IResourceItem<string>
    {
        public string ItemType { get; set; }
        public string Identifier { get; set; }
        public string Location { get; set; }
    }

    public interface IResourceItem<T>
    {
        T ItemType { get; set; }
        string Identifier { get; set; }
        string Location { get; set; }
    }
}
