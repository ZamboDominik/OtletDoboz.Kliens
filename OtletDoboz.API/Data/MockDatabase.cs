using OtletDoboz.Models;
namespace OtletDoboz.API.Data
{
    public static class MockDatabase
    {
        public static List<Idea> ideas { get; set; } = new List<Idea>();
        public static List<Category> categories { get; set; } = new List<Category>();
        static MockDatabase()
        {
            categories.Add(new Category(1,"HR"));    
            categories.Add(new Category(2,"Program"));    
            categories.Add(new Category(3,"Ebéd"));

            ideas.Add(new Idea("Pizza","Legyen Pizza",2,0,false,DateTime.Now));
        }
        public static int IdeasLastId()
        {
            if (ideas.Count == 0) return 0;
            return ideas[ideas.Count-1].Id + 1;
        }
        public static int CategoriesLastId()
        {
            if (categories.Count == 0) return 0;
            return categories[ideas.Count - 1].Id + 1;
        }
    }
}
