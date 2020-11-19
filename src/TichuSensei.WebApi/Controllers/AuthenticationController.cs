using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TichuSensei.Core.Application.Shared.Interfaces;
using TichuSensei.Core.Application.Shared.Models;
using TichuSensei.Kernel.Consts;
using TichuSensei.Infrastructure.Identity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TichuSensei.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly IIdentityService _identityService;
        public AuthenticationController(IIdentityService identityService) => _identityService = identityService;

        // GET api/Authentication/5
        /// <summary>
        /// Gets a Tichu Sensei username.
        /// </summary>
        /// <param name="id">The user id to query for.</param>
        /// <returns>A string with the relevant Tichu Sensei username.</returns>
        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetUsername")]
        public async Task<ActionResult<string>> Get(string id)
        {
            return Ok(await _identityService.GetUserNameAsync(id));
        }

        // POST api/Authentication
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult> Post(string userName, [FromBody] string password)
        {
            (Result Result, string UserId) newUser = await _identityService.CreateUserAsync(userName, password);

            return CreatedAtAction("Get", new { id = newUser.UserId }, newUser);
        }

        //// PUT api/Authentication/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/Authentication/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromBody] string id)
        {
            Result result = await _identityService.DeleteUserAsync(id);

            return result.Succeeded ? NoContent() : Forbid();
        }
    }
}
