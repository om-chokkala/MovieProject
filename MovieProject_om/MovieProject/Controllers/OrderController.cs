using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieProject.Models;
using MovieProject.ViewModels;

namespace MovieProject.Controllers
{

    public class OrderController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        List<Movie> cartItems = new List<Movie>();

        // GET: Order
        public ActionResult AddtoCart([Bind(Prefix = "id")] int movieId, string returnAction, string returnController)
        {
            var movie = _db.Movies.First(m => m.Id == movieId);
            
            if (Session["MoviesList"] == null)
            {
                cartItems.Add(movie);

                Session["MoviesList"] = cartItems;
            }

            else
            {
                cartItems = (List<Movie>)Session["MoviesList"];
                cartItems.Add(movie);
                Session["MoviesList"] = cartItems;

            }
            if (returnAction == "DisplayCart")
            {
                return RedirectToAction(returnAction);
            }
            return RedirectToAction(returnAction,returnController);
        }



        public ActionResult RemoveFromCart([Bind(Prefix = "id")] int movieId)

        {
            if (Session["MoviesList"] != null)

            {
                cartItems = (List<Movie>)Session["MoviesList"];
                cartItems.Remove(cartItems.First(m => m.Id == movieId));
                Session["MoviesList"] = cartItems;
                if (cartItems.Count != 0)
                {
                    return RedirectToAction("DisplayCart");
                }
                 
            }
          
                return RedirectToAction("DisplayMovies", "Movie");

        }

        public ActionResult DisplayCart()
        {
            //Boolean found = false;
            cartItems = (List<Movie>)Session["MoviesList"];
            DisplayCart cartView = new DisplayCart();
            List<ViewMovie> tempList = new List<ViewMovie>();
            cartView.TotalPrice = 0;

            if (cartItems != null)
            {
                foreach (var mItem in cartItems)
                {
                    cartView.TotalPrice += mItem.Price;
                }

                var orderQueryResult = from cIt in cartItems
                                        group cIt by cIt.Id into g
                                        select new ViewMovie
                                        {
                                            Id = g.FirstOrDefault().Id,
                                            Title = g.FirstOrDefault().Title,
                                            AggregatePriceMovie = g.FirstOrDefault().Price * g.Count(),
                                            ItemPrice = g.FirstOrDefault().Price,
                                            MovieQty = g.Count()
                                        };

                

                cartView.MovieListCart = orderQueryResult.ToList();
                return View("DisplayCart", cartView);
            }

            return RedirectToAction("DisplayMovies", "Movie");

        }


        public ActionResult OrderRegistration(Customer customer)
        {
            List<Movie> orderItems = (List<Movie>)Session["MoviesList"];

            Order newOrder = new Order();
            newOrder.Customer = customer;
            newOrder.OrderDate = DateTime.Now;
            List<OrderRow> tempRows = new List<OrderRow>();
            foreach (var item in orderItems)
            {
                OrderRow newRow = new OrderRow()
                {
                    Price = (decimal)item.Price
                };

                newRow.MovieId = item.Id;

                tempRows.Add(newRow);
            }
            newOrder.OrderRows = tempRows;
            _db.Orders.Add(newOrder);
            _db.SaveChanges();
            

            return RedirectToAction("OrderConfirmation", newOrder);
        }

        public ActionResult OrderConfirmation(Order order)
        {
            Order order2 = _db.Orders.FirstOrDefault(o => o.Id == order.Id);
            
            ViewBag.Message = "Thank you for your order " + order2.Customer.FirstName + " " + order2.Customer.LastName + "!";
            Session.Clear();

            return View(order);

        }

        //if (cartItems != null)
        //{
        //    for (int i = 0; i < cartItems.Count-1; i++)
        //    {
        //        if (tempList.Count > 0)
        //        {
        //            for (int j = 0; j < tempList.Count - 1; j++)
        //            {
        //                if (tempList[j].Title == cartItems[i].Title)
        //                {
        //                    tempList[j].AggregatePriceMovie += cartItems[i].Price;
        //                    tempList[j].MovieQty++;
        //                    found = true;
        //                }
        //            }
        //            if (!found)
        //            {
        //                tempList.Add(new ViewMovie
        //                {
        //                    Title = cartItems[i].Title,
        //                    AggregatePriceMovie = cartItems[i].Price,
        //                    MovieQty = 1
        //                });

        //            }

        //    }

        //       else
        //            {
        //                tempList.Add(new ViewMovie {
        //                    Title = cartItems[i].Title,
        //                    AggregatePriceMovie = cartItems[i].Price,
        //                    MovieQty = 1 });
        //            }

        //        cartView.TotalPrice += cartItems[i].Price;
        //    }

        //    cartView.MovieListCart = tempList;

        //    return View("DisplayCart",cartView);
        //}



        //from ci in cartItems
        //                          group ci by ci.Id into g
        //                          select new ViewMovie
        //                           {
        //                               Id = g.FirstOrDefault().Id,
        //                               Title = g.FirstOrDefault().Title,
        //                               ItemPrice = g.FirstOrDefault().Price,
        //                               MovieQty = g.Count(),
        //                               AggregatePriceMovie = g.FirstOrDefault().Price* g.Count()
        //                           };


}
}