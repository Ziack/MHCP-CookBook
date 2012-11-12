using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using SharpArch.Domain.DomainModel;

namespace MHCP.Domain.BoundedContexts.APR
{
    public class Person : Entity
    {
        [Required]
        [StringLength(160)]        
        virtual public string FirstName { get; set; }

        [StringLength(160)]
        [Required]
        virtual public string LastName { get; set; }

        [Range(35, 44)]
        virtual public int Age { get; set; }

        [RegularExpression(@"\d{5}(-\d{4})?")]
        virtual public string PostalCode { get; set; }       
    }
}
