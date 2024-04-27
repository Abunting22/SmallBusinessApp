using System.Data;
using Dapper;
using SmallBusinessApp.Server.Interfaces;

namespace SmallBusinessApp.Server.Repositories
{
    public class BaseRepository(IDbConnection dbConnection) : IBaseRepository
    { 
        public virtual async Task<List<T>> GetData<T, P>(string sql, P parameters)
        {
            using (dbConnection)
            {
                try
                {
                    var data = await dbConnection.QueryAsync<T>(sql, parameters);
                    return data.ToList();
                }
                catch (Exception ex)
                {
                    return [];
                    throw new ArgumentNullException(ex.Message);
                }
            }
        }

        public virtual async Task<T> GetObject<T, P>(string sql, P parameters)
        {
            using (dbConnection)
            {
                try
                {
                    var data = await dbConnection.QueryFirstOrDefaultAsync<T>(sql, parameters);
                    return data;
                }
                catch (Exception ex)
                {
                    throw new ArgumentNullException(ex.Message);
                }
            }
        }

        public virtual async Task SaveData<P>(string sql, P parameters)
        {
            using (dbConnection)
            {
                try
                {
                    var result = await dbConnection.ExecuteAsync(sql, parameters);
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
        }
    }
}
