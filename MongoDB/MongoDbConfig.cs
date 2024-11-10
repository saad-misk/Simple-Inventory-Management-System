public static class MongoDbConfig
{
    public static void Configure()
    {
        // Global configuration to set GUID representation
        MongoDB.Bson.Serialization.BsonSerializer.RegisterSerializer(new MongoDB.Bson.Serialization.Serializers.GuidSerializer(MongoDB.Bson.GuidRepresentation.Standard));
    }
}
