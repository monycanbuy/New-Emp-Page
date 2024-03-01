

using System.Text.Json.Serialization;

namespace Shared.Entities
{
    public class Country:BaseEntity
    {
        [JsonIgnore]
        public List<State>? States { get; set; }


    }
}
