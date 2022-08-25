using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieProject.ViewModels
{
    public class ViewMovie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double ItemPrice { get; set; }
        public double AggregatePriceMovie { get; set; }
        public int MovieQty { get; set; }
    }
}