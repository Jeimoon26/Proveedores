using MongoDB.Driver;
using ProveedoresAPI.Application.Interfaces;
using ProveedoresAPI.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProveedoresAPI.Infrastructure
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly IMongoCollection<Proveedor> _proveedoresCollection;

        public ProveedorRepository(MongoDBContext dbContext)
        {
            _proveedoresCollection = dbContext.ProveedoresCollection;
        }

        public async Task<List<Proveedor>> GetAllAsync()
        {
            return await _proveedoresCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Proveedor> GetByIdAsync(string id)
        {
            return await _proveedoresCollection.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Proveedor proveedor)
        {
            await _proveedoresCollection.InsertOneAsync(proveedor);
        }

        public async Task UpdateAsync(string id, Proveedor proveedor)
        {
            await _proveedoresCollection.ReplaceOneAsync(p => p.Id == id, proveedor);
        }

        public async Task DeleteAsync(string id)
        {
            await _proveedoresCollection.DeleteOneAsync(p => p.Id == id);
        }
    }
}
