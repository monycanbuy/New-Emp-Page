

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shared.Entities
{
    public class Customer:BaseEntity
    {

        //[Required]
        //public string? CustomerName { get; set; }
        //[Required]
        public string? CreatedBy { get; set; } 
        [Required, Range(0.1, 99999.99)]
        public decimal Amount { get; set; }
        public DateTime TimeStamp { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        [Required]
        public string? Phone { get; set; }
        public PaymentType? PaymentType { get; set; }
        public int PaymentTypeId { get; set; }
        //public ApplicationUsers? ApplicationUsers { get; set; }
        //public int ApplicationUsersId { get; set; }
        


    }
}
