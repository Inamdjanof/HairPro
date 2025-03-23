using HairPros.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HairPros.Core.Entities
{
    public class BarberShop : BaseEntity , IAuditedEntity
    {
        public string Name { get; set; } = string.Empty;
        public Guid ResponsibleBarberId { get; set; }
        public string Location { get; set; } = string.Empty;
        public string DocumentPath { get; set; } = string.Empty;
        public ICollection<Barber> Barbers { get; set; } = new List<Barber>();

        // Audit
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
