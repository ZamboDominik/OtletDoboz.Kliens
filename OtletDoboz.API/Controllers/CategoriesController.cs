using Microsoft.AspNetCore.Mvc;
using OtletDoboz.API.Data;
using OtletDoboz.Models;

namespace OtletDoboz.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        public CategoriesController()
        {
            
        }
        [HttpGet]
        public IActionResult GetCategories() 
        {
            return Ok(MockDatabase.categories);
        }
        [HttpPost]
        public IActionResult PostNewCategory(Category category) 
        {
            if(!MockDatabase.categories.Contains(category)) MockDatabase.categories.Add(category);
            if (MockDatabase.categories.Contains(category)) return Ok(new { message = "Hozzáadva vagy már volt." });
            else return BadRequest();
        }
    }
}
