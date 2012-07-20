using System;
using System.Collections.Generic;
using System.Linq;
using Core;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileReader = new FileParser(args.First());
            var result = new List<VerificationResult>();
            var parser = new JsonResourceItemParser();

            VerificationResult validationResult = fileReader.Parse();

            if (validationResult.Type == ResultType.Success)
            {   
                validationResult = parser.ParseResourceItems(validationResult.Message);
            }
            if (validationResult.Type == ResultType.Success)
            {
                List<IResourceItem<string>> resourceList = parser.ResourceList;
                var processor = new VerificationProcessor<string>(new StringTypeResourceVerifierFactory());
                processor.AddResourceItems(resourceList);
                result = processor.ProcessResources();
            }
            if (validationResult.Type != ResultType.Success)
            {
                result.Add(validationResult);
            }

            foreach (VerificationResult verificationResult in result)
            {
                Console.ForegroundColor = GetColour(verificationResult.Type);
                Console.WriteLine(string.Format("{0}", verificationResult.Message));
                Console.ResetColor();
            }

            Console.WriteLine("Done ...");
            Console.ReadKey();
        }

        private static ConsoleColor GetColour(ResultType actual)
        {
            ConsoleColor colour = ConsoleColor.White;
            if (actual == ResultType.Failure)
            {
                colour = ConsoleColor.Red;
            }
            if (actual == ResultType.Success)
            {
                colour = ConsoleColor.Green;
            }
            if (actual == ResultType.Info)
            {
                colour = ConsoleColor.Cyan;
            }
            if (actual == ResultType.Warning)
            {
                colour = ConsoleColor.Yellow;
            }
            return colour;
        }
    }
}
