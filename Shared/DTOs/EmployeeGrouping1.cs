using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs
{
    public class EmployeeGrouping1
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public string Phone { get; set; } = string.Empty;
        [Required]
        public string Photo { get; set; } = string.Empty;
        [Required]
        public string EmpId { get; set; } = string.Empty;
    }
}
