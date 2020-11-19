using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Games.Models.DTOs;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Games.Commands.Update
{
    /// <summary>
    /// Updates a Tichu Sensei Game object and persists the changes in the database. Returns the resulting Game Data Transfer Object.
    /// </summary>
    public class UpdateGameCommand : IRequest<GameDTO>
    {
        /// <summary>
        /// The unique Id of the Tichu Sensei Game who will be updated.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The Tichu Sensei application user's unique Id that is matched with this particular game update.      
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// Mercy Rule setting for this game. Mercy rule states that a game will end if the difference of the teams score exceeds 1000 at any time.
        /// </summary>
        public bool? MercyRule { get; set; }
        /// <summary>
        /// States if the game is over, or is still under way.
        /// </summary>
        public bool? GameOver { get; set; }
        /// <summary>
        /// The unique id of the first team playing in this game.
        /// </summary>
        public long? TeamOneId { get; set; }
        /// <summary>
        /// The unique id of the second team playing in this game.
        /// </summary>
        public long? TeamTwoId { get; set; }
        /// <summary>
        /// The unique id of the first player playing in this round.
        /// </summary>
        public long? PlayerOneId { get; set; }
        /// <summary>
        /// The unique id of the second player playing in this game.
        /// </summary>
        public long? PlayerTwoId { get; set; }
        /// <summary>
        /// The unique id of the third player playing in this game.
        /// </summary>
        public long? PlayerThreeId { get; set; }
        /// <summary>
        /// The unique id of the fourth player playing in this game.
        /// </summary>
        public long? PlayerFourId { get; set; }

    }

    public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, GameDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateGameCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GameDTO> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {

            Game gm = await _context.Games.Where(ch => ch.GameId == request.Id).FirstOrDefaultAsync(cancellationToken: cancellationToken);
            gm = new Game
            {
                DateLastModified = DateTime.UtcNow,
                GameOver = request.GameOver ?? gm.GameOver,
                MercyRule = request.MercyRule ?? gm.MercyRule,
                PlayerOneId = request.PlayerOneId ?? gm.PlayerOneId,
                PlayerTwoId = request.PlayerTwoId ?? gm.PlayerTwoId,
                PlayerThreeId = request.PlayerThreeId ?? gm.PlayerThreeId,
                PlayerFourId = request.PlayerFourId ?? gm.PlayerFourId,
                TeamOneId = request.TeamOneId ?? gm.TeamOneId,
                TeamTwoId = request.TeamTwoId ?? gm.TeamTwoId,
                LastModifiedBy = request.UserId
            };
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<GameDTO>(gm);
        }
    }
}