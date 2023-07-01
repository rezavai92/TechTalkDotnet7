using Infrastructure.Models;
using MediatR;


namespace TechTalkDotnet7.Queries
{
    public class GetTokenQuery : IRequest<ServiceResponse>
    {
        public string Email { get; set; }
    }
}
