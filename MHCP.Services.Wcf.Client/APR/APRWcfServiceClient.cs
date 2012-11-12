using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using MHCP.Services.Wcf.BoundedContexts.APR.Contracts;
using MHCP.Services.Dtos.BoundedContexts.APR;

namespace MHCP.Services.Wcf.Client.APR
{
    public class APRWcfServiceClient : ClientBase<IAPRWcfService>, IAPRWcfService
    {
         public APRWcfServiceClient()
        {
        }

        public APRWcfServiceClient(string endpointName)
            : base(endpointName)
        {
        }

        public APRWcfServiceClient(Binding binding, EndpointAddress address)
            : base(binding, address)
        {
        }

        public IList<PersonDTO> GetPersonsByAge(int age)
        {
            return this.Channel.GetPersonsByAge(age);
        }
}
}
