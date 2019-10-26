using Library.Models;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    class AuthorService : IService
    {
        AuthorRepository authorRepository;
        public event EventHandler<UpdatedEventArgs> Updated;

        public AuthorService(RepositoryFactory rFactory) => authorRepository = rFactory.CreateAuthorRepository();

        public IEnumerable<Author> All() => authorRepository.All();

        public IEnumerable<Author> GetAllWithoutBooks() => All().Where(a => a.Books.Count == 0);

        public IEnumerable<Author> GetAuthorByBook(Book book) => All().Where(a => a.Books.Contains(book));

        public IEnumerable<Author> SortIdAsc(List<Author> list) => list.OrderBy(o => o.Id).ToList();

        public IEnumerable<Author> SortIdDesc(List<Author> list) => list.OrderByDescending(o => o.Id).ToList();

        public IEnumerable<Author> SortTextAsc(List<Author> list) => list.OrderBy(o => o.Name).ToList();

        public IEnumerable<Author> SortTextDesc(List<Author> list) => list.OrderByDescending(o => o.Name).ToList();

        /// <summary>
        /// The Edit method makes sure that the given Author object is saved to the database and raises the Updated() event.
        /// </summary>
        /// <param name="b"></param>
        public void Edit(Author b)
        {
            authorRepository.Edit(b);
            OnUpdateEvent(new UpdatedEventArgs(Action.EDIT, DateTime.Now));
        }

        /// <summary>
        /// The Add method saves a new Author object to the db and raises the Updated() event.
        /// </summary>
        /// <param name="b"></param>
        public void Add(Author b)
        {
            authorRepository.Add(b);
            OnUpdateEvent(new UpdatedEventArgs(Action.ADD, DateTime.Now));
        }

        /// <summary>
        /// The Remove method removes a given book object in the db and raises the Updated() event.
        /// </summary>
        /// <param name="b"></param>
        public void Remove(Author b)
        {
            authorRepository.Remove(b);
            OnUpdateEvent(new UpdatedEventArgs(Action.REMOVE, DateTime.Now));
        }

        public void Reset()
        {
            authorRepository.Reset();
        }

        private void OnUpdateEvent(UpdatedEventArgs uea) => Updated?.Invoke(this, uea);
    }
}
