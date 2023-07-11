using PruebaTecnicaAPI_SuperIntendenciaDeBancos.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaAPI_SuperIntendenciaDeBancos.Core.Domain.Entities
{
    public class Product : EntityAuditableBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }

        // Navigation Prop
        public Category Category { get; set; }
    }
}
