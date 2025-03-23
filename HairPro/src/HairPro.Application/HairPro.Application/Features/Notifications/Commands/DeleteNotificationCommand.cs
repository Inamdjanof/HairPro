using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Notifications.Commands
{


    public class DeleteNotificationCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

}
