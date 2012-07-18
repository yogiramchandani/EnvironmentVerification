using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;

namespace Core
{
    public class ServiceVerifier : ResourceVerifier
    {
        ServiceController[] services;

        public ServiceVerifier() : base()
        {
            services = ServiceController.GetServices();
        }

        protected override bool Verify(Tuple<string, string> tuple)
        {
            ServiceController service = services.FirstOrDefault(x => x.ServiceName == tuple.Item2);
            return service != null && service.Status == ServiceControllerStatus.Running;
        }

        protected override string ConstructMessage(Tuple<string, string> tuple, bool canConnect)
        {
            return string.Format("{0} connecting to {1}, connection string : {2}", canConnect ? "Passed" : "Failed", tuple.Item1, tuple.Item2);
        }
    }
}