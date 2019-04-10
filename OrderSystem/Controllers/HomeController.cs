using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderSystem.Models;


namespace OrderSystem.Controllers
{
    public class HomeController : Controller
    {
       
        OrderingSystemContext _context;

        public HomeController(OrderingSystemContext context)
        {
            _context = context;
        }
       
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Signup()
        {
            if (TempData["Error"] != null)
            {
                ViewData["Error"] = TempData["Error"];
            }
            return View();
        }

        [HttpPost]
        public IActionResult Save(IFormCollection keyValues)
        {
            var firstname = keyValues["firstname"][0];
            var lastname = keyValues["lastname"][0];
            var address = keyValues["address"][0];
            var emailid = keyValues["emailid"][0];
            var password = keyValues["password"][0];
            var dob = keyValues["dob"][0];
            DateTime date = Convert.ToDateTime(dob);
            var city = keyValues["city"][0];
            var zipcode = keyValues["zipcode"][0];
            var state = keyValues["state"][0];

            var isUSerAlreadyInDB = false;
            isUSerAlreadyInDB = _context.User_Registration.Where(x => x.Email_ID.ToLower() == emailid.ToLower()).Any();
            if(isUSerAlreadyInDB)
            {
                TempData["Error"] = "user already in the system";
                TempData.Keep("Error");
                return RedirectToAction("Signup");
            }
            User_Registration user_Registration = new User_Registration();
            user_Registration.First_Name = firstname;
            user_Registration.Last_Name = lastname;
            user_Registration.User_Address = address;
            user_Registration.Email_ID = emailid;
            user_Registration.User_Password = password;
            user_Registration.Date_Of_Birth = date;
            user_Registration.City_Name = city;
            user_Registration.Zip_Code = zipcode;
            user_Registration.State_Name = state;
            user_Registration.User_Status = true;
            try
            {
                _context.User_Registration.Add(user_Registration);
                _context.SaveChanges();
              
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exeception error", ex);
            }
            return RedirectToAction("Login");


        }
       
        public IActionResult Login()
        {
            if (TempData["Error"] != null)
            {
                ViewData["Error"] = TempData["Error"];
            }
            return View();
        }

        public IActionResult LoginValidate(IFormCollection keyValues)
        {
            var emailid = keyValues["emailid"][0];
            var password = keyValues["password"][0];
            User_Registration user_Registration = new User_Registration();
            user_Registration.Email_ID = emailid;
            user_Registration.User_Password = password;

            var IsUserValidate = true;
            IsUserValidate = _context.User_Registration.Where(x => x.Email_ID.ToLower() == emailid.ToLower() && x.User_Password == password).Any() ;
            if (IsUserValidate  == false)
            {
                TempData["Error"] = "User Name or Password is incorrect!! Please try again";
                TempData.Keep("Error");
                return RedirectToAction("Login");
            }
            return RedirectToAction("About");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
    

        public IActionResult Privacy()
        {
            return View();
        }
      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
