using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Calls.Commands.Update;
using TichuSensei.Core.Application.Shared.Interfaces;

namespace TichuSensei.Core.Application.Calls.Commands.Validators
{
    public class UpdateCallCommandValidator : AbstractValidator<UpdateCallCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public UpdateCallCommandValidator(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
            
            RuleFor(v => v.CallId)
                .NotEmpty().GreaterThan(0).WithMessage("A Call Id is required.");

            RuleFor(v => v.UserId)
                 .NotEmpty().WithMessage("Being a user is required.")
                 .Must(UserExists).WithMessage("The user specified does not exist.");
           
        }
        public bool UserExists(string userId) => _currentUserService.UserId == userId;
        
    }
}
