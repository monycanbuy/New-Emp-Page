using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Gender:BaseEntity
    {

        [JsonIgnore]
        public List<Employee>? Employees { get; set; }
    }
}
