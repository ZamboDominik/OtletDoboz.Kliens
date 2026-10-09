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
        IdeaDBContext db;
        public IdeasController()
        {
            db = new IdeaDBContext();
        }
        [HttpGet]
        public IActionResult GetIdeas() 
        {
            return Ok(db.ideas.Where(e => !e.isPrivate));
        }
        [HttpGet("{id}")]
        public IActionResult GetIdea(int id) 
        {

            Idea idea = db.ideas.FirstOrDefault(i => i.Id == id);
            if (idea == null) return BadRequest();
            if (idea.isPrivate) return Unauthorized();
            return Ok(idea);
        }
        [HttpPost]
        public IActionResult PostNewIdea(CreateIdeaRequest request) 
        {
            Idea newIdea = new Idea(request.Title, request.Description,request.CategoryId,isPrivate:request.isPrivate,votes:0,created:DateTime.Now);
            db.ideas.Add(newIdea);
            db.SaveChanges();
            return Ok( new { message = "Sikeres kreáció" });
        }

    }
}
