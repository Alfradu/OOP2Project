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

        /// <summary>
        /// Sets the current database context.
        /// </summary>
        /// <param name="c">A Librarycontext that will be shared among repositories</param>
        public BookCopyRepository(LibraryContext c)
        {
            context = c;
        }

        /// <summary>
        /// Add a bookCopy to database.
        /// </summary>
        /// <param name="item">BookCopy item to be added to db.</param>
        public void Add(BookCopy item)
        {
            context.BookCopies.Add(item);
            context.SaveChanges();
        }

        /// <summary>
        /// Retrieves all bookCopies.
        /// </summary>
        /// <returns>Returns an IEnumerable of all bookCopies.</returns>
        public IEnumerable<BookCopy> All()
        {
            return context.BookCopies;
        }

        /// <summary>
        /// Saves changes as a specific item in the db has changed.
        /// </summary>
        /// <param name="item">Supposedly the item that has been changed.</param>
        public void Edit(BookCopy item)
        {
            context.SaveChanges();
        }

        /// <summary>
        /// Finds a bookCopy corresponding to the given parameter id.
        /// </summary>
        /// <param name="id">Id of a bookCopy.</param>
        /// <returns>Returns a bookCopy corresponding to parameter.</returns>
        public BookCopy Find(int id)
        {
            return context.BookCopies.Find(id);
        }

        /// <summary>
        /// Removes a bookCopy from the db.
        /// </summary>
        /// <param name="item">BookCopy to be removed from db.</param>
        public void Remove(BookCopy item)
        {
            context.BookCopies.Remove(item);
            context.SaveChanges();
        }

        /// <summary>
        /// Rollback database to ignore a pending update.
        /// </summary>
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
