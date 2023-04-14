using Microsoft.EntityFrameworkCore;

namespace Network.API.Model
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions options) : base(options)
        {
        }


       public DbSet<Student> Students { get; set; }

    }
}
