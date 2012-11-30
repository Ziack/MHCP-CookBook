using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MHCP.Domain.BoundedContexts.DRG.Contracts.Tasks;
using MHCP.Domain.BoundedContexts.DRG.Repositories;
using MHCP.Tasks.Seedwork;

namespace MHCP.Tasks.BoundedContexts.DRG
{
    public class PedidoTasks : Tasks<IPedidoRepository>, IPedidoTasks
    {
        private IPedidoRepository _repository;

        public PedidoTasks(IPedidoRepository repository) : base(repository) { }

        public Domain.BoundedContexts.DRG.Pedido CreateOrUpdate(Domain.BoundedContexts.DRG.Pedido Entity)
        {
            return _repository.SaveOrUpdate(Entity);
        }
    }
}
