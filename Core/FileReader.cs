using System;
using System.IO;

namespace Core
{
    public class FileReader : IFileReader
    {
        private string _filePath;

        public FileReader(string filePath)
        {
            _filePath = filePath;
        }

        public ValidationResult Validate()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    return new ValidationResult { Message = "The file does not exist", Type = ResultType.Failure };
                }

                using (TextReader reader = File.OpenText(_filePath))
                {
                    string text = reader.ReadToEnd();
                    return new ValidationResult {Type = ResultType.Success, Message = text};
                }
            }
            catch(Exception e)
            {
                return new ValidationResult {Message = e.Message, Type = ResultType.Failure};
            }
        }
    }

    public interface IFileReader
    {
        ValidationResult Validate();
    }
}