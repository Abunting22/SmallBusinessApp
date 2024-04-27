using SmallBusinessApp.Server.Model;

namespace SmallBusinessApp.Server.Interfaces
{
    public interface IAppointmentRepository
    {
        public Task<List<Appointment>> GetAppointmentsByCustomerId(int id);
    }
}
