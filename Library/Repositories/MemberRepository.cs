using Library.Models;
using System.Collections.Generic;
using System.Linq;

namespace Library.Repositories
{
    /// <summary>
    /// Repository for handling Member-related database actions.
    /// </summary>
    public class MemberRepository : IRepository<Member, int>
    {
        LibraryContext context;

        /// <summary>
        /// Sets the current database context.
        /// </summary>
        /// <param name="c">A Librarycontext that will be shared among repositories</param>
        public MemberRepository(LibraryContext c)
        {
            this.context = c;
        }

        /// <summary>
        /// Add a member to database.
        /// </summary>
        /// <param name="item">Member item to be added to db.</param>
        public void Add(Member item)
        {
            context.Members.Add(item);
            context.SaveChanges();
        }

        /// <summary>
        /// Retrieves all members.
        /// </summary>
        /// <returns>Returns an IEnumerable of all members.</returns>
        public IEnumerable<Member> All()
        {
            return context.Members;
        }

        /// <summary>
        /// Saves changes as a specific item in the db has changed.
        /// </summary>
        /// <param name="item">Supposedly the item that has been changed.</param>
        public void Edit(Member item)
        {
            context.SaveChanges();
        }

        /// <summary>
        /// Finds a member corresponding to the given parameter id.
        /// </summary>
        /// <param name="id">Id of a member.</param>
        /// <returns>Returns a member corresponding to parameter.</returns>
        public Member Find(int id)
        {
            return context.Members.Find(id);
        }

        /// <summary>
        /// Removes a member from the db.
        /// </summary>
        /// <param name="item">Member to be removed from db.</param>
        public void Remove(Member item)
        {
            context.Members.Remove(item);
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
