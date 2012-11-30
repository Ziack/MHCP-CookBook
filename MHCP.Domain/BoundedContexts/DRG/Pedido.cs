using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace MHCP.Domain.BoundedContexts.DRG
{
    public class Pedido : Entity
    {
        public virtual int NumeroPedido { get; set; }

        public virtual DateTime FechaPedido { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual IList<Articulo> Articulos { get; set; }
    }
}
