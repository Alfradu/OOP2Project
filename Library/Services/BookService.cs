using Library.Models;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    class BookService : IService
    {
        /// <summary>
        /// service doesn't need a context but it needs a repository.
        /// </summary>
        BookRepository bookRepository;
        public event EventHandler<UpdatedEventArgs> Updated;

        /// <param name="rFactory">A repository factory, so the service can create its own repository.</param>
        public BookService(RepositoryFactory rFactory)
        {
            this.bookRepository = rFactory.CreateBookRepository();
        }

        public IEnumerable<Book> All()
        {
            return bookRepository.All();
        }

        public IEnumerable<Book> GetAllThatContainsInTitle(string a)
        {
            return All().Where(b => b.Title.Contains(a));
        }

        public IEnumerable<Book> GetAllThatHasAuthor(string a)
        {
            return All().Where(b => b.Author.Name == a);
        }

        public IEnumerable<Book> GetAllThatHasTitle(string t)
        {
            return All().Where(b => b.Title == t);
        }

        public IEnumerable<Book> GetAllAvailable()
        {
            return All().Where(b => b.Copies.Any(c => c.Status == Status.AVAILABLE));
        }

        public IEnumerable<Book> GetAllWithoutCopies()
        {
            return All().Where(b => b.Copies.Count == 0);
        }

        public Book GetBook(string text)
        {
            return All().Where(b => b.Title == text).FirstOrDefault();
        }

        public IEnumerable<Book> sortIdAsc(List<Book> list)
        {
            return list.OrderBy(o => o.Id).ToList();
        }

        public IEnumerable<Book> sortIdDesc(List<Book> list)
        {
            return list.OrderByDescending(o => o.Id).ToList();
        }

        public IEnumerable<Book> sortTextAsc(List<Book> list)
        {
            return list.OrderBy(o => o.Title).ToList();
        }

        public IEnumerable<Book> sortTextDesc(List<Book> list)
        {
            return list.OrderByDescending(o => o.Title).ToList();
        }

        /// <summary>
        /// The Edit method makes sure that the given Book object is saved to the database and raises the Updated() event.
        /// </summary>
        /// <param name="b"></param>
        public void Edit(Book b)
        {
            bookRepository.Edit(b);
            OnUpdateEvent(new UpdatedEventArgs(Action.EDIT, DateTime.Now));
        }

        /// <summary>
        /// The Add method saves a new Book object to the db and raises the Updated() event.
        /// </summary>
        /// <param name="b"></param>
        public void Add(Book b)
        {
            bookRepository.Add(b);
            OnUpdateEvent(new UpdatedEventArgs(Action.ADD, DateTime.Now));
        }

        /// <summary>
        /// The Remove method removes a given book object in the db and raises the Updated() event.
        /// </summary>
        /// <param name="b"></param>
        public void Remove(Book b)
        {
            bookRepository.Remove(b);
            OnUpdateEvent(new UpdatedEventArgs(Action.REMOVE, DateTime.Now));
        }

        private void OnUpdateEvent(UpdatedEventArgs uea) => Updated?.Invoke(this, uea);
    }
}
