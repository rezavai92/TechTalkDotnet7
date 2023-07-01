using Infrastructure.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechTalkDotnet7.Commands;
using TechTalkDotnet7.Contracts;
using TechTalkDotnet7.Dtos;
using TechTalkDotnet7.Queries;

namespace TechTalkDotnet7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ILogger _logger;
        private IMediator _mediator;
        public AuthController(IAuthService authService, IMediator mediator)
        {
            _authService = authService;
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse>> CreateUser([FromBody] CreateUserCommand command)
        {
           return await _mediator.Send(command);
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse>> GetToken([FromBody] GetTokenQuery query )
        {
            return await _mediator.Send(query);
        }

    }
}
