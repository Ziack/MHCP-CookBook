using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace MHCP.Domain.BoundedContexts.DRG
{
    public class Articulo : Entity
    {
        public virtual string Nombre { get; set; }

        public virtual float Valor { get; set; }
    }
}
