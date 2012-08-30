using System;
using System.Linq;
using Core;
using Ninject;
using Ninject.Parameters;
using NLog;

namespace ConsoleClient
{
    class Program
    {
        [Inject]
        public ILog Logger { get; set; }

        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();

            // Container Register
            kernel.Bind<ILog>().ToMethod(
                x =>
                    {
                        var scope = x.Request.ParentRequest.Service.FullName;
                        var log = (ILog)LogManager.GetLogger(scope, typeof(Log));
                        return log;
                    });
            kernel.Bind<IParser>().To<FileParser>();
            kernel.Bind<IResourceItemParser<string>>().To<JsonResourceItemParser>();
            kernel.Bind<IVerificationProcessor<string>>().To<VerificationProcessor<string>>()
                .WithConstructorArgument("factory", new StringTypeResourceVerifierFactory());
            kernel.Bind<IVerificationInvoker>().To<CompositeVerifier<string>>();
            
            // Container Resolve
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

            // Container Release
            kernel.Release(invoker);
            kernel.Release(processor);
            kernel.Release(parser);
            kernel.Release(fileReader);
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
