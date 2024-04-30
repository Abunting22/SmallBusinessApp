using System.Data;
using System.Data.Common;

using Dapper;

using SmallBusinessApp.Server.Interfaces;
using SmallBusinessApp.Server.Model;

namespace SmallBusinessApp.Server.Repositories
{
    public class CustomerRepository(IDbConnection dbConnection) : ICustomerRepository
    {
        public async Task<Customer> Login(LoginDto request)
        {
            using (dbConnection)
            {
                try
                {
                    string sql = $"SELECT * FROM Customer WHERE EmailAddress = @EmailAddress";
                    var customer = await dbConnection.QueryFirstOrDefaultAsync<Customer>(sql, new { request.EmailAddress });
                    return customer;
                }
                catch (Exception ex)
                {
                    throw new ArgumentNullException(ex.Message);
                }
            }
        }
    }
}
