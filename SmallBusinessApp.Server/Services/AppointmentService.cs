using SmallBusinessApp.Server.Interfaces;
using SmallBusinessApp.Server.Model;

namespace SmallBusinessApp.Server.Services
{
    public class AppointmentService(IPrimaryRepository<Appointment> repository, IAppointmentRepository appointmentRepository) : IAppointmentService
    {
        public async Task<List<Appointment>> GetAllAppointmentsRequest()
        {
            var apptList = await repository.GetAll();
            return apptList;
        }

        public async Task<Appointment> GetApptByIdRequest(int id)
        {
            var appt = await repository.GetById(id);
            return appt;
        }

        public async Task<List<Appointment>> GetAppointmentsByCustomerIdRequest(int id)
        {
            var apptList = await appointmentRepository.GetAppointmentsByCustomerId(id);
            return apptList;
        }

        public async Task<bool> AddNewApptRequest(Appointment appt)
        {
            appt.AppointmentId = Guid.NewGuid();
            var result = await repository.Add(appt);
            return result;
        }

        public async Task<bool> UpdateApptInfoRequest(Appointment appt)
        {
            var result = await repository.Update(appt);
            return result;
        }

        public async Task<bool> DeleteApptRequest(int id)
        {
            var result = await repository.Delete(id);
            return result;
        }
    }
}
