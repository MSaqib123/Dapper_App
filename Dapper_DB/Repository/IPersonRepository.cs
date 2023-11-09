using Dapper_DB.DataAccess;
using Dapper_DB.Models.Doman;

namespace Dapper_DB.Repository
{
    public interface IPersonRepository
    {
        Task<bool> AddAsync(Person obj);
        Task<bool> UpdateAsync(Person obj);
        Task<bool> DeleteAsync(int id);
        Task<Person> GetByIdAsync(int id);
        Task<IEnumerable<Person>> GetListAsync();
    }
}