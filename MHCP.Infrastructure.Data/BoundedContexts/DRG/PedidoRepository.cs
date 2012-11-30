using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.NHibernate;
using MHCP.Domain.BoundedContexts.DRG;
using MHCP.Domain.BoundedContexts.DRG.Repositories;

namespace MHCP.Infrastructure.Data.BoundedContexts.DRG
{
    public class PedidoRepository : NHibernateRepository<Pedido>, IPedidoRepository
    {
    }
}
