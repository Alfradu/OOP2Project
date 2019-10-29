using Library.Models;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Services
{
    /// <summary>
    /// Service for handling loan-related queries.
    /// </summary>
    class LoanService : IService
    {
        LoanRepository loanRepository;

        /// <summary>
        /// Allows services to notify when their underlying data model changes.
        /// </summary>
        public event EventHandler<UpdatedEventArgs> Updated;

        /// <param name="rFactory">A repository factory, so the service can create its own repository.</param>
        public LoanService(RepositoryFactory rFactory) => loanRepository = rFactory.CreateLoanRepository();

        /// <returns>Returns all loans.</returns>
        public IEnumerable<Loan> All() => loanRepository.All();

        /// <param name="name">String to sort loans by.</param>
        /// <returns>Returns loans of a specified member.</returns>
        public IEnumerable<Loan> GetAllOfMember(string name) => All().Where(l => l.Member.Name == name);

        /// <param name="title">String to sort loan by.</param>
        /// <returns>Returns loans of a specified book.</returns>
        public IEnumerable<Loan> GetAllofBook(string title) => All().Where(l => l.BookCopy.Book.Title == title);

        /// <param name="bc">BookCopy to search loan by.</param>
        /// <returns>Returns a loan by given BookCopy.</returns>
        public Loan Find(BookCopy bc) => All().Where(i => i.BookCopy.Id == bc.Id && i.State != State.Archived).FirstOrDefault();

        /// <returns>Returns loans that are overtimed.</returns>
        public IEnumerable<Loan> GetOvertimedLoans() => All().Where(a => a.DueDate <= DateTime.Now && a.BookCopy.Status != Status.AVAILABLE);

        /// <returns>Returns loans that are active.</returns>
        public IEnumerable<Loan> GetAllActiveLoans() => All().Where(l => l.State == State.Active);

        /// <returns>Returns loans that are archived.</returns>
        public IEnumerable<Loan> GetAllArchivedLoans() => All().Where(l => l.State == State.Archived);

        /// <summary>
        /// Sorts given list by id ascending.
        /// </summary>
        /// <param name="list">List of items to be sorted.</param>
        /// <returns>Returns a sorted IEnumerable.</returns>
        public IEnumerable<Loan> SortIdAsc(List<Loan> list) => list.OrderBy(o => o.Id);

        /// <summary>
        /// Sorts given list by id descending.
        /// </summary>
        /// <param name="list">List of items to be sorted.</param>
        /// <returns>Returns a sorted IEnumerable.</returns>
        public IEnumerable<Loan> SortIdDesc(List<Loan> list) => list.OrderByDescending(o => o.Id);

        /// <summary>
        /// Sorts given list by text ascending.
        /// </summary>
        /// <param name="list">List of items to be sorted.</param>
        /// <returns>Returns a sorted IEnumerable.</returns>
        public IEnumerable<Loan> SortTextAsc(List<Loan> list) => list.OrderBy(o => o.Member.Name);

        /// <summary>
        /// Sorts given list by text descending.
        /// </summary>
        /// <param name="list">List of items to be sorted.</param>
        /// <returns>Returns a sorted IEnumerable.</returns>
        public IEnumerable<Loan> SortTextDesc(List<Loan> list) => list.OrderByDescending(o => o.Member.Name);

        /// <summary>
        /// The Edit method makes sure that the given Loan object is saved to the database and raises the Updated() event.
        /// </summary>
        /// <param name="b">Loan item to be edited (Saved).</param>
        public void Edit(Loan b)
        {
            loanRepository.Edit(b);
            OnUpdateEvent(new UpdatedEventArgs(Action.EDIT, DateTime.Now));
        }

        /// <summary>
        /// The Add method saves a new Loan object to the db and raises the Updated() event.
        /// </summary>
        /// <param name="b">Loan item to be added.</param>
        public void Add(Loan b)
        {
            loanRepository.Add(b);
            OnUpdateEvent(new UpdatedEventArgs(Action.ADD, DateTime.Now));
        }

        /// <summary>
        /// The Remove method removes a given book object in the db and raises the Updated() event.
        /// </summary>
        /// <param name="b">Loan item to be removed.</param>
        public void Remove(Loan b)
        {
            loanRepository.Remove(b);
            OnUpdateEvent(new UpdatedEventArgs(Action.REMOVE, DateTime.Now));
        }

        /// <summary>
        /// Rollback db to ignore uncommitted changes.
        /// </summary>
        public void Reset()
        {
            loanRepository.Reset();
        }

        /// <summary>
        /// Invoke Updated event to listeners with arguments.
        /// </summary>
        /// <param name="uea">UpdatedEventArgs describing db action and time.</param>
        private void OnUpdateEvent(UpdatedEventArgs uea) => Updated?.Invoke(this, uea);
    }
}
