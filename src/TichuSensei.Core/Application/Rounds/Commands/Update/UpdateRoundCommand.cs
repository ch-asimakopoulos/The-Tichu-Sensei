using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Calls.Models.DTOs;
using TichuSensei.Core.Application.Rounds.Models.DTOs;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Rounds.Commands.Update
{
    /// <summary>s
    /// Updates a Tichu Sensei Round object and persists it in the database. Returns the resulting Round Data Transfer Object.
    /// </summary>
    public class UpdateRoundCommand : IRequest<RoundDTO>
    {
        public long Id { get; set; }
        public DateTime? DateEnded { get; set; }
        public long? BombsTeamOne { get; set; }
        public long? BombsTeamTwo { get; set; }
        public long? HighCardsTeamOne { get; set; }
        public long? HighCardsTeamTwo { get; set; }
        public IList<CallDTO> RoundCalls { get; set; }
        public long? PlayerOneId { get; set; }
        public long? PlayerTwoId { get; set; }
        public long? PlayerThreeId { get; set; }
        public long? PlayerFourId { get; set; }
        public long? TeamOneId { get; set; }
        public long? TeamTwoId { get; set; }
        public long? ScoreTeamOne { get; set; }
        public long? ScoreTeamTwo { get; set; }
    }

    public class UpdateRoundCommandHandler : IRequestHandler<UpdateRoundCommand, RoundDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateRoundCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<RoundDTO> Handle(UpdateRoundCommand request, CancellationToken cancellationToken)
        {
            Round rnd = _context.Rounds.Where(rd => request.Id == rd.RoundId).FirstOrDefault();

            rnd = new Round
            {
                DateCreated = rnd.DateCreated,
                DateEnded = request.DateEnded ?? rnd.DateEnded,
                BombsTeamOne = request.BombsTeamOne ?? rnd.BombsTeamOne,
                BombsTeamTwo = request.BombsTeamTwo?? rnd.BombsTeamTwo,
                HighCardsTeamOne = request.HighCardsTeamOne ?? rnd.HighCardsTeamOne,
                HighCardsTeamTwo = request.HighCardsTeamTwo ?? rnd.HighCardsTeamTwo,
                Calls = request.RoundCalls != null ? _mapper.Map<List<Call>>(request.RoundCalls) : rnd.Calls,
                PlayerOneId = request.PlayerOneId ?? rnd.PlayerOneId,
                PlayerTwoId = request.PlayerTwoId ?? rnd.PlayerTwoId,
                PlayerThreeId = request.PlayerThreeId ?? rnd.PlayerThreeId,
                PlayerFourId = request.PlayerFourId ?? rnd.PlayerFourId,
                TeamOneId = request.TeamOneId ?? rnd.TeamOneId,
                TeamTwoId = request.TeamTwoId ?? rnd.TeamTwoId,
                ScoreTeamOne = request.ScoreTeamOne ?? rnd.ScoreTeamOne,
                ScoreTeamTwo = request.ScoreTeamTwo ?? rnd.ScoreTeamTwo
            };
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<RoundDTO>(rnd);
        }
    }
}