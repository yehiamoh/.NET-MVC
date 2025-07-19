using Bulky_MVC.Data;
using Bulky_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulky_MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Category> CategoriesList= _dbContext.Categories.ToList();
            return View(CategoriesList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            bool IsCategoryNumber= category.Name.All(char.IsDigit);

            if (IsCategoryNumber)
            {
                ModelState.AddModelError("Name", "The Name Must Be A Characters");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
    }
}
