using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace blogTimofeeva.Controllers
{
    /// <summary>
    ///  контроллер для работы с блогом
    /// </summary>
    public class BlogController : Controller
    {
        /// <summary>
        /// страница блога
        /// </summary>
        /// <returns>код htmlcs блога</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
