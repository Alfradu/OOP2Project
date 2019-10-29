using Library.Models;
using System.Collections.Generic;
using System.Linq;

namespace Library.Repositories
{
    /// <summary>
    /// Repository for handling Author-related database actions.
    /// </summary>
    public class LoanRepository : IRepository<Loan, int>
    {
        LibraryContext context;

        /// <summary>
        /// Sets the current database context.
        /// </summary>
        /// <param name="c">A Librarycontext that will be shared among repositories</param>
        public LoanRepository(LibraryContext c)
        {
            this.context = c;
        }

        /// <summary>
        /// Add a loan to database.
        /// </summary>
        /// <param name="item">Loan item to be added to db.</param>
        public void Add(Loan item)
        {
            context.Loans.Add(item);
            context.SaveChanges();
        }

        /// <summary>
        /// Retrieves all loans.
        /// </summary>
        /// <returns>Returns an IEnumerable of all loans.</returns>
        public IEnumerable<Loan> All()
        {
            return context.Loans;
        }

        /// <summary>
        /// Saves changes as a specific item in the db has changed.
        /// </summary>
        /// <param name="item">Supposedly the item that has been changed.</param>
        public void Edit(Loan item)
        {
            context.SaveChanges();
        }

        /// <summary>
        /// Finds a loan corresponding to the given parameter id.
        /// </summary>
        /// <param name="id">Id of a loan.</param>
        /// <returns>Returns a loan corresponding to parameter.</returns>
        public Loan Find(int id)
        {
            return context.Loans.Find(id);
        }

        /// <summary>
        /// Removes a loan from the db.
        /// </summary>
        /// <param name="item">Loan to be removed from db.</param>
        public void Remove(Loan item)
        {
            context.Loans.Remove(item);
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
