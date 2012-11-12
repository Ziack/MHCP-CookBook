using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.PersistenceSupport;

namespace MHCP.Domain.BoundedContexts.APR.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        IList<Person> GetPersonsByAge(int age);
    }
}
