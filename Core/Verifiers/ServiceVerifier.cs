using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;

namespace Core
{
    public class ServiceVerifier : AbstractResourceVerifier
    {
        ServiceController[] services;

        public ServiceVerifier() : base()
        {
            services = ServiceController.GetServices();
        }

        protected override ResultType Verify(Tuple<string, string> tuple)
        {
            ServiceController service = services.FirstOrDefault(x => x.ServiceName == tuple.Item2);
            return service != null && service.Status == ServiceControllerStatus.Running ? ResultType.Success : ResultType.Failure;
        }

        protected override string ConstructMessage(Tuple<string, string> tuple, ResultType resultType)
        {
            return string.Format("{0} connecting to {1}, connection string : {2}", resultType.ToString(), tuple.Item1, tuple.Item2);
        }
    }
}