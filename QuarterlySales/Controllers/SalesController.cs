﻿using Microsoft.AspNetCore.Mvc;
using QuarterlySales.Models;
using QuarterlySales.Models.Validation;

namespace QuarterlySales.Controllers
{
    public class SalesController : Controller
    {
        private SalesContext context { get; set; }
        public SalesController(SalesContext ctx) => context = ctx;

        public IActionResult Index() => RedirectToAction("Index", "Home");

        [HttpGet]

        public IActionResult Add()
        {
            ViewBag.Employees = context.Employees.OrderBy(e => e.Firstname).ToList();
            return View();
        }
        [HttpPost]

        public IActionResult Add(Sales sales)
        {
            string msg = Validate.CheckSales(context, sales);
            if (!string.IsNullOrEmpty(msg))
            {
                ModelState.AddModelError(nameof(sales.EmployeeId), msg);
            }

            if (ModelState.IsValid)
            {
                context.Sales.Add(sales);
                context.SaveChanges();
                TempData["message"] = "Sales added";
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
