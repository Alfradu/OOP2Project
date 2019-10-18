using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;

namespace Library.Repositories
{
    public class BookCopyRepository : IRepository<BookCopy, int>
    {
        LibraryContext context;

        public BookCopyRepository(LibraryContext c)
        {
            this.context = c;
        }

        public void Add(BookCopy item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookCopy> All()
        {
            throw new NotImplementedException();
        }

        public void Edit(BookCopy item)
        {
            throw new NotImplementedException();
        }

        public BookCopy Find(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(BookCopy item)
        {
            throw new NotImplementedException();
        }
    }
}
