namespace Finance_Stripe_OneTimePayment_V1.DTOS
{
    public class PaymentRequest
    {
        public string ID { get; set; }
        public long Amount { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
    }
}
