using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MHCP.Domain.BoundedContexts.DRG.Contracts.Tasks;
using MHCP.Domain.BoundedContexts.DRG.Repositories;

namespace MHCP.Tasks.BoundedContexts.DRG
{
    public class DomicilioTasks : IDomicilioTasks
    {
        private IDomicilioRepository _repository;

        public DomicilioTasks(IDomicilioRepository repository)
        {
            _repository = repository;
        }

        public Domain.BoundedContexts.DRG.Domicilio CreateOrUpdate(Domain.BoundedContexts.DRG.Domicilio Entity)
        {
            return _repository.SaveOrUpdate(Entity);
        }
    }
}
