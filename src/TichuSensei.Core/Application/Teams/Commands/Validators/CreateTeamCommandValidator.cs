using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Application.Teams.Commands.Create;

namespace TichuSensei.Core.Application.Teams.Commands.Validators
{
    public class CreateTeamCommandValidator : AbstractValidator<CreateTeamCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateTeamCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.PlayerOneId)
                .NotEmpty().GreaterThan(0).WithMessage("A player Id is required.");

            RuleFor(v => v.PlayerTwoId)
                .NotEmpty().GreaterThan(0).WithMessage("A player Id is required.");

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(Kernel.Consts.Player.Name.Min).WithMessage($"Name must not be shorter than {Kernel.Consts.Player.Name.Min} characters.")
                .MaximumLength(Kernel.Consts.Player.Name.Max).WithMessage($"Name must not exceed {Kernel.Consts.Player.Name.Max} characters.")
                .MustAsync(UniqueName).WithMessage("The specified name already exists.");

        }

        public async Task<bool> UniqueName(string name, CancellationToken cancellationToken)
        {
            return await _context.Teams
                .AllAsync(tm => tm.Name != name, cancellationToken: cancellationToken);
        }

    }
}
