using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement1.Controllers
{
    public class WelcoeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
