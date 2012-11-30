using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace MHCP.Domain.BoundedContexts.DRG
{
    public class DatosContacto : ValueObject
    {
        public virtual string Direccion { get; set;  }

        public virtual double Telefono { get; set; }
    }
}
