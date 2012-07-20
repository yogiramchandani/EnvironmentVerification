using System;
using System.IO;

namespace Core
{
    public class FileParser : AbstractParser
    {
        private string _filePath;

        public FileParser(string filePath)
        {
            _filePath = filePath;
        }

        public override VerificationResult Execute()
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

        public override string ConstructExceptionMessage(Exception e)
        {
            return string.Format("{0}: Error while parsing the file {1}, the exception thrown : {2}", ResultType.Failure, _filePath, e.Message);
        }
    }

    public interface IParser
    {
        VerificationResult Parse();
    }
}