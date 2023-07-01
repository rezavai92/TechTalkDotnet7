using Infrastructure.Models;
using MediatR;
using TechTalkDotnet7.Commands;
using TechTalkDotnet7.Contracts;
using TechTalkDotnet7.Queries;

namespace TechTalkDotnet7.Handlers.Query_Handlers
{
    public class GetTokenQueryHandler : IRequestHandler<GetTokenQuery, ServiceResponse>
    {

        private readonly IAuthService _authService;

        public GetTokenQueryHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<ServiceResponse> Handle(GetTokenQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _authService.AuthenticateUserByEmail(request.Email);
            }
            catch (Exception ex)
            {
                return new ServiceResponse().HandleError(500,null,null);
            }

        }
    }
}
