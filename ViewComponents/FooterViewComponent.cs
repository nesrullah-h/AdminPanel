using fiorello.DAL;
using fiorello.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace fiorello.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private AppDbContext _context;
        public FooterViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Bio bio = _context.bios.FirstOrDefault();
            return View(await Task.FromResult(bio));
        }
    }
}
