using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogTimofeeva.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace blogTimofeeva.Controllers
{
    /// <summary>
    ///  контроллер для управления блогом
    /// </summary>
    public class BlogController : Controller
    {
        //информация о сервере
        private readonly IOptions<ServerInformation>  _serverInformation;

        /// <summary>
        /// Конструктор контроллера BlogController
        /// </summary>
        /// <param name="serverInformation"></param>
        public BlogController(IOptions<ServerInformation> serverInformation)
        {
            _serverInformation = serverInformation;
        }

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
