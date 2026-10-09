using Microsoft.EntityFrameworkCore;
using OtletDoboz.Models;
namespace OtletDoboz.API.Data
{
    public class IdeaDBContext: DbContext
    {
        public DbSet<Idea> ideas => Set<Idea>();
        public DbSet<Category> categories => Set<Category>();

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptions) 
        {
            var connectionString = "Server=localhost;Port=32768;Database=sys;User=root;Password=Teszt123;";

            dbContextOptions.UseMySQL(connectionString);
        }
        
    }
}
