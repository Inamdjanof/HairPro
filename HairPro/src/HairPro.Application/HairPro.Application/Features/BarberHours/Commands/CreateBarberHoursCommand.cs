using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.BarberHours.Commands
{
    public class CreateBarberHoursCommand : IRequest<Guid>
    {
        public Guid BarberId { get; set; }
        public string DayOfWeek { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
    }
}
