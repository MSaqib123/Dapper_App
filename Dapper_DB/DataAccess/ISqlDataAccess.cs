namespace Dapper_DB.DataAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> GetData<T, P>(string spName, P parameter, string connectiongId = "conn");
        Task SaveData<T>(string spName, T parameter, string connectiongId = "conn");
    }
}