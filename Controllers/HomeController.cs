using fiorello.DAL;
using fiorello.Models;
using fiorello.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace fiorello.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM();
            homeVM.sliders= _context.sliders.ToList();
            homeVM.pageIntro= _context.pageIntros.FirstOrDefault();
            homeVM.categories = _context.categories.ToList();
            return View(homeVM);
        }
    }
}
