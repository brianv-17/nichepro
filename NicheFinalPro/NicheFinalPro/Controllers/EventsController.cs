using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NicheFinalPro.Data;
using NicheFinalPro.Models;

namespace NicheFinalPro.Controllers
{
    public class EventsController : Controller
    {
        private ApplicationDbContext _context;
        
        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }
        //[Authorize]
        public IActionResult Index()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login","Account");
            }



            var events = _context.Events.ToList();
            return View(events);
        }
        //public async Task<IActionResult> Index()
        //{
        //    var events = await _context.Events.ToListAsync();
        //    return View(events);
        //}
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Event evnt)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Events.AddAsync(evnt);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Something went wrong{ex.Message}");
                    
                }

            }
            ModelState.AddModelError(string.Empty, $"Something went wrong");
            return View();
        }
        [HttpGet]
        public async Task<IActionResult>Edit(int id)
        {
            var evnt = await _context.Events.FirstOrDefaultAsync(p => p.Id == id);
            return View(evnt);
        }
        [HttpPost]
        public async Task<IActionResult>Edit(Event evnt)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var exist = await _context.Events.FirstOrDefaultAsync(p => p.Id == evnt.Id);

                    if(exist != null)
                    {
                        exist.Title = evnt.Title;
                        exist.Theme = evnt.Theme;
                        exist.Place = evnt.Place;
                        exist.Date = evnt.Date;
                        exist.Description = evnt.Description;


                        await _context.SaveChangesAsync();
                        return RedirectToAction("Index");
                    }
                    ModelState.AddModelError(string.Empty, $"Something went wrong");
                    return View(evnt);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Something went wrong{ex.Message}");

                }

            }
            ModelState.AddModelError(string.Empty, $"Something went wrong");
            return View(evnt);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var evnt = await _context.Events.FirstOrDefaultAsync(p => p.Id == id);
            return View(evnt);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Event evnt)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var exist = await _context.Events.FirstOrDefaultAsync(p => p.Id == evnt.Id);

                    if (exist != null)
                    {
                        _context.Events.Remove(exist);
                        await _context.SaveChangesAsync();

                        return RedirectToAction("Index");
                    }
                    ModelState.AddModelError(string.Empty, "Invalid deletion");
                    return View(evnt);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Invalid deletion {ex.Message}");

                }
            }
            ModelState.AddModelError(string.Empty, "Invalid deletion");
            return View(evnt);
        }
    }
}
