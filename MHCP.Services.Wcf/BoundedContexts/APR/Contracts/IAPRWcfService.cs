using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using SharpArch.Wcf;
using MHCP.Services.Dtos.BoundedContexts.APR;
using MHCP.Domain.BoundedContexts.APR;

namespace MHCP.Services.Wcf.BoundedContexts.APR.Contracts
{
    [ServiceContract]    
    public interface IAPRWcfService : ICloseableAndAbortable
    {

        [OperationContract]
        IList<Person> GetPersonsByAge(int age);
    }
}
