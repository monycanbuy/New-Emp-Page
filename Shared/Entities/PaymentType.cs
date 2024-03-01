

using System.Text.Json.Serialization;

namespace Shared.Entities
{
    public class PaymentType:BaseEntity
    {
        [JsonIgnore]
        public List<Customer>? Customers { get; set; }

        //[JsonIgnore]
        //public List<Cust>? Custs { get; set; }
    }
}
