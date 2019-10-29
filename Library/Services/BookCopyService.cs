using Library.Models;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Services
{
    /// <summary>
    /// Service for handling bookCopy-related queries.
    /// </summary>
    class BookCopyService : IService
    {
        BookCopyRepository bookCopyRepository;

        /// <summary>
        /// Allows services to notify when their underlying data model changes.
        /// </summary>
        public event EventHandler<UpdatedEventArgs> Updated;

        /// <param name="rFactory">A repository factory, so the service can create its own repository.</param>
        public BookCopyService(RepositoryFactory rFactory) => bookCopyRepository = rFactory.CreateBookCopyRepository();

        /// <returns>Returns all bookCopies.</returns>
        public IEnumerable<BookCopy> All() => bookCopyRepository.All();

        /// <param name="b">Book item to sort by.</param>
        /// <returns>Returns all bookCopies of a given book.</returns>
        public IEnumerable<BookCopy> All(Book b) => All().Where(c => c.Book == b);

        /// <returns>Returns all bookCopies that are available.</returns>
        public IEnumerable<BookCopy> AllAvailable() => All().Where(bc => bc.Status == Status.AVAILABLE);

        /// <param name="b">Book item tosort by.</param>
        /// <returns>Returns all bookCopies that are available of a given book.</returns>
        public IEnumerable<BookCopy> AllAvailable(Book b) => AllAvailable().Where(bc => bc.Book == b);

        /// <summary>
        /// Sorts given list by id ascending.
        /// </summary>
        /// <param name="list">List of items to be sorted.</param>
        /// <returns>Returns a sorted IEnumerable.</returns>
        public IEnumerable<BookCopy> SortIdAsc(List<BookCopy> list) => list.OrderBy(o => o.Id);

        /// <summary>
        /// Sorts given list by id descending.
        /// </summary>
        /// <param name="list">List of items to be sorted.</param>
        /// <returns>Returns a sorted IEnumerable.</returns>
        public IEnumerable<BookCopy> SortIdDesc(List<BookCopy> list) => list.OrderByDescending(o => o.Id);

        /// <summary>
        /// Sorts given list by text ascending.
        /// </summary>
        /// <param name="list">List of items to be sorted.</param>
        /// <returns>Returns a sorted IEnumerable.</returns>
        public IEnumerable<BookCopy> SortTextAsc(List<BookCopy> list) => list.OrderBy(o => o.Book.Title);

        /// <summary>
        /// Sorts given list by text descending.
        /// </summary>
        /// <param name="list">List of items to be sorted.</param>
        /// <returns>Returns a sorted IEnumerable.</returns>
        public IEnumerable<BookCopy> SortTextDesc(List<BookCopy> list) => list.OrderByDescending(o => o.Book.Title);

        /// <summary>
        /// The Edit method makes sure that the given Book object is saved to the database and raises the Updated() event.
        /// </summary>
        /// <param name="b">BookCopy item to be edited (Saved).</param>
        public void Edit(BookCopy bc)
        {
            bookCopyRepository.Edit(bc);
            OnUpdateEvent(new UpdatedEventArgs(Action.EDIT, DateTime.Now));
        }

        /// <summary>
        /// The Add method saves a new Book object to the db and raises the Updated() event.
        /// </summary>
        /// <param name="b">BookCopy item to be added.</param>
        public void Add(BookCopy bc)
        {
            bookCopyRepository.Add(bc);
            OnUpdateEvent(new UpdatedEventArgs(Action.ADD, DateTime.Now));
        }

        /// <summary>
        /// The Remove method removes a given book object in the db and raises the Updated() event.
        /// </summary>
        /// <param name="b">BookCopy item to be removed.</param>
        public void Remove(BookCopy bc)
        {
            bookCopyRepository.Remove(bc);
            OnUpdateEvent(new UpdatedEventArgs(Action.REMOVE, DateTime.Now));
        }

        /// <summary>
        /// Rollback db to ignore uncommitted changes.
        /// </summary>
        public void Reset()
        {
            bookCopyRepository.Reset();
        }

        /// <summary>
        /// Invoke Updated event to listeners with arguments.
        /// </summary>
        /// <param name="uea">UpdatedEventArgs describing db action and time.</param>
        private void OnUpdateEvent(UpdatedEventArgs uea) => Updated?.Invoke(this, uea);
    }
}
