using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MHCP.Services.Wcf.BoundedContexts.APR.Contracts;
using MHCP.Domain.BoundedContexts.APR.Contracts.Tasks;
using SharpArch.Domain;
using MHCP.Services.Dtos.BoundedContexts.APR;
using System.ServiceModel;

namespace MHCP.Services.Wcf.BoundedContexts.APR
{
    public class APRWcfService: IAPRWcfService
    {
        private readonly IPersonTasks personTask;

        public APRWcfService(IPersonTasks personTask)
        {
            Check.Require(personTask != null, "personTask may not be null");
            this.personTask = personTask;
        }

        public void Abort()
        {
        }

        public void Close()
        {
        }

        
        public IList<PersonDTO> GetPersonsByAge(int age)
        {
            this.personTask.GetPersonsByAge(age);
            return new List<PersonDTO>();
        }
    }
}
