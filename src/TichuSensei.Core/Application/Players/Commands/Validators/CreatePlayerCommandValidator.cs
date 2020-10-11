using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Players.Commands.Create;
using TichuSensei.Core.Application.Shared.Interfaces;

namespace TichuSensei.Core.Application.Players.Commands.Validators
{
    public class CreatePlayerCommandValidator : AbstractValidator<CreatePlayerCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public CreatePlayerCommandValidator(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;

            RuleFor(v => v.UserId)
                .NotEmpty().WithMessage("Being a user is required.")
                .Must(UserExists).WithMessage("The user specified does not exist.");

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(Kernel.Consts.Player.Name.Min).WithMessage($"Name must not be shorter than {Kernel.Consts.Player.Name.Min} characters.")
                .MaximumLength(Kernel.Consts.Player.Name.Max).WithMessage($"Name must not exceed {Kernel.Consts.Player.Name.Max} characters.")
                .MustAsync(UniqueName).WithMessage("The specified name already exists.");

            RuleFor(v => v.URL)
                .Must(CheckURLEmptyOrValid).WithMessage("The image specified is not valid");
        }

        public async Task<bool> UniqueName(string name, CancellationToken cancellationToken)
        {
            return await _context.Players
                .AllAsync(pl => pl.Name != name, cancellationToken: cancellationToken);
        }

        public bool UserExists(string userId) => _currentUserService.UserId == userId;

        public static bool CheckURLEmptyOrValid(string avatarUrl) {
            if (!(string.IsNullOrEmpty(avatarUrl) || (Uri.TryCreate(avatarUrl, UriKind.Absolute, out Uri uriResult) && uriResult.Scheme == Uri.UriSchemeHttps)))
                 return false;
            // Initialize the request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(avatarUrl);
            request.Method = "HEAD";

            // Get the response
            using WebResponse resp = request.GetResponse();
            return resp.ContentType.ToLower(CultureInfo.InvariantCulture)
                       .StartsWith("image/");

        }
    }
}
