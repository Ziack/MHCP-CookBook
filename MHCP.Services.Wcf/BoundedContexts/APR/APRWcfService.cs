using System.Collections.Generic;
using MHCP.Services.Wcf.BoundedContexts.APR.Contracts;
using MHCP.Domain.BoundedContexts.APR.Contracts.Tasks;
using SharpArch.Domain;
using MHCP.Domain.BoundedContexts.APR;

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

        
        public IList<Person> GetPersonsByAge(int age)
        {
            return this.personTask.GetPersonsByAge(age);
            
        }
    }
}
