using Library.Models;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    class LoanService : IService
    {
        LoanRepository loanRepository;
        public event EventHandler<UpdatedEventArgs> Updated;

        public LoanService(RepositoryFactory rFactory) => loanRepository = rFactory.CreateLoanRepository();

        public IEnumerable<Loan> All() => loanRepository.All();

        public IEnumerable<object> GetAllOfMember(string name) => loanRepository.All().Where(l => l.Member.Name == name);

        public IEnumerable<object> GetAllofBook(string title) => loanRepository.All().Where(l => l.BookCopy.Book.Title == title);

        public Loan Find(BookCopy bc) => loanRepository.All().Where(i => i.BookCopy.Id == bc.Id && i.State != State.Archived).FirstOrDefault();

        public IEnumerable<Loan> GetOvertimedLoans() => loanRepository.All().Where(a => a.DueDate <= DateTime.Now && a.BookCopy.Status != Status.AVAILABLE);

        public IEnumerable<Loan> GetAllActiveLoans() => All().Where(l => l.State == State.Active);

        public IEnumerable<Loan> GetAllArchivedLoans() => All().Where(l => l.State == State.Archived);

        public IEnumerable<Loan> SortIdAsc(List<Loan> list) => list.OrderBy(o => o.Id).ToList();

        public IEnumerable<Loan> SortIdDesc(List<Loan> list) => list.OrderByDescending(o => o.Id).ToList();

        public IEnumerable<Loan> SortTextAsc(List<Loan> list) => list.OrderBy(o => o.Member.Name).ToList();

        public IEnumerable<Loan> SortTextDesc(List<Loan> list) => list.OrderByDescending(o => o.Member.Name).ToList();

        /// <summary>
        /// The Edit method makes sure that the given Loan object is saved to the database and raises the Updated() event.
        /// </summary>
        /// <param name="b"></param>
        public void Edit(Loan b)
        {
            loanRepository.Edit(b);
            OnUpdateEvent(new UpdatedEventArgs(Action.EDIT, DateTime.Now));
        }

        /// <summary>
        /// The Add method saves a new Loan object to the db and raises the Updated() event.
        /// </summary>
        /// <param name="b"></param>
        public void Add(Loan b)
        {
            loanRepository.Add(b);
            OnUpdateEvent(new UpdatedEventArgs(Action.ADD, DateTime.Now));
        }

        /// <summary>
        /// The Remove method removes a given book object in the db and raises the Updated() event.
        /// </summary>
        /// <param name="b"></param>
        public void Remove(Loan b)
        {
            loanRepository.Remove(b);
            OnUpdateEvent(new UpdatedEventArgs(Action.REMOVE, DateTime.Now));
        }

        public void Reset()
        {
            loanRepository.Reset();
        }

        private void OnUpdateEvent(UpdatedEventArgs uea) => Updated?.Invoke(this, uea);
    }
}
