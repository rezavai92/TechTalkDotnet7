using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TechTalkDotnet7.Entities
{
    public class UserRoles
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public  string ItemId { get; set; }
        public  string Name { get; set; }

    }
}
