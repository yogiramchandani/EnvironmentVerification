using System;
using System.Linq;
using Core;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IParser fileReader = new FileParser(args.First());
            VerificationResult validationResult = fileReader.Parse();

            IResourceItemParser<string> parser = new JsonResourceItemParser();
            IVerificationProcessor<string> processor = new VerificationProcessor<string>(new StringTypeResourceVerifierFactory());

            IVerificationInvoker invoker = new VerificationInvoker<string>(parser, processor);
            var result = invoker.VerifyEnvironment(validationResult);

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
