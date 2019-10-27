using System.Collections.Generic;
using System.Linq;
using Library.Models;

namespace Library.Repositories
{
    /// <summary>
    /// Repository for handling BookCopy-related database actions.
    /// </summary>
    public class BookCopyRepository : IRepository<BookCopy, int>
    {
        LibraryContext context;

        public BookCopyRepository(LibraryContext c)
        {
            context = c;
        }

        public void Add(BookCopy item)
        {
            context.BookCopies.Add(item);
            context.SaveChanges();
        }

        public IEnumerable<BookCopy> All()
        {
            return context.BookCopies;
        }

        public void Edit(BookCopy item)
        {
            context.SaveChanges();
        }

        public BookCopy Find(int id)
        {
            return context.BookCopies.Find(id);
        }

        public void Remove(BookCopy item)
        {
            context.BookCopies.Remove(item);
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
