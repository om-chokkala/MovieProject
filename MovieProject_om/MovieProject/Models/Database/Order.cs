using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieProject.Models.Database
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Order Date")]
        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Total Price")]
        public Decimal TotalPrice { get; set; }

        [Display(Name = "Customer ID")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderRow> Orders { get; set; }
    }
}