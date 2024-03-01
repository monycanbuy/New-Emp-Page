

using System.Text.Json.Serialization;

namespace Shared.Entities
{
    public class Branch:BaseEntity
    {
        public Department? Department { get; set; }
        public int DepartmentId { get; set; }

        //Relationship : One to Many with Employee
        [JsonIgnore]
        public List<Employee>? Employees { get; set; }
    }
}
