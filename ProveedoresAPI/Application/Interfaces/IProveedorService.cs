using ProveedoresAPI.Domain;

namespace ProveedoresAPI.Application.Interfaces
{
    public interface IProveedorService
    {
        Task<IEnumerable<Proveedor>> GetAllAsync();
        Task<Proveedor> GetByIdAsync(string id);
        Task AddAsync(Proveedor proveedor);
        Task UpdateAsync(string id, Proveedor proveedor);
        Task DeleteAsync(string id);
    }
}
