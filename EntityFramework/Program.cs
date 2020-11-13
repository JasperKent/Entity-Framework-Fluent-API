using BookLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntityFramework
{
    class Program
    {       
        static void Main()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var options = new DbContextOptionsBuilder<BooksContext>()
                .UseSqlServer(config.GetConnectionString("BooksLibrary:SQLServer"))
                .Options;

            using var db = new BooksContext(options);

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
