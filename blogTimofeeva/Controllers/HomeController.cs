using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using blogTimofeeva.Models;

namespace blogTimofeeva.Controllers
{
    /// <summary>
    /// контроллер для работы с главной страницей
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// переменная для ведения журнала
        /// </summary>
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Конструктор класса HomeController
        /// </summary>
        /// <param name="logger"></param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// главная страница
        /// </summary>
        /// <returns>код htmlcs главной страницы</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// страница конфиденциальности
        /// </summary>
        /// <returns>код htmlcs страницы конфиденциальности</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// страница ошибка
        /// </summary>
        /// <returns>код htmlcs с ошибкой</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
