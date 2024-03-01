

using System.ComponentModel.DataAnnotations;

namespace Shared.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
