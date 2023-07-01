using Infrastructure.Models;
using MediatR;
using UAM.Queries;

namespace UAM.Handlers.Query_Handlers
{
    internal class UserListQueryHandler : IRequestHandler<UserListQuery, ServiceResponse>
    {
        private readonly IUamService _service;

        public UserListQueryHandler(IUamService service)
        {
            _service = service;
        }

        public async Task<ServiceResponse> Handle(UserListQuery request, CancellationToken cancellationToken)
        {
            return await  _service.GetUserList(request);
        }
    }
}
