using Infrastructure.Models;
using TechTalkDotnet7.Commands;


namespace TechTalkDotnet7.Contracts
{
    public interface IAuthService
    {
       

         Task<ServiceResponse> CreateUserAsync(CreateUserCommand command);
       //  Task<ServiceResponse> CreateJwtToken(CreateJwtTokenDto createJwtDto);
        Task<ServiceResponse> AuthenticateUserByEmail(string email);


    }
}
