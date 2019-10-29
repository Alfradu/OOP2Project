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

        /// <summary>
        /// Sets the current database context.
        /// </summary>
        /// <param name="c">A Librarycontext that will be shared among repositories</param>
        public BookRepository(LibraryContext c)
        {
            context = c;
        }

        /// <summary>
        /// Add a book to database.
        /// </summary>
        /// <param name="item">Book item to be added to db.</param>
        public void Add(Book item)
        {
            context.Books.Add(item);
            context.SaveChanges();
        }

        /// <summary>
        /// Retrieves all books.
        /// </summary>
        /// <returns>Returns an IEnumerable of all books.</returns>
        public IEnumerable<Book> All()
        {
            return context.Books;
        }

        /// <summary>
        /// Saves changes as a specific item in the db has changed.
        /// </summary>
        /// <param name="item">Supposedly the item that has been changed.</param>
        public void Edit(Book b)
        {
            context.SaveChanges();
        }

        /// <summary>
        /// Finds a book corresponding to the given parameter id.
        /// </summary>
        /// <param name="id">Id of a book.</param>
        /// <returns>Returns a book corresponding to parameter.</returns>
        public Book Find(int id)
        {
            return context.Books.Find(id);
        }

        /// <summary>
        /// Removes a book from the db.
        /// </summary>
        /// <param name="item">Book to be removed from db.</param>
        public void Remove(Book item)
        {
            context.Books.Remove(item);
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