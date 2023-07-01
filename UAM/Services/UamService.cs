using AutoMapper;
using Infrastructure.Contracts;
using Infrastructure.Entities;
using Infrastructure.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAM.Dtos;
using UAM.Queries;

namespace UAM.Services
{
    public class UamService : IUamService
    {

        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public UamService(IDbRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }


        FilterDefinition<AppUser> GetUserListQueryFilterDefinition(string searchKeyWord)
        {
            var filter = Builders<AppUser>.Filter.Regex("Email", new MongoDB.Bson.BsonRegularExpression(searchKeyWord, "i"));
            return filter;
        }
        public async Task<ServiceResponse> GetUserList(UserListQuery query)
        {
            var filter = GetUserListQueryFilterDefinition(query.SearchKeyWord);
            var response =  await _dbRepository.FindManyAsync<AppUser>(filter);
            var responseDto = _mapper.Map<List<AppUserListResponseDto>>(response);
            return new ServiceResponse().HandleSuccess<List<AppUserListResponseDto>>(200, responseDto, "returned List of user");
        }
    }
}
