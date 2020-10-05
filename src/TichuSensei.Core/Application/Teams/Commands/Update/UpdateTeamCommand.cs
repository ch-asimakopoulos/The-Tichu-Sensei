using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Application.Teams.Models.DTOs;
using TichuSensei.Core.Domain.Entities;

namespace TichuSensei.Core.Application.Teams.Commands.Update
{
    /// <summary>
    /// Updates a Tichu Sensei Team object and persists the changes in the database. Returns the resulting Team Data Transfer Object.
    /// </summary>
    public class UpdateTeamCommand : IRequest<TeamDTO>
    {
        /// <summary>
        /// The unique Id of the Tichu Sensei Team who will be updated.
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Containing the Team's new name, if it is updated.      
        /// </summary>
        public string Name { get; set; }
    }

    public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommand, TeamDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateTeamCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<TeamDTO> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {

            Team tm = await _context.Teams.Where(ch => ch.TeamId == request.Id).FirstOrDefaultAsync(cancellationToken: cancellationToken);
            tm.Name = string.IsNullOrWhiteSpace(request.Name) ? tm.Name : request.Name;
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<TeamDTO>(tm);
        }
    }
}