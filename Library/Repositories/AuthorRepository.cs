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
    }
}
