namespace OtletDoboz.Models
{
    public class Idea
    {

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public Category? Category { get; set; }
        public int Votes { get; set; } = 0;
        public DateTime Created { get; private set; }
        public bool isPrivate { get; set; } = false;
        public Idea(int id, string? title, string? content, Category? category, int votes, bool isPrivate, DateTime created)
        {
            Id = id;
            Title = title;
            Content = content;
            Category = category;
            Votes = votes;
            Created = created;
            this.isPrivate = isPrivate;
        }



    }
}
