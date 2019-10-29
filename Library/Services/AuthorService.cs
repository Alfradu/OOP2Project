using Library.Models;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Services
{
    /// <summary>
    /// Service for handling author-related queries.
    /// </summary>
    class AuthorService : IService
    {
        AuthorRepository authorRepository;

        /// <summary>
        /// Allows services to notify when their underlying data model changes.
        /// </summary>
        public event EventHandler<UpdatedEventArgs> Updated;

        /// <param name="rFactory">A repository factory, so the service can create its own repository.</param>
        public AuthorService(RepositoryFactory rFactory) => authorRepository = rFactory.CreateAuthorRepository();

        /// <returns>Returns all authors.</returns>
        public IEnumerable<Author> All() => authorRepository.All();

        /// <returns>Returns all authors without books.</returns>
        public IEnumerable<Author> GetAllWithoutBooks() => All().Where(a => a.Books.Count == 0);

        /// <summary>
        /// Returns an author selected by a given book.
        /// </summary>
        /// <param name="book">Book item to sort author by.</param>
        /// <returns>Returns an author.</returns>
        public IEnumerable<Author> GetAuthorByBook(Book book) => All().Where(a => a.Books.Any(b => b.Title == book.Title));

        /// <summary>
        /// Sorts given list by id ascending.
        /// </summary>
        /// <param name="list">List of items to be sorted.</param>
        /// <returns>Returns a sorted IEnumerable.</returns>
        public IEnumerable<Author> SortIdAsc(List<Author> list) => list.OrderBy(o => o.Id);

        /// <summary>
        /// Sorts given list by id descendng.
        /// </summary>
        /// <param name="list">List of items to be sorted.</param>
        /// <returns>Returns a sorted IEnumerable.</returns>
        public IEnumerable<Author> SortIdDesc(List<Author> list) => list.OrderByDescending(o => o.Id);

        /// <summary>
        /// Sorts given list by text ascending.
        /// </summary>
        /// <param name="list">List of items to be sorted.</param>
        /// <returns>Returns a sorted IEnumerable.</returns>
        public IEnumerable<Author> SortTextAsc(List<Author> list) => list.OrderBy(o => o.Name);

        /// <summary>
        /// Sorts given list by text descending.
        /// </summary>
        /// <param name="list">List of items to be sorted.</param>
        /// <returns>Returns a sorted IEnumerable.</returns>
        public IEnumerable<Author> SortTextDesc(List<Author> list) => list.OrderByDescending(o => o.Name);

        /// <summary>
        /// The Edit method makes sure that the given Author object is saved to the database and raises the Updated() event.
        /// </summary>
        /// <param name="b">Author item to be edited (Saved).</param>
        public void Edit(Author b)
        {
            authorRepository.Edit(b);
            OnUpdateEvent(new UpdatedEventArgs(Action.EDIT, DateTime.Now));
        }

        /// <summary>
        /// The Add method saves a new Author object to the db and raises the Updated() event.
        /// </summary>
        /// <param name="b">Author item to be added.</param>
        public void Add(Author b)
        {
            authorRepository.Add(b);
            OnUpdateEvent(new UpdatedEventArgs(Action.ADD, DateTime.Now));
        }

        /// <summary>
        /// The Remove method removes a given book object in the db and raises the Updated() event.
        /// </summary>
        /// <param name="b">Author item to be removed.</param>
        public void Remove(Author b)
        {
            authorRepository.Remove(b);
            OnUpdateEvent(new UpdatedEventArgs(Action.REMOVE, DateTime.Now));
        }

        /// <summary>
        /// Rollback db to ignore uncommitted changes.
        /// </summary>
        public void Reset()
        {
            authorRepository.Reset();
        }

        /// <summary>
        /// Invoke Updated event to listeners with arguments.
        /// </summary>
        /// <param name="uea">UpdatedEventArgs describing db action and time.</param>
        private void OnUpdateEvent(UpdatedEventArgs uea) => Updated?.Invoke(this, uea);
    }
}
