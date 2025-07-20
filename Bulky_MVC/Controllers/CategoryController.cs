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
            TempData["success"] = "Category Created Successfully"; // Will Be Used In The View
            return RedirectToAction("Index", "Category");
        }

        public IActionResult Edit(int? id){
            if(id==0 || id == null)
            {
                return NotFound();
            }

            Category? category = _dbContext.Categories.Find(id);

            if (category == null) { 
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _dbContext.Categories.Update(category);
            TempData["success"] = "Category Edited Successfully"; // Will Be Used In The View
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Category");
        }

        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            Category? category = _dbContext.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? category = _dbContext.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
            TempData["success"] = "Category Deleted Successfully"; // Will Be Used In The View
            return RedirectToAction("Index", "Category");
        }
    }
}
 