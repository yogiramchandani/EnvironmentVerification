using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Core
{
    public class JsonResourceItemParser : AbstractParser, IResourceItemParser<string, string>
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

        public override VerificationResult Execute()
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

        public override string ConstructExceptionMessage(Exception e)
        {
            return string.Format("{0}: Error in class (JsonResourceItemParser) while parsing Json content, the exception thrown : {1}", ResultType.Failure, e.Message);
        }
    }
}