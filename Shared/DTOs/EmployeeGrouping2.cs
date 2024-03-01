using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs
{
    public class EmployeeGrouping2
    {
        [Required]
        public string JobName { get; set; } = string.Empty;

        [Required, Range(1, 99999, ErrorMessage = "You must select branch")]
        public int BranchId { get; set; }
        [Required, Range(1, 99999, ErrorMessage = "You must select city")]
        public int CityId { get; set; }

        [Required, Range(1, 99999, ErrorMessage = "You must select gender")]
        public int GenderId { get; set; }
    }
}
