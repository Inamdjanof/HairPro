using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Notifications.Commands
{
    public class CreateNotificationCommand : IRequest<Guid>
    {
        public string Message { get; set; } = string.Empty;
        public Guid UserId { get; set; }
    }

}
