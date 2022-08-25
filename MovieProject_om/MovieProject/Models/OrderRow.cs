using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieProject.Models
{
    public class OrderRow
    {

        //public int Id { get; set; }
        //[Required]
        //public Movie Movie { get; set; }
        //[Required]
        //public Order Order { get; set; }
        //[Required]
        //[DataType(DataType.Currency)]
        //public decimal Price { get; set; }

        public int Id { get; set; }

        [Required]
        public int MovieId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Order Order { get; set; }
    }

}