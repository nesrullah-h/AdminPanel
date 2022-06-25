using fiorello.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace fiorello.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base (options)
        {

        }

        public DbSet<Slider> sliders { get; set; }
        public DbSet<PageIntro> pageIntros { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Bio> bios { get; set; }
    }
}
