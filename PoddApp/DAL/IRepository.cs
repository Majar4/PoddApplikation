using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository<T>
    {
        
        Task AddAsync(T item);

        
        Task<List<T?>> GetAllAsync();

        Task<T> GetByIdAsync(string id);

        
        Task <bool> UpdateAsync(T item);

        
        Task DeleteAsync(String id);
    }
}
