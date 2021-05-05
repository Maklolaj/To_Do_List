using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET5_test.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
            
        }

        public IActionResult Details(int id)
        {
            return Ok("You have entered id = " + id);
        }
    }
}
