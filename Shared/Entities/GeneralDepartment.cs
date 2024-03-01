

using System.Text.Json.Serialization;

namespace Shared.Entities
{
    public class GeneralDepartment:BaseEntity
    {
        [JsonIgnore]
        public List<Employee>? Employees { get; set; }
    }
}
