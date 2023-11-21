using Microsoft.AspNetCore.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ServiceController : Controller
    {
        private readonly AppDbContext _services;

        public ServiceController(AppDbContext appDb)
        {
            _services = appDb;
        }

        public IActionResult Index()
        {
            List<Service> src = _services.Services.ToList();
            return View(src);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _services.Services.Add(service);
            _services.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Service wantedService = _services.Services.FirstOrDefault(s => s.Id == id);

            if (wantedService == null) return NotFound();

            return View(wantedService);
        }

        [HttpPost]
        public IActionResult Update(Service service)
        {
            if (!ModelState.IsValid) return View();

            Service existService = _services.Services.FirstOrDefault(x => x.Id == service.Id);

            if (existService == null) return NotFound();

            existService.Title = service.Title;
            existService.Description = service.Description;
            existService.Logo = service.Logo;

            _services.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Service wantedService = _services.Services.FirstOrDefault(s => s.Id == id);

            if (wantedService == null) return NotFound();

            return View(wantedService);
        }

        [HttpPost]
        public IActionResult Delete(Service service)
        {
            Service existService = _services.Services.FirstOrDefault(x => x.Id == service.Id);

            if (existService == null)
            {
                return NotFound();
            }

            _services.Services.Remove(existService);
            _services.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
