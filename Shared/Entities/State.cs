

using System.Text.Json.Serialization;

namespace Shared.Entities
{
    public class State:BaseEntity
    {
        [JsonIgnore]
        public List<City>? Cities { get; set; }

        public Country? Country { get; set; }
        public int CountryId { get; set; }
    }
}
