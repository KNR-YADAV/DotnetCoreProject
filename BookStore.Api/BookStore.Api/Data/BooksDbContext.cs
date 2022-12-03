using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Data
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext()
        {
                
        }
        public BooksDbContext(DbContextOptions<BooksDbContext> options):base(options)
        {
           
        }
        public DbSet<Books> books { get; set; }
        
    }
}
