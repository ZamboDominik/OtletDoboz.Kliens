
using System.ComponentModel.DataAnnotations.Schema;

namespace OtletDoboz.Models
{
    
    public class Idea
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int Votes { get; set; } = 0;
        public DateTime Created { get; private set; }
        public bool isPrivate { get; set; } = false;
        public Idea(string? title, string? content, int categoryId, int votes, bool isPrivate, DateTime created)
        {
            
            Title = title;
            Content = content;
            CategoryId = categoryId;
            Votes = votes;
            Created = created;
            this.isPrivate = isPrivate;
        }



    }
}
