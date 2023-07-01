using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAM.Queries;

namespace UAM
{
    public interface IUamService
    {
        Task<ServiceResponse> GetUserList(UserListQuery query);
    }
}
