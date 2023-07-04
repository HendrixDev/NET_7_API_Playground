using Microsoft.EntityFrameworkCore;
using NET_7_API_Playground.Entities.Models;

namespace NET_7_API_Playground.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }
    }
}
