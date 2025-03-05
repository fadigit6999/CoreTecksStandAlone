using System.Diagnostics;
using CoreTechs.Web.Models;
using CoreTechs.Web.Models.ModelEntities;
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

        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return PartialView("~/Views/Shared/Home/_EmployeeModal.cshtml", new Employees());
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employees model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Example: Saving the employee to the database
                    _employeeService.AddEmployees(model.Name, model.Phone, model.Address, model.Salary);

                    return Json(new { success = true }); // Redirect to the Index or Employee List page
                }
                catch (Exception ex)
                {
                    // Log the exception and show an error message
                    ModelState.AddModelError("", $"An error occurred while saving the employee: {ex.Message}");
                }
            }

            // If we got this far, something failed; redisplay the form
            return View(model);
        }

        [HttpGet]
        public IActionResult UpdateEmployee(int id)
        {
            var employee = _employeeService.GetEmployees().Where(x => x.Id == id).FirstOrDefault();
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateEmployee(Employees model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Example: Saving the employee to the database
                    _employeeService.UpdateEmployees(model.Id, model.Name, model.Phone, model.Address, model.Salary);

                    return Redirect("/Home/GetEmployee/2");
                }
                catch (Exception ex)
                {
                    // Log the exception and show an error message
                    ModelState.AddModelError("", $"An error occurred while saving the employee: {ex.Message}");
                }
            }

            // If we got this far, something failed; redisplay the form
            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _employeeService.GetEmployees().Where(x => x.Id == id).FirstOrDefault();
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmployee(Employees model)
        {
            try
            {
                // Example: Saving the employee to the database
                _employeeService.DeleteEmployees(model.Id);

                return Redirect("/Home/GetEmployee/3");
            }
            catch (Exception ex)
            {
                // Log the exception and show an error message
                ModelState.AddModelError("", $"An error occurred while saving the employee: {ex.Message}");
            }

            // If we got this far, something failed; redisplay the form
            return View(model);
        }

        #endregion

    }
}
