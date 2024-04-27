using SmallBusinessApp.Server.Model;

namespace SmallBusinessApp.Server.Interfaces
{
    public interface IAppointmentService
    {
        public Task<List<Appointment>> GetAllAppointmentsRequest();
        public Task<Appointment> GetApptByIdRequest(int id);
        public Task<List<Appointment>> GetAppointmentsByCustomerIdRequest(int id);
        public Task<bool> AddNewApptRequest(Appointment appt);
        public Task<bool> UpdateApptInfoRequest(Appointment appt);
        public Task<bool> DeleteApptRequest(int id);
    }
}
