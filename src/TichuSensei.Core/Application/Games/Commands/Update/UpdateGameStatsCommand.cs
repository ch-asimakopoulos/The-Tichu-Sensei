using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Application.Games.Models.DTOs;
using TichuSensei.Core.Domain.Entities;
using TichuSensei.Core.Application.Rounds.Models.DTOs;
using System.Collections.Generic;
using System;

namespace TichuSensei.Core.Application.Games.Commands.Update
{
    /// <summary>
    /// Updates a Tichu Sensei Game's stats object and persists the changes in the database. Returns the resulting Game With Stats Data Transfer Object.
    /// </summary>
    public class UpdateGameStatsCommand : IRequest<GameWithStatsDTO>
    {
        /// <summary>
        /// The unique Id of the Tichu Sensei Game whose stats will be updated.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The Tichu Sensei application user's unique Id that is matched with this particular game stats update.      
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// The current team one score for this game.
        /// </summary>
        public int ScoreTeamOne { get; set; }

        /// <summary>
        /// The current team two score for this game.
        /// </summary>
        public int ScoreTeamTwo { get; set; }

        /// <summary>
        /// The total rounds of this game. 
        /// </summary>
        public long RoundsTotal { get; set; }
        /// <summary>
        /// The rounds of this game that team one won. 
        /// </summary>
        public long RoundsWonTeamOne { get; set; }
        /// <summary>
        /// The rounds of this game that team two won. 
        /// </summary>
        public long RoundsWonTeamTwo { get; set; }
        /// <summary>
        /// A collection of round data transfer objects describing each round of this game. 
        /// </summary>
        public IList<RoundDTO> Rounds { get; set; }
        /// <summary>
        /// The total Grand Tichu calls team one made in this game. 
        /// </summary>
        public long GrandTichuCallsTotalTeamOne { get; set; }
        /// <summary>
        /// The total Grand Tichu calls team one won in this game. 
        /// </summary>
        public long GrandTichuCallsWonTeamOne { get; set; }
        /// <summary>
        /// The total Grand Tichu calls team two made in this game. 
        /// </summary>
        public long GrandTichuCallsTotalTeamTwo { get; set; }
        /// <summary>
        /// The total Grand Tichu calls team two won in this game. 
        /// </summary>
        public long GrandTichuCallsWonTeamTwo { get; set; }
        /// <summary>
        /// The total Tichu calls team one made in this game. 
        /// </summary>
        public long TichuCallsTotalTeamOne { get; set; }
        /// <summary>
        /// The total Tichu calls team one won in this game. 
        /// </summary>
        public long TichuCallsWonTeamOne { get; set; }
        /// <summary>
        /// The total Tichu calls team two made in this game. 
        /// </summary>
        public long TichuCallsTotalTeamTwo { get; set; }
        /// <summary>
        /// The total Tichu calls team two won in this game. 
        /// </summary>
        public long TichuCallsWonTeamTwo { get; set; }
        /// <summary>
        /// The total High Cards team one had in this game. 
        /// </summary>
        public long HighCardsTotalTeamOne { get; set; }
        /// <summary>
        /// The total High Cards team two had in this game. 
        /// </summary>
        public long HighCardsTotalTeamTwo { get; set; }
        /// <summary>
        /// The total Bombs team one had in this game. 
        /// </summary>
        public long BombsTotalTeamOne { get; set; }
        /// <summary>
        /// The total Bombs team two had in this game. 
        /// </summary>
        public long BombsTotalTeamTwo { get; set; }
        /// <summary>
        /// The game's unique Id.
        /// </summary>
        public long GameId { get; set; }


    }

    public class UpdateGameStatsCommandHandler : IRequestHandler<UpdateGameStatsCommand, GameWithStatsDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateGameStatsCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GameWithStatsDTO> Handle(UpdateGameStatsCommand request, CancellationToken cancellationToken)
        {

            Game gm = await _context.Games.Where(ch => ch.GameId == request.Id).FirstOrDefaultAsync(cancellationToken: cancellationToken);
            GameStats gmStats = gm.Stats;
            GameStats updatedGameStats = new GameStats
            {
                BombsTotalTeamOne = request.BombsTotalTeamOne,
                BombsTotalTeamTwo = request.BombsTotalTeamTwo,
                GrandTichuCallsTotalTeamOne = request.GrandTichuCallsTotalTeamOne,
                GrandTichuCallsTotalTeamTwo = request.GrandTichuCallsTotalTeamTwo,
                GrandTichuCallsWonTeamOne = request.GrandTichuCallsWonTeamOne,
                GrandTichuCallsWonTeamTwo = request.GrandTichuCallsWonTeamTwo,
                HighCardsTotalTeamOne = request.HighCardsTotalTeamOne,
                HighCardsTotalTeamTwo = request.HighCardsTotalTeamTwo,
                Rounds = request.Rounds.Select(rd => _mapper.Map<Round>(rd)).ToList(),
                RoundsTotal = request.RoundsTotal,
                RoundsWonTeamOne = request.RoundsWonTeamOne,
                RoundsWonTeamTwo = request.RoundsWonTeamTwo,
                ScoreTeamOne = request.ScoreTeamOne,
                ScoreTeamTwo = request.ScoreTeamTwo,
                TichuCallsTotalTeamOne = request.TichuCallsTotalTeamOne,
                TichuCallsTotalTeamTwo = request.TichuCallsTotalTeamTwo,
                TichuCallsWonTeamOne = request.TichuCallsWonTeamOne,
                TichuCallsWonTeamTwo = request.TichuCallsWonTeamTwo,
                DateLastModified = DateTime.Now,
                LastModifiedBy = request.UserId,
                CreatedBy = gmStats?.CreatedBy ?? request.UserId,
                DateCreated = gmStats?.DateCreated ?? DateTime.Now,
                GameId = gm.GameId
            };

            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<GameWithStatsDTO>(gm);
        }
    }
}