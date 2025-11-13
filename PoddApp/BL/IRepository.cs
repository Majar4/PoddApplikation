using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IRepository<T>
    {
        // C
        Task AddAsync(T item);

        // R
        Task<List<T?>> GetAllAsync();

        // U
        Task <bool> UpdateAsync(T item);

        // D
        Task DeleteAsync(T item);
    }
}
