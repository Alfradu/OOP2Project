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

        public AuthorService(RepositoryFactory rFactory)
        {
            this.authorRepository = rFactory.CreateAuthorRepository();
        }

        public IEnumerable<Author> All()
        {
            return authorRepository.All();
        }

        internal List<Author> sortIdAsc(List<Author> list)
        {
            return list.OrderBy(o => o.Id).ToList();
        }

        internal List<Author> sortIdDesc(List<Author> list)
        {
            return list.OrderByDescending(o => o.Id).ToList();
        }

        internal List<Author> sortTextAsc(List<Author> list)
        {
            return list.OrderBy(o => o.Name).ToList();
        }

        internal List<Author> sortTextDesc(List<Author> list)
        {
            return list.OrderByDescending(o => o.Name).ToList();
        }

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

        private void OnUpdateEvent(UpdatedEventArgs uea) => Updated?.Invoke(this, uea);
    }
}
