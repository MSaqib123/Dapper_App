using Dapper_DB.DataAccess;
using Dapper_DB.Models.Doman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_DB.Repository
{
    public class PersonRepository:IPersonRepository
    {
        private readonly ISqlDataAccess _db;
        public PersonRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Person>> GetListAsync()
        {
            IEnumerable<Person> result = await _db.GetData<Person, dynamic>("spGetAllPersons", new { });
            return result;
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            IEnumerable<Person> result = await _db.GetData<Person, dynamic>("spGetPersonById", new { Id = id });
            return result.FirstOrDefault();
        }


        public async Task<bool> AddAsync(Person obj)
        {
            try
            {
                await _db.SaveData("spInsertPerson", new { obj.Name, obj.Email, obj.Address });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Person obj)
        {
            try
            {
                await _db.SaveData("spUpdatePerson", obj);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _db.SaveData("spDeletePerson", new {Id=id});
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        
    }
}
