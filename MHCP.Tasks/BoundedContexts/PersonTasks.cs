using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MHCP.Tasks.Seedwork;
using MHCP.Domain.BoundedContexts.APR;
using MHCP.Domain.BoundedContexts.APR.Contracts.Tasks;
using SharpArch.Domain.PersistenceSupport;
using MHCP.Domain.BoundedContexts.APR.Repositories;
using SharpArch.Domain;

namespace MHCP.Tasks.BoundedContexts
{
    public class PersonTasks : Tasks<IPersonRepository>, IPersonTasks
    {
        public PersonTasks(IPersonRepository personRepository) : base(personRepository) {}

        public IList<Person> GetPersonsByAge(int age)
        {
            return this.repository.GetPersonsByAge(age);
        }
    }
}
