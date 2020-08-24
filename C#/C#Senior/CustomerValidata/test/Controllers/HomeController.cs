using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using test.Models;

namespace test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Test(PersonData person)
        {
            //Console.WriteLine(ModelState.IsValid);
            //foreach (var prop in ModelState.Values)
            //{
            //    foreach (var error in prop.Errors)
            //    {
            //        Console.WriteLine(error.ErrorMessage);
            //    }
            //}

            foreach (var prop in person.Validate(null))
            {
                foreach (var name in prop.MemberNames)
                {
                    Console.WriteLine(name);
                }
                Console.WriteLine(prop.ErrorMessage);
            }
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
