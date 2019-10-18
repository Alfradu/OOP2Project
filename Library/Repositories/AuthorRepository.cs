using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repositories
{
    public class AuthorRepository : IRepository<Author, int>
    {
        LibraryContext context;

        public AuthorRepository(LibraryContext c)
        {
            this.context = c;
        }

        public void Add(Author item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Author> All()
        {
            throw new NotImplementedException();
        }

        public void Edit(Author item)
        {
            throw new NotImplementedException();
        }

        public Author Find(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Author item)
        {
            throw new NotImplementedException();
        }
    }
}
