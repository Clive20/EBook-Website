using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBooks.Controllers
{
    public class AuthController : Controller
    {
        private readonly EBooksContext _context;
        public AuthController(EBooksContext context)
        {
            _context = context;
        }

        [HttpGet]
        // GET: Auth/Login
        public IActionResult Login()
        {
            //if user will login then customer will redirected to home page, user will not
            //able to login again
            var customerId = HttpContext.Session.GetString("customerId");
            if (customerId != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: Auth/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("CustomerEmail,CustomerPassword")] Customer user)
        {
            //customer user will login, also i am using session here, to manage
            // the application authorization/security
            var result = _context.Customers.Where(e => e.CustomerEmail == user.CustomerEmail && e.CustomerPassword == user.CustomerPassword).FirstOrDefault();
            if (result != null)
            {
                    HttpContext.Session.SetString("customerFullName", result.CustomerName);
                    HttpContext.Session.SetString("customerId", result.CustomerId.ToString());
                    HttpContext.Session.SetString("role", "customer");
                    return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["invalidMessage"] = "Email or password is wrong";
                return View();
            }

        }

        [HttpGet]
        // GET: Auth/Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        // GET: Auth/Register
        public IActionResult Register(Customer customer)
        {
            //here customer will be able to register their accounts
            var result = _context.Customers.Where(x=>x.CustomerEmail == customer.CustomerEmail).FirstOrDefault();
            if (result!=null)
            {
                ViewData["errorMessage"] = "Email is already registered";
            }
            else
            {
                customer.Role = "customer";
                _context.Add(customer);
                _context.SaveChanges();
                TempData["successMessage"] = "Your account is created please login";
                return RedirectToAction("Login", "Auth");
            }
            return View();
        }


        [HttpGet]
        // GET: Auth/SignIn
        //for admin
        public IActionResult SignIn()
        {
            //here admin will be able to login, admin username and password is stored in admin table
            var adminId = HttpContext.Session.GetString("adminId");
            if (adminId != null)
            {
                return RedirectToAction("Index", "ManageCategories");
            }
            return View();
        }

        // POST: Auth/SignIn
        //for admin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn([Bind("Username,Password")] Admin admin)
        {
            var result = _context.Admins.Where(e => e.Username == admin.Username && e.Password == admin.Password).FirstOrDefault();
            if (result != null)
            {
                HttpContext.Session.SetString("adminFullName", result.FullName);
                HttpContext.Session.SetString("adminId", result.AdminId.ToString());
                HttpContext.Session.SetString("role", "admin");
                return RedirectToAction("Index", "ManageCategories");
            }
            else
            {
                ViewData["invalidMessage"] = "Username or password is wrong";
                return View();
            }

        }


        //for admin
        public IActionResult AdminLogout()
        {
            HttpContext.Session.Remove("adminFullName");
            HttpContext.Session.Remove("adminId");
            HttpContext.Session.Remove("role");
            return RedirectToAction("Index", "Home");
        }
        //for customer
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("customerFullName");
            HttpContext.Session.Remove("customerId");
            HttpContext.Session.Remove("role");
            HttpContext.Session.Remove("totalCartItems");
            return RedirectToAction("Index", "Home");
        }


    }
}
