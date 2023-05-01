using Microsoft.AspNetCore.Mvc;
using QuarterlySales.Models;
using QuarterlySales.Models.Validation;

namespace QuarterlySales.Controllers
{
    public class EmployeeController : Controller
    {
        private SalesContext context { get; set; }

        public EmployeeController(SalesContext ctx) => context = ctx;
        public IActionResult Index() => RedirectToAction("Index", "Home");

        [HttpGet]

        public IActionResult Add()
        {
            ViewBag.Employees = context.Employees.OrderBy(e => e.Firstname).ToList();
            return View();
        }

        [HttpPost]

        public IActionResult Add(Employee employee)
        {
            string msg = Validate.CheckEmployee(context, employee);
            if (!string.IsNullOrEmpty(msg))
            {
                ModelState.AddModelError(nameof(employee.ManagerId), msg);
            }

            if (ModelState.IsValid)
            {
                context.Employees.Add(employee);
                context.SaveChanges();
                TempData["message"] = "Information added";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Employees = context.Employees.OrderBy(e => e.Firstname).ToList();
                return View();
            }

        }

    }
}
