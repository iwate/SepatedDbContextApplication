using SepatedDbContextApplication.Entity;
using System.Data.Entity;

namespace SepatedDbContextApplication.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DefaultConnection") { }
        public static DataContext Create()
        {
            return new DataContext();
        }
        public DbSet<Datum> Data { get; set; }
    }
}
