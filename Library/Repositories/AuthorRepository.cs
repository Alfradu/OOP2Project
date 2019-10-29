using Library.Models;
using System.Collections.Generic;
using System.Linq;

namespace Library.Repositories
{
    /// <summary>
    /// Repository for handling Author-related database actions.
    /// </summary>
    public class AuthorRepository : IRepository<Author, int>
    {
        LibraryContext context;

        /// <summary>
        /// Sets the current database context.
        /// </summary>
        /// <param name="c">A Librarycontext that will be shared among repositories</param>
        public AuthorRepository(LibraryContext c)
        {
            context = c;
        }

        /// <summary>
        /// Add an author to database.
        /// </summary>
        /// <param name="item">Author item to be added to db.</param>
        public void Add(Author item)
        {
            context.Authors.Add(item);
            context.SaveChanges();
        }

        /// <summary>
        /// Retrieves all authors.
        /// </summary>
        /// <returns>Returns an IEnumerable of all authors.</returns>
        public IEnumerable<Author> All()
        {
            return context.Authors;
        }

        /// <summary>
        /// Saves changes as a specific item in the db has changed.
        /// </summary>
        /// <param name="item">Supposedly the item that has been changed.</param>
        public void Edit(Author item)
        {
            context.SaveChanges();
        }

        /// <summary>
        /// Finds an author corresponding to the given parameter id.
        /// </summary>
        /// <param name="id">Id of an author.</param>
        /// <returns>Returns an author corresponding to parameter.</returns>
        public Author Find(int id)
        {
            return context.Authors.Find(id);
        }

        /// <summary>
        /// Removes an author from the db.
        /// </summary>
        /// <param name="item">Author to be removed from db.</param>
        public void Remove(Author item)
        {
            context.Authors.Remove(item);
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
