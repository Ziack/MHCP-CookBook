using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MHCP.Domain.BoundedContexts.APR.Contracts.Tasks
{
    public interface IPersonTasks
    {
        IList<Person> GetPersonsByAge(int age);
    }
}
