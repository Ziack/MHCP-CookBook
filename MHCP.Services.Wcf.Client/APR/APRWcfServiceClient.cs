﻿using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using MHCP.Services.Wcf.BoundedContexts.APR.Contracts;
using MHCP.Domain.BoundedContexts.APR;

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

        public IList<Person> GetPersonsByAge(int age)
        {
            return this.Channel.GetPersonsByAge(age);
        }
}
}
