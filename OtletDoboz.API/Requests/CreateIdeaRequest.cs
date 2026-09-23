using System.ComponentModel.DataAnnotations;

namespace OtletDoboz.API.Requests
{
    public class CreateIdeaRequest
    {
        [Required]
        [StringLength(50,MinimumLength = 3)]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public bool isPrivate { get; set; } = false;
        
    }
}
