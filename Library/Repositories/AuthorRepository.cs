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

        public AuthorRepository(LibraryContext c)
        {
            context = c;
        }

        public void Add(Author item)
        {
            context.Authors.Add(item);
            context.SaveChanges();
        }

        public IEnumerable<Author> All()
        {
            return context.Authors;
        }

        public void Edit(Author item)
        {
            context.SaveChanges();
        }

        public Author Find(int id)
        {
            return context.Authors.Find(id);
        }

        public void Remove(Author item)
        {
            context.Authors.Remove(item);
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
