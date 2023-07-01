using AutoMapper;
using Infrastructure.Contracts;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TechTalkDotnet7.Commands;
using TechTalkDotnet7.Contracts;
using TechTalkDotnet7.Dtos;
using TechTalkDotnet7.Entities;

namespace TechTalkDotnet7.Services
{
    public class AuthService : IAuthService
    {
        private readonly IDbRepository _repository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthService(IDbRepository repository, IMapper mapper, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _configuration = configuration;
        }


        private FilterDefinition<AppUser> GetUserExistsFilterDefinition(string email)
        {
            var filter = Builders<AppUser>.Filter.Empty;

            filter &= Builders<AppUser>.Filter.Eq(user =>user.Email,email);
            return filter;

        }
        public async Task<ServiceResponse> CreateUserAsync(CreateUserCommand command)
        {
          
                var userExists = await _repository.FindOneAsync<AppUser>(GetUserExistsFilterDefinition(command.Email));
                if (userExists !=null)
                {
                    return new ServiceResponse().HandleError(StatusCodes.Status400BadRequest,null,"User with this email already exists");
                }

                var userModelToInsert = _mapper.Map<AppUser>(command);

                if (userModelToInsert != null)
                {
                    await _repository.InsertOneAsync<AppUser>(userModelToInsert);

                    return new ServiceResponse().HandleSuccess(StatusCodes.Status200OK, userModelToInsert, "User has been created successfully");
                }

                return new ServiceResponse().HandleError(StatusCodes.Status400BadRequest, null, null);
          
        }


        public async Task<ServiceResponse> LoginAsync(LoginUserDto loginDto)
        {
            var userExists = await _repository.FindOneAsync<AppUser>(GetUserExistsFilterDefinition(loginDto.Email));
            if(userExists == null)
            {
                return new ServiceResponse().HandleError(StatusCodes.Status400BadRequest, null, null);
            }

            var jwtDto = new CreateJwtTokenDto
            {
                DisplayName = userExists.DisplayName,
                Email = userExists.Email,
             //   UserRoles = userExists.UserRoles
            };

            var token = CreateJwtToken(jwtDto);
            return new ServiceResponse().HandleSuccess<string>(StatusCodes.Status200OK, null, null);
        }


        public async Task<ServiceResponse>  AuthenticateUserByEmail(string email)
        {
            var userExists = await _repository.FindOneAsync<AppUser>(GetUserExistsFilterDefinition(email));
            if (userExists == null)
            {
                return new ServiceResponse().HandleError(StatusCodes.Status400BadRequest, null, "No user exists with this email");
            }
            var jwtDto = new CreateJwtTokenDto
            {
                DisplayName = userExists.DisplayName,
                Email = userExists.Email,
                //   UserRoles = userExists.UserRoles
            };

            var token = CreateJwtToken(jwtDto);
            return new ServiceResponse().HandleSuccess(200, token);

        }
        public string CreateJwtToken(CreateJwtTokenDto jwtDto)
        {
            List<Claim> claims = new List<Claim>();

            
            claims.Add(new Claim(ClaimTypes.Email, jwtDto.Email));

            foreach (var role in jwtDto.UserRoles)
            {
                claims.Add(
                    new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(7),
                signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
