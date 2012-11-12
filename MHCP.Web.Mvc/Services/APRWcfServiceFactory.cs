using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MHCP.Services.Wcf.BoundedContexts.APR.Contracts;
using MHCP.Services.Wcf.Client.APR;
using System.ServiceModel;
using System.Configuration;

namespace MHCP.Web.Mvc.Services
{
    public class APRWcfServiceFactory
    {
        public static IAPRWcfService Create()
        {
            EndpointAddress address = new EndpointAddress(ConfigurationManager.AppSettings["IAPRWcfServiceUri"]);
            NetTcpBinding binding = new NetTcpBinding();
            return new APRWcfServiceClient(binding, address);
        }
    }
}