using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MHCP.Domain.BoundedContexts.DRG
{
    public class Domicilio
    {
        public virtual Pedido Pedido { get; set; }
        public virtual bool Entregado { get; set; }
    }
}
