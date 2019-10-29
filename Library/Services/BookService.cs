using Library.Models;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Services
{
    /// <summary>
    /// Service for handling book-related queries.
    /// </summary>
    class BookService : IService
    {
        BookRepository bookRepository;

        /// <summary>
        /// Allows services to notify when their underlying data model changes.
        /// </summary>
        public event EventHandler<UpdatedEventArgs> Updated;

        /// <param name="rFactory">A repository factory, so the service can create its own repository.</param>
        public BookService(RepositoryFactory rFactory) => bookRepository = rFactory.CreateBookRepository();

        /// <returns>Returns all books.</returns>
        public IEnumerable<Book> All() => bookRepository.All();

        /// <param name="a">String to sort list by.</param>
        /// <returns>Return all books that has part of the given string in it's title.</returns>
        public IEnumerable<Book> GetAllThatContainsInTitle(string a) => All().Where(b => b.Title.Contains(a));
        
        /// <param name="a">String to sort list by.</param>
        /// <returns>Returns all books that has an author mathing the given name.</returns>
        public IEnumerable<Book> GetAllThatHasAuthor(string a) => All().Where(b => b.Author.Name == a);

        /// <param name="t">String to sort list by.</param>
        /// <returns>Returns books that has the given string as title.</returns>
        public IEnumerable<Book> GetAllThatHasTitle(string t) => All().Where(b => b.Title == t);

        /// <returns>Returns books that are available.</returns>
        public IEnumerable<Book> GetAllAvailable() => All().Where(b => b.Copies.Any(c => c.Status == Status.AVAILABLE));

        /// <returns>Returns books that has no copies.</returns>
        public IEnumerable<Book> GetAllWithoutCopies() => All().Where(b => b.Copies.Count == 0);

        /// <summary>
        /// Tries to get a book from a given string.
        /// </summary>
        /// <param name="text">String to find book by.</param>
        /// <returns>Returns a book or null.</returns>
        public Book GetBook(string text) => All().Where(b => b.Title == text).FirstOrDefault();

        /// <summary>
        /// Sorts given list by id ascending.
        /// </summary>
        /// <param name="list">List of items to be sorted.</param>
        /// <returns>Returns a sorted IEnumerable.</returns>
        public IEnumerable<Book> SortIdAsc(List<Book> list) => list.OrderBy(o => o.Id);

        /// <summary>
        /// Sorts given list by id descending.
        /// </summary>
        /// <param name="list">List of items to be sorted.</param>
        /// <returns>Returns a sorted IEnumerable.</returns>
        public IEnumerable<Book> SortIdDesc(List<Book> list) => list.OrderByDescending(o => o.Id);

        /// <summary>
        /// Sorts given list by text ascending.
        /// </summary>
        /// <param name="list">List of items to be sorted.</param>
        /// <returns>Returns a sorted IEnumerable.</returns>
        public IEnumerable<Book> SortTextAsc(List<Book> list) => list.OrderBy(o => o.Title);

        /// <summary>
        /// Sorts given list by text descending.
        /// </summary>
        /// <param name="list">List of items to be sorted.</param>
        /// <returns>Returns a sorted IEnumerable.</returns>
        public IEnumerable<Book> SortTextDesc(List<Book> list) => list.OrderByDescending(o => o.Title);

        /// <summary>
        /// The Edit method makes sure that the given Book object is saved to the database and raises the Updated() event.
        /// </summary>
        /// <param name="b">Book item to be edited (saved).</param>
        public void Edit(Book b)
        {
            bookRepository.Edit(b);
            OnUpdateEvent(new UpdatedEventArgs(Action.EDIT, DateTime.Now));
        }

        /// <summary>
        /// The Add method saves a new Book object to the db and raises the Updated() event.
        /// </summary>
        /// <param name="b">Book item to be added.</param>
        public void Add(Book b)
        {
            bookRepository.Add(b);
            OnUpdateEvent(new UpdatedEventArgs(Action.ADD, DateTime.Now));
        }

        /// <summary>
        /// The Remove method removes a given book object in the db and raises the Updated() event.
        /// </summary>
        /// <param name="b">Book item to be removed.</param>
        public void Remove(Book b)
        {
            bookRepository.Remove(b);
            OnUpdateEvent(new UpdatedEventArgs(Action.REMOVE, DateTime.Now));
        }

        /// <summary>
        /// Rollback db to ignore uncommitted changes.
        /// </summary>
        public void Reset()
        {
            bookRepository.Reset();
        }

        /// <summary>
        /// Invoke Updated event to listeners with arguments.
        /// </summary>
        /// <param name="uea">UpdatedEventArgs describing db action and time.</param>
        private void OnUpdateEvent(UpdatedEventArgs uea) => Updated?.Invoke(this, uea);
    }
}
