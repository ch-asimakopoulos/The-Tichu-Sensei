using FluentValidation;

namespace TichuSensei.Core.Application.Games.Queries.Validators
{
    public class GetGamesWithPaginationQueryValidator : AbstractValidator<GetGamesWithPaginationQuery>
    {
        public GetGamesWithPaginationQueryValidator()
        {

            RuleFor(ch => ch.PageNumber).NotNull().NotEmpty().
                WithMessage("Page number is required.");

            RuleFor(ch => ch.PageNumber).LessThan(Kernel.Consts.Pagination.PageNumber.Min).
                WithMessage($"Page number cannot be less than{ Kernel.Consts.Pagination.PageNumber.Min}");


            RuleFor(ch => ch.PageSize).NotNull().NotEmpty().
                WithMessage("Page size is required.");

            RuleFor(ch => ch.PageSize).LessThan(Kernel.Consts.Pagination.PageSize.Max).
                WithMessage($"Page size cannot be more than{Kernel.Consts.Pagination.PageSize.Max}");

            RuleFor(ch => ch.PageSize).LessThan(Kernel.Consts.Pagination.PageSize.Min).
                WithMessage($"Page size cannot be less than{Kernel.Consts.Pagination.PageSize.Min}");

            RuleFor(ch => ch.PageSize).LessThan(Kernel.Consts.Pagination.PageSize.Max).
                WithMessage($"Page size cannot be more than{Kernel.Consts.Pagination.PageSize.Max}");

        }
    }
}