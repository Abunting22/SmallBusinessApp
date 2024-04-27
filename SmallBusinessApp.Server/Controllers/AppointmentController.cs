using Microsoft.AspNetCore.Mvc;
using SmallBusinessApp.Server.Interfaces;
using SmallBusinessApp.Server.Model;

namespace SmallBusinessApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController(IAppointmentService service) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Appointment>>> GetAllAppointments()
        {
            var apptList = await service.GetAllAppointmentsRequest();
            return Ok(apptList);
        }

        [HttpGet("GetById{id}")]
        public async Task<ActionResult<Appointment>> GetApptInfo(int id)
        {
            var appt = await service.GetApptByIdRequest(id);
            return Ok(appt);
        }

        [HttpGet("GetApptByCustomerId{id}")]
        public async Task<ActionResult<List<Appointment>>> GetAppointmentsByCustomerId(int id)
        {
            var apptList = await service.GetAppointmentsByCustomerIdRequest(id);
            return Ok(apptList);
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddNewAppt([FromBody]Appointment appt)
        {
            var result = await service.AddNewApptRequest(appt);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<ActionResult> UpdateApptInfo([FromBody]Appointment appt)
        {
            var result = await service.UpdateApptInfoRequest(appt);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteAppt(int id)
        {
            var result = await service.DeleteApptRequest(id);
            return Ok(result);
        }
    }
}
