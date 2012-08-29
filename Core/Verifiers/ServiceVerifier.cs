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
        private string ServiceStatus = "ServiceStatus";

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

            string serviceStatus;
            if (!tuple.Item2.TryGetValue(ServiceStatus, out serviceStatus))
            {
                return new VerificationResult { Type = ResultType.Failure, Message = string.Format("Key {0} not found", ServiceStatus) };
            }

            ServiceControllerStatus status;
            if (!Enum.TryParse(serviceStatus, true, out status))
            {
                return new VerificationResult { Type = ResultType.Failure, Message = string.Format("Service controller status {0} is not a valid ServiceControllerStatus type enum", serviceStatus) };
            }

            ServiceController service = services.FirstOrDefault(x => x.ServiceName == serviceName && x.Status == status);

            return service != null
                ? new VerificationResult { Type = ResultType.Success }
                : new VerificationResult { Type = ResultType.Failure, Message = "Service not found" };
        }
    }
}