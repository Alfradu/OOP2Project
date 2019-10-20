using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repositories
{
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
    }
}
