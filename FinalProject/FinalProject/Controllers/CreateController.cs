using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject.Controllers
{
    public class CreateController : Controller
    {
        // GET: /<controller>/
        public IActionResult CreatePage()
        {
            return View();
        }
        public IActionResult Create(Event model)
        {
            if (ModelState.IsValid)
            {
                Event newEmployee = _eventRepository.AddEmployee(model);
                return RedirectToAction("Details", new { id = model.id });
            }
            else
            {
                throw new Exception();
            }

        }
    }
}
