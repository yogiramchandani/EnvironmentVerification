﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TechTalk.SpecFlow;

namespace Core.SpecFlow
{
    [Binding]
    public class JsonResourceItemProcessorSteps
    {
        JsonResourceItemProcessor _processor;

        [Given("I have a new JsonResourceItemProcessor")]
        public void GivenIHaveANewJsonResourceItemProcessor()
        {
            _processor = new JsonResourceItemProcessor();
        }

        [When("I add Json objects for processing (.*)")]
        public void WhenIAddJsonItemsForProcessing(string json)
        {
            _processor.ParseResourceItems(json);
        }

        [Then("the Json result should have a count of (.*)")]
        public void ThenTheJsonParseResultCountShouldBe(int expected)
        {
            var actual = _processor.GetResourceList();
            Assert.AreEqual(actual.Count, expected);
        }

        [Then("the Json result for type (.*) should have a count of (.*)")]
        public void ThenTheJsonParseResultTypeCountShouldBe(string type, int count)
        {
            var actual = _processor.GetResourceList();
            Assert.AreEqual(actual.Count(x => x.ItemType == type), count);
        }
    }

    public class JsonResourceItemProcessor : IResourceItemProcessor<string, string>
    {
        private List<IResourceItem<string>> _resourceList;

        public JsonResourceItemProcessor()
        {
            _resourceList = new List<IResourceItem<string>>();
        }

        public void ParseResourceItems(string json)
        {
            var list = JsonConvert.DeserializeObject<List<ResourceItem>>(json);
            _resourceList.AddRange(list);
        }

        public List<IResourceItem<string>> GetResourceList()
        {
            return _resourceList;
        }
    }

    public interface IResourceItemProcessor<TResourceType, TFormat>
    {
        void ParseResourceItems(TFormat json);
        List<IResourceItem<TResourceType>> GetResourceList();
    }
}