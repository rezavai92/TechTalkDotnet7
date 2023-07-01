using Infrastructure.Models;
using MediatR;
using TechTalkDotnet7.Commands;
using TechTalkDotnet7.Contracts;
using TechTalkDotnet7.Dtos;

namespace TechTalkDotnet7.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ServiceResponse>
    {
        private readonly IAuthService _authService;
        public CreateUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<ServiceResponse> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _authService.CreateUserAsync(command);

                return result;
            }
            catch (Exception ex)
            {
                return new ServiceResponse().HandleError(StatusCodes.Status500InternalServerError, ex, ex.Message);
            }
          
        }
    }
}
