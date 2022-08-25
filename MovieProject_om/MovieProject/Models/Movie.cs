using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieProject.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [DataType(DataType.ImageUrl)] 
        public string ImageUrl { get; set; }

        public virtual ICollection<OrderRow> OrderRows { get; set; }
    }
}