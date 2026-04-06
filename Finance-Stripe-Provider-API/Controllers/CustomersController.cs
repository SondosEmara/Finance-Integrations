using Finance_Stripe_Provider_API.Mock_Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Finance_Stripe_Provider_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        [HttpGet("id")]
        public ActionResult<CustomerMock> GetCustomer([FromRoute] int id)
        {
            var customer = MockData.Customers.FirstOrDefault(cust=>cust.Id==id);
            return customer!=null? Ok(customer):NotFound();
        }
    }
}
