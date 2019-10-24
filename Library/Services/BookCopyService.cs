using Library.Models;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    class BookCopyService : IService
    {
        BookCopyRepository bookCopyRepository;
        public event EventHandler<UpdatedEventArgs> Updated;

        public BookCopyService(RepositoryFactory rFactory)
        {
            this.bookCopyRepository = rFactory.CreateBookCopyRepository();
        }
        
        public IEnumerable<BookCopy> All()
        {
            return bookCopyRepository.All();
        }

        public IEnumerable<BookCopy> All(Book b)
        {
            return bookCopyRepository.All().Where(c => c.Book == b);
        }

        public IEnumerable<BookCopy> AllAvailable()
        {
            return All().Where(bc => bc.Status == Status.AVAILABLE);
        }

        public IEnumerable<BookCopy> AllAvailable(Book b)
        {
            return AllAvailable().Where(bc => bc.Book == b);
        }

        /// <summary>
        /// The Edit method makes sure that the given Book object is saved to the database and raises the Updated() event.
        /// </summary>
        /// <param name="b"></param>
        public void Edit(BookCopy bc)
        {
            bookCopyRepository.Edit(bc);
            OnUpdateEvent(new UpdatedEventArgs(Action.EDIT, DateTime.Now));
        }

        /// <summary>
        /// The Add method saves a new Book object to the db and raises the Updated() event.
        /// </summary>
        /// <param name="b"></param>
        public void Add(BookCopy bc)
        {
            bookCopyRepository.Add(bc);
            OnUpdateEvent(new UpdatedEventArgs(Action.ADD, DateTime.Now));
        }

        /// <summary>
        /// The Remove method removes a given book object in the db and raises the Updated() event.
        /// </summary>
        /// <param name="b"></param>
        public void Remove(BookCopy bc)
        {
            bookCopyRepository.Remove(bc);
            OnUpdateEvent(new UpdatedEventArgs(Action.REMOVE, DateTime.Now));
        }

        public void RemoveAllOfBook(Book b)
        {
            b.Copies.ForEach(c => bookCopyRepository.Remove(c));
        }
        private void OnUpdateEvent(UpdatedEventArgs uea) => Updated?.Invoke(this, uea);
    }
}
