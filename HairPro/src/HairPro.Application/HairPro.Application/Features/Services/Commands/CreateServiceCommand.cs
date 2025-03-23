using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Services.Commands
{
    public record CreateServiceCommand(string Name) : IRequest<Guid>;

}
