using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class CustomerProfile
    {
        public int Id { get; set; } 
        public string? CreatedBy { get; set; }
        [Required, Range(0.1, 99999.99)]
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        [Required]
        public string? Phone { get; set; }
    }
}
