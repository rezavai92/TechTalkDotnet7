using AutoMapper;
using Infrastructure.Entities;
using UAM.Dtos;

namespace UAM.Mapping_Profiles
{
    public class UamAutoMapperProfile : Profile
    {
        public UamAutoMapperProfile()
        {
            CreateMap<AppUser, AppUserListResponseDto>().ReverseMap();
        }
    }
}
