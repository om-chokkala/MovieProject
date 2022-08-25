using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieProject.Models;


namespace MovieProject.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Customer
        public ActionResult CheckCustomer(string email)
        {
            Customer existCustomer = _db.Customers.Where(c => c.Email == email).FirstOrDefault();
            if (existCustomer != null)
            {
                return RedirectToAction("OrderRegistration", "Order", existCustomer);
            }
            else
            {
                return RedirectToAction("AddCustomer", "Customer");
            }
        
        }

        public ActionResult AddCustomer()
        {
            Customer newCustomer = new Customer();
            
            return View(newCustomer);
        }

        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            var addCustomer = _db.Customers.Add(customer);
            return RedirectToAction("OrderRegistration", "Order", addCustomer);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email)
        {
          
            Customer customer = _db.Customers.Where(c => c.Email == email).FirstOrDefault();
            if (customer == null)
            {
                TempData["Message"] = "Your e-mail was not found";
                return RedirectToAction("AddCustomer");
            }

            return RedirectToAction("OrderRegistration", "Order", customer);

          
        }

    }
}