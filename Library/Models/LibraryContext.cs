using System.Data.Entity;

namespace Library.Models
{

    /// <summary>
    /// Derived context.
    /// </summary>
    public class LibraryContext : DbContext {
        public LibraryContext(){
            Database.SetInitializer<LibraryContext>(new LibraryDbInit());
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookCopy> BookCopies { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }
    }
}