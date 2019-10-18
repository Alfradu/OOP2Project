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
            throw new NotImplementedException();
        }

        public IEnumerable<Member> All()
        {
            throw new NotImplementedException();
        }

        public void Edit(Member item)
        {
            throw new NotImplementedException();
        }

        public Member Find(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Member item)
        {
            throw new NotImplementedException();
        }
    }
}
