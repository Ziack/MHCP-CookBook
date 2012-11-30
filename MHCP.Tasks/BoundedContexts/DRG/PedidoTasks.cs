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
        public PedidoTasks(IPedidoRepository repository) : base(repository) { }

        public Domain.BoundedContexts.DRG.Pedido CreateOrUpdate(Domain.BoundedContexts.DRG.Pedido Entity)
        {
            return repository.SaveOrUpdate(Entity);
        }
    }
}
