using AutoMapper;
using TechTalkDotnet7.Commands;
using TechTalkDotnet7.Dtos;
using TechTalkDotnet7.Entities;
using TechTalkDotnet7.Queries;

namespace TechTalkDotnet7.MappingProfiles
{
    public class IdentityMappingProfiles : Profile
    {
      
        public IdentityMappingProfiles()
        {
            CreateMap<CreateUserCommand, AppUser>()
                .ForMember(user => user.DisplayName, dest => dest.MapFrom(x => x.UserName)).ReverseMap();
               // .ForMember(user=>user.UserRoles,dest=>dest.MapFrom(x=>new List<string>() { "appuser"}));

            
        }
    }
}
