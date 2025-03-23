using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.BarberHours.Commands
{

    public class UpdateBarberHoursCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string DayOfWeek { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
    }

}
