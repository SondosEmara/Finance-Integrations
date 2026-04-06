using Finance_Stripe_Provider_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Finance_Stripe_Provider_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        #region ONE-TIME PAYMENT  (PaymentIntent)

        [HttpPost("intent")]
        public async Task<IActionResult> StripIntentAsync(CreatePaymentIntentRequest createPaymentIntentRequest)
        {
            var service = new PaymentIntentService();
            var intent = await service.CreateAsync(new PaymentIntentCreateOptions
            {
                Amount = req.AmountCents,
                Currency = req.Currency,
                Customer = req.CustomerId,
                PaymentMethodTypes = new List<string> { "card" }
            });
            return Results.Ok(new { intent.Id, intent.ClientSecret, intent.Status });
            return Ok("");
        }
        #endregion
    }
}
