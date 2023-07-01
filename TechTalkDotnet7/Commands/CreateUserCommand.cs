using Infrastructure.Models;
using MediatR;


namespace TechTalkDotnet7.Commands
{
    public class CreateUserCommand : IRequest<ServiceResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Language { get; set; }
    }
}
