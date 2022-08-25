using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieProject.Models.Database
{
    public class Movie
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        [Display(Name = "Movie Title")]
        public string Title { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "Directed by")]
        public string Director { get; set; }

        [Required]
        [Display(Name = "Released Year")]
        public int ReleaseYear { get; set; }


        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public Decimal Price { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImgUrl { get; set; }
        public virtual ICollection<OrderRow> Orders { get; set; }
    }
}