using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SysTech.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SysTech.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly OfficeContext officeContext;

        public HomeController(ILogger<HomeController> logger, IOptions<DBOptions> dbOtions)
        {
            var connString = dbOtions.Value.ConnString;
            officeContext = new OfficeContext(connString);
            _logger = logger;
        }

        public IActionResult Index()
        {
            var allPositions = officeContext.Positions.ToList();
            var allWorkers = officeContext.Workers.ToList();
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
