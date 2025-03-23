using HairPros.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPros.Core.Entities
{
    public class BarberService : BaseEntity, IAuditedEntity
    {
        public Guid BarberId { get; set; }
        public Guid ServiceId { get; set; }
        public decimal Price { get; set; }

        public Barber Barber { get; set; }
        public Service Service { get; set; }

        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedOn { get; set; }
    }
}
