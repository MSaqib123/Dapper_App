using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_DB.DataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> GetData<T, P>(string spName, P parameter, string connectiongId = "conn")
        {
            using IDbConnection connection = new SqlConnection
                (_config.GetConnectionString(connectiongId));
            return await connection.QueryAsync<T>(spName,parameter,commandType:CommandType.StoredProcedure);
        }

        public async Task SaveData<T>(string spName, T parameter,string connectiongId = "conn")
        {
            using IDbConnection connection = new SqlConnection
                (_config.GetConnectionString(connectiongId));
            await connection.QueryAsync<T>(spName, parameter, commandType: CommandType.StoredProcedure);
        }

    }
}
