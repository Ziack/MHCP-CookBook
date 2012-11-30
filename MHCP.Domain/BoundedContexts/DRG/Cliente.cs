using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace MHCP.Domain.BoundedContexts.DRG
{
    public class Cliente : Entity
    {
        public virtual string Nombres { get; set; }

        public virtual string Apellidos { get; set; }

        public virtual DatosContacto DatosContacto { get; set; }
    }
}
