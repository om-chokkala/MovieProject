using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieProject.Models;

namespace MovieProject.Controllers
{
    public class MovieController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();


        
        public ActionResult AddMovie()
        {
            Movie addmovie = new Movie();

            return View(addmovie);
        }
        [HttpPost]
        public ActionResult AddMovie( Movie newMovie)
        {
            string temp = newMovie.ImageUrl;
            newMovie.ImageUrl = "~/Content/Images/" + temp;
            _db.Movies.Add(newMovie);
            _db.SaveChanges();
            return RedirectToAction("DisplayMovies");
        }
        public ActionResult DisplayMovies()
        {
            List<Movie> movieList = new List<Movie>();
            movieList = _db.Movies.ToList();
            return View(movieList);
        }

        //public ActionResult DisplayMovie(Movie movie)
        //{

        //    return PartialView(movie);
        //}

    }
}