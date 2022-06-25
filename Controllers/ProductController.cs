using fiorello.DAL;
using fiorello.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace fiorello.Controllers
{
    public class ProductController : Controller
    {
        private AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.ProductCount = _context.products.Count();
            List<Product>products = _context.products.Include(p => p.Category).OrderByDescending(p=>p.Id).Take(2).ToList();
            return View(products);
        }
        public IActionResult LoadMore(int skip)
        {
            List<Product> products = _context.products.Include(p => p.Category).Skip(skip).Take(2).ToList();
            return PartialView("_ProductPartial",products);
        }
    }
}
