

using System.Text.Json.Serialization;

namespace Shared.Entities
{
    public class ApplicationUsers
    {
        public int Id { get; set; }
        public string? Fullname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        //[JsonIgnore]
        //public List<Customer>? Customers { get; set; }
    }
}
