using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProveedoresAPI.Domain;

namespace ProveedoresAPI.Infrastructure
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<Proveedor> ProveedoresCollection
            => _database.GetCollection<Proveedor>("Proveedores"); 
    }
}
