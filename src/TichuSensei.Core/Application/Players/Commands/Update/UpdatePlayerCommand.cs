using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Players.Models.DTOs;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Players.Commands.Update
{
    /// <summary>
    /// Updates a Tichu Sensei player object and persists the changes in the database. Returns the resulting Player Data Transfer Object.
    /// </summary>
    public class UpdatePlayerCommand : IRequest<PlayerDTO>
    {
        /// <summary>
        /// The unique Id of the Tichu Sensei player who will be updated.
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Containing the player's new name, if it is updated.      
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Containing the player's new avatar image URL, if it is updated.      
        /// </summary>
        public string URL { get; set; }
    }

    public class UpdatePlayerCommandHandler : IRequestHandler<UpdatePlayerCommand, PlayerDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdatePlayerCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PlayerDTO> Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
        {

            Player pl = await _context.Players.Where(ch => ch.PlayerId == request.Id).FirstOrDefaultAsync(cancellationToken: cancellationToken);
            pl.Name = string.IsNullOrWhiteSpace(request.Name) ? pl.Name : request.Name;
            pl.AvatarPath = string.IsNullOrWhiteSpace(request.URL) ? pl.AvatarPath : request.URL;
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<PlayerDTO>(pl);
        }
    }
}