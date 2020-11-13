using Microsoft.EntityFrameworkCore;

namespace BookLibrary
{
    public class BooksContext : DbContext
    {
        public BooksContext()
        {

        }

        public BooksContext(DbContextOptions<BooksContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var books = modelBuilder.Entity<Book>();

            books.ToTable("Volumes");

            books.Property(b => b.Title).IsRequired();

            books.HasKey(b =>  b.ISBN);

            //books.Ignore(b => b.Price);

            books.HasOne(b => b.Author).WithMany(a => a.Books).HasForeignKey("Id_Author").IsRequired();

            books.Property(b => b.YearOfPublication).HasColumnName("Year");

            books.Property(b => b.Title).HasMaxLength(30);

            books.Property(b => b.Price).HasColumnType("decimal(5,2)");

            modelBuilder.Entity<Author>().Property(a => a.DateOfBirth).HasColumnType("date");
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
