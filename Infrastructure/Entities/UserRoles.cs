using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.Entities
{
    public class UserRoles
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public  string ItemId { get; set; }
        public  string Name { get; set; }

    }
}
