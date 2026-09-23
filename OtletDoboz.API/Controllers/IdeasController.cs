using Microsoft.AspNetCore.Mvc;
using OtletDoboz.API.Data;
using OtletDoboz.API.Requests;
using OtletDoboz.Models;

namespace OtletDoboz.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdeasController : Controller
    {
        public IdeasController()
        {
            
        }
        [HttpGet]
        public IActionResult GetIdeas() 
        {
            return Ok(MockDatabase.ideas.Where(e => !e.isPrivate));
        }
        [HttpGet("{id}")]
        public IActionResult GetIdea(int id) 
        {

            Idea idea = MockDatabase.ideas.FirstOrDefault(i => i.Id == id);
            if (idea == null) return BadRequest();
            if (idea.isPrivate) return Unauthorized();
            return Ok(idea);
        }
        [HttpPost]
        public IActionResult PostNewIdea(CreateIdeaRequest request) 
        {
            Idea newIdea = new Idea(MockDatabase.IdeasLastId(), request.Title, request.Description, MockDatabase.categories.FirstOrDefault(c => c.Id == request.CategoryId),isPrivate:request.isPrivate,votes:0,created:DateTime.Now);
            MockDatabase.ideas.Add(newIdea);
            return Ok( new { message = "Sikeres kreáció" });
        }

    }
}
