using System.Diagnostics;
using CoreTechs.Web.Models;
using CoreTechs.Web.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreTechs.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EmployeeService _employeeService;

        public HomeController(ILogger<HomeController> logger,EmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
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

        #region Employee Management
        public IActionResult GetEmployee()
        {
            var model = _employeeService.GetEmployees().ToList();
            return View(model);
        }
        #endregion

    }
}
