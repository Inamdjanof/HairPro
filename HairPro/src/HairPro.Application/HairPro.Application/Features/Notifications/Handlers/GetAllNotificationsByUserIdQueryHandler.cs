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
    public class GetAllNotificationsByUserIdQueryHandler : IRequestHandler<GetAllNotificationsByUserIdQuery, List<Notification>>
    {
        private readonly DatabaseContext _context;

        public GetAllNotificationsByUserIdQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Notification>> Handle(GetAllNotificationsByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Notifications
                .Where(n => n.UserId == request.UserId)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();
        }
    }

}
