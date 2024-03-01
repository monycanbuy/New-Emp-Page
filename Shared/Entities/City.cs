

using System.Text.Json.Serialization;

namespace Shared.Entities
{
    public class City:BaseEntity
    {
        [JsonIgnore]
        public List<Employee>? Employees { get; set; }

        //Many to one relationship with city
        public State? States { get; set; }
        public int StateId { get; set; }

        

        
    }
}
