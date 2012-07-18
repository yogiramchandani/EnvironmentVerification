using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;

namespace Core
{
    public class ServiceVerifier : IResourceVerifier
    {
        private IList<Tuple<string, string>> serviceConnectionList;

        public ServiceVerifier()
        {
            serviceConnectionList = new List<Tuple<string, string>>();
        }

        public void AddConnectionToVerify(string key, string connection)
        {
            serviceConnectionList.Add(new Tuple<string, string>(key, connection));
        }

        public List<VerificationResult> GetVerificationStatus()
        {
            List<VerificationResult> result = new List<VerificationResult>();
            bool canConnect = false;

            ServiceController[] services;
            services = ServiceController.GetServices();

            foreach (Tuple<string, string> tuple in serviceConnectionList)
            {
                ServiceController service = services.FirstOrDefault(x => x.ServiceName == tuple.Item2);
                if (service != null && service.Status == ServiceControllerStatus.Running)
                {
                    canConnect = true;
                }
                string message = string.Format("{0} connecting to {1}, connection string : {2}", canConnect ? "Passed" : "Failed", tuple.Item1, tuple.Item2);
                result.Add(new VerificationResult { CanConnect = canConnect, Message = message });

                canConnect = false;
            }

            return result;
        }
    }
}