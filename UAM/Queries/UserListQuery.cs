using Infrastructure.Entities;
using Infrastructure.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAM.Dtos;

namespace UAM.Queries
{
    public class UserListQuery : IRequest<ServiceResponse>
    {
        public string SearchKeyWord { get; set; }
    }
}
