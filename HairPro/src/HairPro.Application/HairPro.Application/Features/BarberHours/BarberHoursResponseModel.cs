using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.BarberHours
{
    public class BarberHoursResponseModel : BaseResponseModel
    {
        public Guid BarberId { get; set; }
        public string BarberName { get; set; } 

        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }

    }
}
