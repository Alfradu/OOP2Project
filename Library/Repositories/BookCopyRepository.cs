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
            context.BookCopies.Add(item);
            context.SaveChanges();
        }

        public IEnumerable<BookCopy> All()
        {
            return context.BookCopies;
        }

        public void Edit(BookCopy item)
        {
            context.SaveChanges();
        }

        public BookCopy Find(int id)
        {
            return context.BookCopies.Find(id);
        }

        public void Remove(BookCopy item)
        {
            context.BookCopies.Remove(item);
            context.SaveChanges();
        }
    }
}
