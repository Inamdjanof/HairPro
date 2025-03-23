using HairPros.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Notifications.Queries
{

    public class GetAllNotificationsByUserIdQuery : IRequest<List<Notification>>
    {
        public Guid UserId { get; set; }
    }

}
