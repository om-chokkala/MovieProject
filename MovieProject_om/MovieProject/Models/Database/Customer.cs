using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieProject.Models.Database
{
    public class Customer
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        [Required]
        [Display(Name = "Billing Address")]
        public string BillingAddress { get; set; }

        [Required]
        [Display(Name = "Billing Zip")]
        public string BillingZip { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Billing City")]
        public string BillingCity { get; set; }

        [Required]
        [Display(Name = "Delivery Address")]
        public string DeliveryAddress { get; set; }

        [Required]
        [Display(Name = "Delivery Zip")]
        public string DeliveryZip { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Delivery City")]
        public string DeliveryCity { get; set; }

        [Required]
        [Display(Name = "Email")]
        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}