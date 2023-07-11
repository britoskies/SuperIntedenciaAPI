using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaAPI_SuperIntendenciaDeBancos.Core.Domain.Common
{
    public class EntityAuditableBase
    {
        public virtual int Id { get; set; }
        public string CreatedBy { get; set; } = "Uknown User";
        public DateTime Created { get; set; } 
        public string ModifiedBy { get; set; } = "Uknown User";
        public DateTime? LastModified { get; set; }
    }
}
