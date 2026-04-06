using Finance_Stripe_Provider_API.Controllers;
using System.Collections.Generic;

namespace Finance_Stripe_Provider_API.Mock_Data
{
    public class CustomerMock
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public string Name { get; set; }
        public CustomerMock(int id, string email , string name)
        {
            Id = id;
            Email = email;
            Name = name;
            
        }
    }

    public static class MockData
    {
        public static List<CustomerMock> Customers = new List<CustomerMock>()
        {
            new CustomerMock(1,"sondos.emara@gmail.com","sondos"),
            new CustomerMock(2,"sarah.emara@gmail.com","sarah"),
            new CustomerMock(2,"sherouk.emara@gmail.com","sherouk"),
            new CustomerMock(2,"salma.emara@gmail.com","salma")
        }; 
    }
}
