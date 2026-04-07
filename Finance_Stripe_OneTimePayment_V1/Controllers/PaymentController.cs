using Finance_Stripe_OneTimePayment_V1.DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Forwarding;

namespace Finance_Stripe_OneTimePayment_V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpPost("create-payment-intent")]
        public async Task<IResult >CreatePaymentIntentAsync(PaymentRequest paymentRequest)
        {

            var options = new PaymentIntentCreateOptions
            {
                Amount = paymentRequest.Amount,           // Amount in cents (e.g. 2000 = $20.00)
                Currency = paymentRequest.Currency,       // e.g. "usd"
                AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                {
                    Enabled = true,
                },
                Description = paymentRequest.Description,
                ReceiptEmail = "sondos.emara2002@gmail.com"
            };

            var service = new PaymentIntentService();
            try
            {
                var intent = await service.CreateAsync(options);
                return Results.Ok(new { clientSecret = intent.ClientSecret, intentId = intent.Id });
            }
            catch (StripeException ex)
            {
                return Results.BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("payment-status/{intentId}")]
        public async Task<IResult> GetPaymentStatus(string intentId)
        {
            var service = new PaymentIntentService();
            try
            {
                var intent = await service.GetAsync(intentId);
                return Results.Ok(new { status = intent.Status });
            }
            catch (StripeException ex)
            {
                return Results.BadRequest(new { error = ex.Message });
            }

        }

    }
}
