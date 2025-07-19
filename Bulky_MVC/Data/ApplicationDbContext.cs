using Bulky_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky_MVC.Data
{
    public class ApplicationDbContext:DbContext
    {
      public DbSet<Category> Categories { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { ID=1,Name="Action",DisplayOrder=1},
                new Category { ID=2,Name="SciFi",DisplayOrder=2},
                new Category { ID=3,Name="History",DisplayOrder=3}
                //new Category { ID=4,Name="Action",DisplayOrder=1},
                //new Category { ID=5,Name="Action",DisplayOrder=1},
                //new Category { ID=6,Name="Action",DisplayOrder=1},
                //new Category { ID=7,Name="Action",DisplayOrder=1}
                
                );
        }

    }
}
