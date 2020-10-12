using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Games.Models.DTOs;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Games.Commands.Create
{
    /// <summary>
    /// Creates a Tichu Sensei Game object and persists it in the database. Returns the resulting Game Data Transfer Object.
    /// </summary>
    public class CreateGameCommand : IRequest<GameDTO>
    {
        /// <summary>
        /// The Tichu Sensei application user's unique Id that is matched with this particular game creation.      
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// Containing the new Game's player one unique identifier.
        /// </summary>
        public long PlayerOneId { get; set; }
        /// <summary>
        /// Containing the new Game's player two unique identifier.
        /// </summary>
        public long PlayerTwoId { get; set; }
        /// <summary>
        /// Containing the new Game's player three unique identifier.
        /// </summary>
        public long PlayerThreeId { get; set; }
        /// <summary>
        /// Containing the new Game's player four unique identifier.
        /// </summary>
        public long PlayerFourId { get; set; }
        /// <summary>
        /// Containing the new Game's team one unique identifier.
        /// </summary>
        public long TeamOneId { get; set; }
        /// <summary>
        /// Containing the new Game's team two unique identifier.
        /// </summary>
        public long TeamTwoId { get; set; }
        /// <summary>
        /// Determines on if the mercy rule is enabled for this game or not.
        /// </summary>
        public bool MercyRule { get; set; }
    }

    public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, GameDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateGameCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GameDTO> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            Game gm = new Game
            {
                DateCreated = DateTime.UtcNow,
                GameOver = false,
                DateLastModified = DateTime.UtcNow,
                MercyRule = request.MercyRule,
                PlayerThreeId = request.PlayerThreeId,
                PlayerFourId = request.PlayerFourId,
                PlayerOneId = request.PlayerOneId,
                PlayerTwoId = request.PlayerTwoId,
                TeamOneId = request.TeamOneId,
                TeamTwoId = request.TeamTwoId,
                LastModifiedBy = request.UserId,
                CreatedBy = request.UserId                
            };
            _context.Games.Add(gm);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<GameDTO>(gm);
        }
    }
}