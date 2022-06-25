using fiorello.DAL;
using fiorello.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fiorello.ViewComponents
{
    public class ProductsViewComponent:ViewComponent
    {
        private AppDbContext _context;
        public ProductsViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Product> products = _context.products.Include(p => p.Category).Take(8).ToList();
            return View(await Task.FromResult(products));
        }
    }
}
