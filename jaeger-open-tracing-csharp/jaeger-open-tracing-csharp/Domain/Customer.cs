using MongoDB.Bson.Serialization.Attributes;

namespace JaegerOpenTrace.Domain
{
    [BsonIgnoreExtraElements]
    public class Customer
    {
        public string Name { get; set; }
        public string Document { get; set; }
    }
}
