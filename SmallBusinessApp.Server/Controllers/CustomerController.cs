using Microsoft.AspNetCore.Mvc;
using SmallBusinessApp.Server.Interfaces;
using SmallBusinessApp.Server.Model;

namespace SmallBusinessApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ICustomerService service) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Customer>>> GetAllCustomers()
        {
            var customerList = await service.GetAllCustomersRequest();
            return Ok(customerList);
        }

        [HttpGet("GetById{id}")]
        public async Task<ActionResult<Customer>> GetCustomerInfo(int id)
        {
            var customer = await service.GetCustomerByIdRequest(id);
            return Ok(customer);
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddNewCustomer([FromBody] Customer customer)
        {
            var result = await service.AddNewCustomerRequest(customer);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<ActionResult> UpdateCustomerInfo([FromBody] Customer customer)
        {
            var result = await service.UpdateCustomerInfoRequest(customer);
            return Ok(result);
        }

        [HttpDelete("Delete{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            var result = await service.DeleteCustomerRequest(id);
            return Ok(result);
        }
    }
}
