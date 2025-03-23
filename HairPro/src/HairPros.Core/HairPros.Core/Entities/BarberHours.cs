using HairPros.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPros.Core.Entities
{

    public class BarberHours : BaseEntity, IAuditedEntity
    {
        public Guid BarberId { get; set; }
        public DayOfWeek DayOfWeek { get; set; } // Haftaning qaysi kuni
        public TimeSpan OpenTime { get; set; } // Ish boshlash vaqti
        public TimeSpan CloseTime { get; set; } // Ish tugash vaqti

        public Barber Barber { get; set; }

        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedOn { get; set; }
    }



}
