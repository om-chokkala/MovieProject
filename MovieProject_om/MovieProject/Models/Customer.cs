using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieProject.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        public string BillingAddress { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]
        public string BillingZip { get; set; }
        [Required]
        public string BillingCity { get; set; }
        [Required]
        public string DeliveryAddress { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]
        public string DeliveryZip { get; set; }
        [Required]
        public string DeliveryCity { get; set; }
        [Required]

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
}

}