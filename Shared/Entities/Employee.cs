using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Employee:BaseEntity
    {
        [Required]
        public string EmpId { get; set; } = string.Empty;

        [Required]
        public string JobName { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required, DataType(DataType.PhoneNumber)]
        public string Phone { get; set; } = string.Empty;
        [Required]
        public string Photo { get; set; } = string.Empty;

        

        //Many to one relationship with Branch
        public Branch? Branch { get; set; }
        public int BranchId { get; set; }

        public City? City { get; set; }
        public int CityId { get; set; }

        public Gender? Gender { get; set; }
        public int GenderId { get; set; }

    }
}
