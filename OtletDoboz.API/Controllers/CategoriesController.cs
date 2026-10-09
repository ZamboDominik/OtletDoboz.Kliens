using Microsoft.AspNetCore.Mvc;
using OtletDoboz.API.Data;
using OtletDoboz.Models;

namespace OtletDoboz.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        public IdeaDBContext db;
        public CategoriesController()
        {
            db = new IdeaDBContext();
        }
        [HttpGet]
        public IActionResult GetCategories() 
        {
            return Ok(db.categories);
        }
        [HttpPost]
        public IActionResult PostNewCategory(Category category) 
        {
           
            if (!db.categories.Contains(category))
            {
                db.categories.Add(category);
                db.SaveChanges();
            }
            if (db.categories.Contains(category)) return Ok(new { message = "Hozzáadva vagy már volt." });
            else return BadRequest();
        }
    }
}
