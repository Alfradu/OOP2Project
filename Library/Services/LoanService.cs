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

        public LoanService(RepositoryFactory rFactory)
        {
            this.loanRepository = rFactory.CreateLoanRepository();
        }

        public IEnumerable<Loan> All()
        {
            return loanRepository.All();
        }

        internal IEnumerable<object> GetAllOfMember(string name)
        {
            return loanRepository.All().Where(l => l.Member.Name == name);
        }

        internal IEnumerable<object> GetAllofBook(string title)
        {
            return loanRepository.All().Where(l => l.BookCopy.Book.Title == title);
        }

        internal Loan Find(BookCopy bc)
        {
            return loanRepository.All().Where(i => i.BookCopy == bc).FirstOrDefault();
        }

        public IEnumerable<Loan> getOvertimedLoans()
        {
            return loanRepository.All().Where(a => a.DueDate <= DateTime.Now && a.BookCopy.Status != Status.OVERDUE);
        }
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

        private void OnUpdateEvent(UpdatedEventArgs uea) => Updated?.Invoke(this, uea);
    }
}
