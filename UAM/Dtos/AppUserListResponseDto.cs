using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAM.Dtos
{
    internal class AppUserListResponseDto
    {
        public string ItemId { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Language { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string PostOfficNo { get; set; }
        public string StreetNo { get; set; }
        public string ProfileImageId { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
