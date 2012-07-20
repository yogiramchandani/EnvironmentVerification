using System;
using System.IO;

namespace Core
{
    public class FileParser : AbstractParser<Exception>
    {
        private string _filePath;

        public FileParser(string filePath)
        {
            _filePath = filePath;
        }

        protected override VerificationResult Execute()
        {
            if (!File.Exists(_filePath))
            {
                return new VerificationResult { Message = "The file does not exist", Type = ResultType.Failure };
            }

            using (TextReader reader = File.OpenText(_filePath))
            {
                string text = reader.ReadToEnd();
                text = text.RemoveEscapeChars();
                return new VerificationResult { Type = ResultType.Success, Message = text };
            }
        }

        protected override string ConstructExceptionMessage(Exception e)
        {
            return string.Format("{0}: Error while parsing the file {1}, the exception thrown : {2}", ResultType.Failure, _filePath, e.Message);
        }
    }
}