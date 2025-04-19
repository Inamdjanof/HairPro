using HairPros.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPros.Core.Entities
{
    public class BarberHours : BaseEntity
    {
        public Guid BarberId { get; set; }
        public DayOfWeek DayOfWeek { get; set; } 
        public TimeSpan OpenTime { get; set; } 
        public TimeSpan CloseTime { get; set; } 

        public Barber Barber { get; set; }

    }
      



}
