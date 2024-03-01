using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Cust
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CahierName { get; set; }
        [Required, Range(0.1, 99999.99)]
        public decimal Amount { get; set; }
        public DateTime TimeStamp { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        [Required]
        public string? Phone { get; set; }
        //public PaymentType? PaymentType { get; set; }
        //public int PaymentTypeId { get; set; }
    }
}
