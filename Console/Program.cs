using System;
using System.Diagnostics;
using System.Linq;
using Core;
using NLog;
using Ninject;
using Ninject.Extensions.Logging;
using Ninject.Parameters;

namespace ConsoleClient
{
    class Program
    {
        [Inject]
        public ILogger logger { private get; set; }

        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<ILogger>().ToMethod(
                x =>
                    {
                        var scope = x.Request.ParentRequest.Service.FullName;
                        var log = (ILogger) LogManager.GetLogger(scope, typeof (Log));
                        return log;
                    });

            kernel.Bind<IParser>().To<FileParser>();
            kernel.Bind<IResourceItemParser<string>>().To<JsonResourceItemParser>();
            kernel.Bind<IVerificationProcessor<string>>().To<VerificationProcessor<string>>()
                .WithConstructorArgument("factory", new StringTypeResourceVerifierFactory());
            kernel.Bind<IVerificationInvoker>().To<CompositeVerifier<string>>();
            
            IParser fileReader = kernel.Get<IParser>(new ConstructorArgument("filePath", args.First()));
            VerificationResult jsonStringFromFile = fileReader.Parse();
            IResourceItemParser<string> parser = kernel.Get<IResourceItemParser<string>>();
            IVerificationProcessor<string> processor = kernel.Get<IVerificationProcessor<string>>();
            IVerificationInvoker invoker = kernel.Get<IVerificationInvoker>(
                                                new ConstructorArgument("parser", parser), 
                                                new ConstructorArgument("processor", processor));
            
            var result = invoker.VerifyEnvironment(jsonStringFromFile);

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
