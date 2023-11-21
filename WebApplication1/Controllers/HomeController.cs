using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using WebApplication1.DAL;
using WebApplication1.Models;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _logger;

        public HomeController(AppDbContext logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
          

            return View();
        }

    }
}