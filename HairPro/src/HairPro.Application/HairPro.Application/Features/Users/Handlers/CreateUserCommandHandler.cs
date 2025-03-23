using HairPro.Application.Features.Users.Commands;
using HairPros.Core.Entities;
using HairPros.Core.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Features.Users.Handlers
{
    //public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    //{
    //    private readonly UserManager<User> _userManager;

    //    public CreateUserCommandHandler(UserManager<User> userManager)
    //    {
    //        _userManager = userManager;
    //    }

    //    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    //    {
    //        var user = new User
    //        {
    //            FirstName = request.FirstName,
    //            LastName = request.LastName,
    //            Email = request.Email,
    //            UserName = request.Email,
    //            IsVerified = false,
    //            CreatedOn = DateTime.UtcNow,
    //            CreatedBy = "System"
    //        };

    //        var result = await _userManager.CreateAsync(user, request.Password);

    //        if (!result.Succeeded)
    //            throw new ValidationException(result.Errors.Select(e => e.Description));

    //        return user.Id;
    //    }
    //}


}
