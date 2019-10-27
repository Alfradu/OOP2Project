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

        public LoanRepository(LibraryContext c)
        {
            this.context = c;
        }

        public void Add(Loan item)
        {
            context.Loans.Add(item);
            context.SaveChanges();
        }

        public IEnumerable<Loan> All()
        {
            return context.Loans;
        }

        public void Edit(Loan item)
        {
            context.SaveChanges();
        }

        public Loan Find(int id)
        {
            return context.Loans.Find(id);
        }

        public void Remove(Loan item)
        {
            context.Loans.Remove(item);
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
