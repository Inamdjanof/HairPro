using HairPro.Application.Features.Notifications.Commands;
using HairPro.DataAccess.Persistence;
using HairPros.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Notifications.Handlers
{
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, Guid>
    {
        private readonly DatabaseContext _context;

        public CreateNotificationCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = new Notification
            {
                Message = request.Message,
                UserId = request.UserId,
                CreatedAt = DateTime.UtcNow
            };

            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync(cancellationToken);

            return notification.Id;
        }
    }

}
