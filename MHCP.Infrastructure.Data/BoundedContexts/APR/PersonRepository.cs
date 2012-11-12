using System.Collections.Generic;

using NHibernate.Criterion;
using NHibernate.Transform;

using SharpArch.NHibernate;

using MHCP.Domain.BoundedContexts.APR;
using MHCP.Domain.BoundedContexts.APR.Repositories;

namespace MHCP.Infrastructure.Data.BoundedContexts.APR
{
    public class PersonRepository : NHibernateRepository<Person>, IPersonRepository
    {
        public IList<Person> GetPersonsByAge(int age)
        {      
            
            var criteria =
                this.Session.CreateCriteria<Person>().Add(
                        Restrictions.Eq("Age", age)).SetResultTransformer(
                            new DistinctRootEntityResultTransformer());

            return criteria.List<Person>();
        }
    }
}
