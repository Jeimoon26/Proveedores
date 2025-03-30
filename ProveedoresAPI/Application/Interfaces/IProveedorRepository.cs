using ProveedoresAPI.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProveedoresAPI.Application.Interfaces
{
    public interface IProveedorRepository
    {
        Task<List<Proveedor>> GetAllAsync();
        Task<Proveedor> GetByIdAsync(string id);
        Task AddAsync(Proveedor proveedor);
        Task UpdateAsync(string id, Proveedor proveedor);
        Task DeleteAsync(string id);
    }
}
