using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Calls.Queries;
using TichuSensei.Core.Application.Players.Commands.Create;
using TichuSensei.Core.Application.Players.Commands.Delete;
using TichuSensei.Core.Application.Players.Commands.Update;
using TichuSensei.Core.Application.Players.Models.DTOs;
using TichuSensei.Core.Application.Players.Queries;
using TichuSensei.Core.Application.Shared.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TichuSensei.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class PlayersController : ControllerBase
    { 

        public PlayersController(IMediator mediator, ILogger<PlayersController> logger)
            {
                _mediator = mediator;
                _logger = logger;
            }
        private readonly IMediator _mediator;

        private readonly ILogger<PlayersController> _logger;

        // GET: api/players
        [HttpGet]
        public async Task<ActionResult<PaginatedList<PlayerDTO>>> Get(GetPlayersWithPaginationQuery query)
        {
            return !ModelState.IsValid ? BadRequest() : Ok(await _mediator.Send(query));
        }

        // GET api/players/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PlayerDTO>> Get(int id)
        {
           return Ok(await _mediator.Send(new GetPlayerQuery() { id = id }));
            
        }

        // GET: api/players/stats
        [HttpGet("Stats")]
        public async Task<ActionResult<PaginatedList<PlayerWithStatsDTO>>> GetPlayersWithStats(GetPlayersWithStatsWithPaginationQuery query)
        {
            return !ModelState.IsValid ? BadRequest() : Ok(await _mediator.Send(query));
        }

        // GET api/players/stats/5
        [HttpGet("Stats/{id:int}")]
        public async Task<ActionResult<PlayerWithStatsDTO>> GetPlayersWithStats(int id)
        {
            return Ok(await _mediator.Send(new GetPlayerWithStatsQuery() { id = id }));

        }

        // POST api/players
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreatePlayerCommand command)
        {
            if (!ModelState.IsValid) return BadRequest();
            PlayerDTO player = await _mediator.Send(command);
            return CreatedAtRoute("Get", new { id = player.PlayerId }, player);
        }

        // PUT api/players/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdatePlayerCommand command)
        {
            if(!ModelState.IsValid || id != command.Id ) return BadRequest();

            await _mediator.Send(command);

            return NoContent();
        }

        // DELETE api/players/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeletePlayerCommand { Id = id });

            return NoContent();
        }
    }
}
