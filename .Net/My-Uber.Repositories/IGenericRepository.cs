using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Uber.Repositories.Contract
{
    public interface IGenericRepository<T>
    {
        // Get all entities
        Task<IEnumerable<T>> GetAllAsync();

        // Get a single entity by ID
        Task<T> GetByIdAsync(int id);

        // Add a new entity
        Task AddAsync(T entity);

        // Update an existing entity
        Task UpdateAsync(T entity);

        // Delete an entity
        Task DeleteAsync(T entity);

        // Save changes to the context
        Task SaveChangesAsync();
    }
}
