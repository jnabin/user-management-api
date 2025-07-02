using System.Threading;
using Api.Controllers.Users.Dto;
using Application.Users.GetUserById;
using Domain.Users.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly ISender _sender;
        public UsersController(ISender sender) => _sender = sender;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id, CancellationToken token)
        {
            var query = new GetUserByIdQuery(id);
            var result = await _sender.Send(query, token);
            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDto userDto, CancellationToken token)
        {
            var command = new RegisterUserCommand(userDto.Email, userDto.FirstName, userDto.LastName, userDto.password);
            var result = await _sender.Send(command, token);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(nameof(GetUser), new { id = result.Value }, result.Value);
        }
    }
}
