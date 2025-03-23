using HairPro.Application.Exceptions;
using HairPro.Application.Features.Users.Commands;
using HairPros.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Users.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly UserManager<User> _userManager;

        public UpdateUserCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null)
                throw new NotFoundException(nameof(User), request.Id);

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.UpdatedOn = DateTime.UtcNow;
            user.UpdatedBy = "System";

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }
    }

}
