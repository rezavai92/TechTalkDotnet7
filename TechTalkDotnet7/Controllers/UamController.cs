using Infrastructure.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechTalkDotnet7.Contracts;
using TechTalkDotnet7.Handlers.Query_Handlers;
using TechTalkDotnet7.Queries;
using UAM.Queries;

namespace TechTalkDotnet7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UamController : Controller
    {
        private IMediator _mediator;

        public UamController(IMediator mediator)
        {
         
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse>> GetUserList([FromBody] UserListQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
