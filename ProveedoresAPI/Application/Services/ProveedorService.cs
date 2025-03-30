using ProveedoresAPI.Application.Interfaces;
using ProveedoresAPI.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProveedoresAPI.Application.Services
{
    public class ProveedorService : IProveedorService
    {
        private readonly IProveedorRepository _proveedorRepository;

        public ProveedorService(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }

        public async Task<IEnumerable<Proveedor>> GetAllAsync()
        {
            return await _proveedorRepository.GetAllAsync();
        }

        public async Task<Proveedor> GetByIdAsync(string id)
        {
            return await _proveedorRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Proveedor proveedor)
        {
            await _proveedorRepository.AddAsync(proveedor);
        }

        public async Task UpdateAsync(string id, Proveedor proveedor)
        {
            await _proveedorRepository.UpdateAsync(id, proveedor);
        }

        public async Task DeleteAsync(string id)
        {
            await _proveedorRepository.DeleteAsync(id);
        }
    }
}
