namespace MHCP.Tasks.Seedwork
{
    using System.Collections.Generic;
    using System.Linq;
    using SharpArch.Domain.PersistenceSupport;

    public class DaoTasks<T, TId>
    {
        private readonly IRepositoryWithTypedId <T,TId> repository;

        public DaoTasks(IRepositoryWithTypedId<T, TId> repository)
        {
            this.repository = repository;
        }

        public List<T> GetAll()
        {
            return this.repository.GetAll().ToList();
        }

        public T Get(TId id)
        {
            return this.repository.Get(id);
        }

        public T CreateOrUpdate(T entity)
        {
            this.repository.SaveOrUpdate(entity);
            return entity;
        }

        public void Delete(TId id)
        {
            T entity = this.repository.Get(id);
            this.repository.Delete(entity);
        }
    }
}
