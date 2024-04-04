using Microsoft.EntityFrameworkCore;

namespace todolist.Data
{
    public class DataContext : DbContext

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Gorev> Gorevler => Set<Gorev>();

    }

}