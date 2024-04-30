using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<ActionResult<List<Customer>>> GetAllCustomers()
        {
            var customerList = await service.GetAllCustomersRequest();
            return Ok(customerList);
        }

        [HttpGet("GetById{id}")]
        [Authorize]
        public async Task<ActionResult<Customer>> GetCustomerInfo(int id)
        {
            var customer = await service.GetCustomerByIdRequest(id);
            return Ok(customer);
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddNewCustomer([FromForm] CustomerDto request)
        {
            var result = await service.AddNewCustomerRequest(request);
            return Ok(result);
        }

        [HttpPost("Update")]
        [Authorize]
        public async Task<ActionResult> UpdateCustomerInfo([FromBody] Customer customer)
        {
            var result = await service.UpdateCustomerInfoRequest(customer);
            return Ok(result);
        }

        [HttpDelete("Delete{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            var result = await service.DeleteCustomerRequest(id);
            return Ok(result);
        }
    }
}
