using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Calls.Models.DTOs;
using TichuSensei.Core.Application.Rounds.Models.DTOs;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Rounds.Commands.Create
{
    /// <summary>
    /// Creates a Tichu Sensei Round object and persists it in the database. Returns the resulting Round Data Transfer Object.
    /// </summary>
    public class CreateRoundCommand : IRequest<RoundDTO>
    {
        public DateTime? DateEnded { get; set; }
        public long BombsTeamOne { get; set; }
        public long BombsTeamTwo { get; set; }
        public long HighCardsTeamOne { get; set; }
        public long HighCardsTeamTwo { get; set; }
        public IList<CallDTO> RoundCalls { get; set; }
        public long GameId { get; set; }
        public long PlayerOneId { get; set; }
        public long PlayerTwoId { get; set; }
        public long PlayerThreeId { get; set; }
        public long PlayerFourId { get; set; }
        public long TeamOneId { get; set; }
        public long TeamTwoId { get; set; }
        public long ScoreTeamOne { get; set; }
        public long ScoreTeamTwo { get; set; }
    }

    public class CreateRoundCommandHandler : IRequestHandler<CreateRoundCommand, RoundDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateRoundCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<RoundDTO> Handle(CreateRoundCommand request, CancellationToken cancellationToken)
        {
            Round pl = new Round
            {
                DateCreated = DateTime.UtcNow,
                DateEnded = request.DateEnded,
                BombsTeamOne = request.BombsTeamOne,
                BombsTeamTwo = request.BombsTeamTwo,
                HighCardsTeamOne = request.HighCardsTeamOne,
                HighCardsTeamTwo = request.HighCardsTeamTwo,
                Calls = _mapper.Map<List<Call>>(request.RoundCalls),
                GameId = request.GameId,
                PlayerOneId = request.PlayerOneId,
                PlayerTwoId = request.PlayerTwoId,
                PlayerThreeId = request.PlayerThreeId,
                PlayerFourId = request.PlayerFourId,
                TeamOneId = request.TeamOneId,
                TeamTwoId = request.TeamTwoId,
                ScoreTeamOne = request.ScoreTeamOne,
                ScoreTeamTwo = request.ScoreTeamTwo
            };
            _context.Rounds.Add(pl);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<RoundDTO>(pl);
        }
    }
}