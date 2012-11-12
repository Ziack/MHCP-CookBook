using SharpArch.Domain.PersistenceSupport;
using SharpArch.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain;

namespace MHCP.Tasks.Seedwork
{
    public abstract class Tasks<T> : NHibernateQuery
    {
        protected readonly T repository;

        public Tasks(T repository)
        {
            Check.Require(repository != null, "{0} may not be null");
            this.repository = repository;
        }
    }
}
