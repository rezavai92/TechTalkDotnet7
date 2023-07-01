using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TechTalkDotnet7.Entities
{
    public class AppUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ItemId { get; set; }
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
        
       // public List<string> UserRoles { get; set; }

        public AppUser()
        {
            
       //     UserRoles = new List<string>() { };
        }
    }
}
