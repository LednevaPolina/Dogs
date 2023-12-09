using Microsoft.EntityFrameworkCore;

namespace Dogs.Models
{
    public class DogDbContext:DbContext
    {
        public DogDbContext(DbContextOptions options) : base(options) 
        {
        
        }
        public DbSet<Dog>Dogs { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<DogTag> DogTags { get; set; }
        public DbSet<FCICategory> FCICategories { get; set; }
    }
}
