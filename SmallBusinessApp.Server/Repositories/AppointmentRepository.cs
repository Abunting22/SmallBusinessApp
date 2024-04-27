using System.Data;
using Dapper;
using SmallBusinessApp.Server.Interfaces;
using SmallBusinessApp.Server.Model;

namespace SmallBusinessApp.Server.Repositories
{
    public class AppointmentRepository(IDbConnection dbConnection) : IAppointmentRepository
    {
        public async Task<List<Appointment>> GetAppointmentsByCustomerId(int id)
        {
            using (dbConnection)
            {
                try
                {
                    var data = await dbConnection.QueryAsync<Appointment>("GetAppointmentByCustomerId", new { CustomerId = id },
                        commandType: CommandType.StoredProcedure);
                    return data.ToList();
                }
                catch (Exception ex)
                {
                    throw new ArgumentNullException(ex.Message);
                }
            }
        }
    }
}
