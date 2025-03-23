using HairPro.Application.Exceptions;
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

    public class DeleteNotificationCommandHandler : IRequestHandler<DeleteNotificationCommand, bool>
    {
        private readonly DatabaseContext _context;

        public DeleteNotificationCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = await _context.Notifications.FindAsync(request.Id);
            if (notification == null) throw new NotFoundException(nameof(Notification), request.Id);

            _context.Notifications.Remove(notification);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }


}
