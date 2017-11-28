using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Test_Dot_Net
{
    public class EFCoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseMySql(@"Server=localhost;database=dotnet_test;uid=dotnet_test_user;pwd=1@&EyESh&r3XI!z@wkDz;");
    }
}
// dotnet_test_user      1@&EyESh&r3XI!z@wkDz