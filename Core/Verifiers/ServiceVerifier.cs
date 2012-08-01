using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;

namespace Core
{
    public class ServiceVerifier : AbstractResourceVerifier
    {
        ServiceController[] services;
        private string ServicePath = "ServiceName";

        public ServiceVerifier() : base()
        {
            services = ServiceController.GetServices();
        }

        protected override VerificationResult Verify(Tuple<string, IDictionary<string, string>> tuple)
        {
            string serviceName;
            if (!tuple.Item2.TryGetValue(ServicePath, out serviceName))
            {
                return new VerificationResult { Type = ResultType.Failure, Message = string.Format("Key {0} not found", ServicePath) };
            }

            ServiceController service = services.FirstOrDefault(x => x.ServiceName == serviceName);
            return service != null && service.Status == ServiceControllerStatus.Running 
                ? new VerificationResult { Type = ResultType.Success }
                : new VerificationResult { Type = ResultType.Failure, Message = "Service not found" };
        }
    }
}