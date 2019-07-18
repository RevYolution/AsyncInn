using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AsyncInn.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Directs to the Home Page of the Application
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}