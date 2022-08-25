using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieProject.Models.Database
{
    public class OrderRow
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public Decimal Price { get; set; }

        [Display(Name = "Order ID")]
        public int OrdeId { get; set; }

        [Display(Name = "Movie ID")]
        public int MovieId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Movie Movie { get; set; }
    }
}