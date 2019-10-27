using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repositories
{
    /// <summary>
    /// Repository for handling Member-related database actions.
    /// </summary>
    public class MemberRepository : IRepository<Member, int>
    {
        LibraryContext context;

        public MemberRepository(LibraryContext c)
        {
            this.context = c;
        }

        public void Add(Member item)
        {
            context.Members.Add(item);
            context.SaveChanges();
        }

        public IEnumerable<Member> All()
        {
            return context.Members;
        }

        public void Edit(Member item)
        {
            context.SaveChanges();
        }

        public Member Find(int id)
        {
            return context.Members.Find(id);
        }

        public void Remove(Member item)
        {
            context.Members.Remove(item);
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
