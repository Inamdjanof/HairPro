using HairPro.Application.Exceptions;
using HairPro.Application.Features.Notifications.Queries;
using HairPro.DataAccess.Persistence;
using HairPros.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Notifications.Handlers
{

    public class GetNotificationByIdQueryHandler : IRequestHandler<GetNotificationByIdQuery, Notification>
    {
        private readonly DatabaseContext _context;

        public GetNotificationByIdQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Notification> Handle(GetNotificationByIdQuery request, CancellationToken cancellationToken)
        {
            var notification = await _context.Notifications
                .Include(n => n.User)
                .FirstOrDefaultAsync(n => n.Id == request.Id);

            if (notification == null) throw new NotFoundException(nameof(Notification), request.Id);

            return notification;
        }
    }
}
