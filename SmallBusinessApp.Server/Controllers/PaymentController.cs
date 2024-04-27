using Microsoft.AspNetCore.Mvc;

using SmallBusinessApp.Server.Interfaces;
using SmallBusinessApp.Server.Model;

namespace SmallBusinessApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController(IPrimaryRepository<Payment> repository) : ControllerBase
    {
        [HttpGet("GetAll")]
        public virtual async Task<ActionResult<List<Payment>>> GetAll()
        {
            var result = await repository.GetAll();
            return Ok(result);
        }

        [HttpPost("Add")]
        public virtual async Task<ActionResult> Add([FromBody] Payment transaction)
        {
            var result = await repository.Add(transaction);
            return Ok(result);
        }

        [HttpPost("Update")]
        public virtual async Task<ActionResult> Update([FromBody] Payment transaction)
        {
            var result = await repository.Update(transaction);
            return Ok(result);
        }

        [HttpDelete("Delete{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            var result = await repository.Delete(id);
            return Ok(result);
        }
    }
}
