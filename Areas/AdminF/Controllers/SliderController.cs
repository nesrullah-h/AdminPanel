using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using fiorello.DAL;
using fiorello.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fiorello.Areas.AdminF.Controllers
{
    [Area("AdminF")]
    public class SliderController : Controller
    {
        private AppDbContext _context;
        private IWebHostEnvironment _env;
        public SliderController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Slider> sliders = _context.sliders.ToList();
            return View(sliders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            if(ModelState["Photo"].ValidationState==Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }
            if(slider.Photo.ContentType.Contains("image"))
            {

                ModelState.AddModelError("Photo", "accept only image");
                return View();
            }
            if (slider.Photo.Length/1024>10000)
            {
                ModelState.AddModelError("Photo", "1 mg yuxari ola bilmez");
                return View();
            }
            //string path = @"/Users/ilkinibrahimov/Desktop/fiorello-master/wwwroot/img";
            string path = _env.WebRootPath;
            string fileName = Guid.NewGuid().ToString() + slider.Photo.FileName;
            string result = Path.Combine(path,"img",fileName);

            using (FileStream stream=new FileStream(result,FileMode.Create))
            {
               await slider.Photo.CopyToAsync(stream);
            };
            Slider newSlider = new Slider();
            newSlider.ImageUrl = fileName;
            await _context.sliders.AddAsync(newSlider);
            await _context.SaveChangesAsync();
            return Content($"{fileName}");
        }
    }
}
