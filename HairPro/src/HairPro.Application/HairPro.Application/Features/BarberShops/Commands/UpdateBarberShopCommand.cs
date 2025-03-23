using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.BarberShops.Commands
{
    public class UpdateBarberShopCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ResponsibleBarberId { get; set; }
        public string Location { get; set; } = string.Empty;
        public string DocumentPath { get; set; } = string.Empty;
    }
}
