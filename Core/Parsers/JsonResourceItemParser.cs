using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Core
{
    /// <summary>
    /// This takes a string blob and parses the Json string into a List of Resource items
    /// </summary>
    public class JsonResourceItemParser : AbstractParser<JsonException>, IResourceItemParser<string>
    {
        public List<IResourceItem<string>> ResourceList { get; set; }
        private string _content;

        public JsonResourceItemParser()
        {
            ResourceList = new List<IResourceItem<string>>();
        }

        public VerificationResult ParseResourceItems(string raw)
        {
            _content = raw;
            return Parse();
        }

        protected override VerificationResult Execute()
        {
            _content = Regex.Replace(_content,
                @"(?<!\\)  # lookbehind: Check that previous character isn't a \
                \\         # match a \
                (?!\\)     # lookahead: Check that the following character isn't a \",
                @"\\", RegexOptions.IgnorePatternWhitespace);

            var list = JsonConvert.DeserializeObject<List<ResourceItem>>(_content);
            ResourceList.AddRange(list);

            return new VerificationResult{Type = ResultType.Success};
        }

        protected override string ConstructExceptionMessage(JsonException e)
        {
            return string.Format("{0}: Error in class (JsonResourceItemParser) while parsing Json content, the exception thrown : {1}", ResultType.Failure, e.Message);
        }
    }
}