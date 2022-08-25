using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieProject.ViewModels
{
    public class DisplayCart
    {
        public List<ViewMovie> MovieListCart { get; set; }
        public double TotalPrice { get; set; }
    }
}