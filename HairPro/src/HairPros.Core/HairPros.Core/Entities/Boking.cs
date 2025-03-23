using HairPros.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPros.Core.Entities
{
    public class Booking : BaseEntity, IAuditedEntity
    {
        public Guid OrderId { get; set; }
        public Guid BarberServiceId { get; set; }
        public TimeSpan BookingTime { get; set; }
        public bool IsConfirmed { get; set; }

        public Order Order { get; set; }
        public BarberService BarberService { get; set; }

        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedOn { get; set; }
    }

}
