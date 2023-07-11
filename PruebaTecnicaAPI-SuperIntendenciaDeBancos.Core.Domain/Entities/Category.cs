using PruebaTecnicaAPI_SuperIntendenciaDeBancos.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaAPI_SuperIntendenciaDeBancos.Core.Domain.Entities
{
    public class Category : EntityAuditableBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation Prop
        public ICollection<Product> Products { get; set; }
    }
}
