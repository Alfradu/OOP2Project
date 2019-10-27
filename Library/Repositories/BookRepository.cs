using System.Collections.Generic;
using System.Linq;
using Library.Models;

namespace Library.Repositories
{
    /// <summary>
    /// Repository for handling Book-related database actions.
    /// </summary>
    public class BookRepository : IRepository<Book, int>
    {
        LibraryContext context;

        public BookRepository(LibraryContext c)
        {
            context = c;
        }

        public void Add(Book item)
        {
            context.Books.Add(item);
            context.SaveChanges();
        }

        public IEnumerable<Book> All()
        {
            return context.Books;
        }

        public void Edit(Book b)
        {
            context.SaveChanges();
        }

        public Book Find(int id)
        {
            return context.Books.Find(id);
        }

        public void Remove(Book item)
        {
            context.Books.Remove(item);
            context.SaveChanges();
        }

        public void Reset()
        {
            var entries = context.ChangeTracker.Entries().Where(e => e.State != System.Data.Entity.EntityState.Unchanged).ToArray();
            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case System.Data.Entity.EntityState.Modified:
                        entry.State = System.Data.Entity.EntityState.Unchanged;
                        break;
                    case System.Data.Entity.EntityState.Added:
                        entry.State = System.Data.Entity.EntityState.Detached;
                        break;
                    case System.Data.Entity.EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }
    }
}