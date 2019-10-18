using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repositories
{
    public class LoanRepository : IRepository<Loan, int>
    {
        LibraryContext context;

        public LoanRepository(LibraryContext c)
        {
            this.context = c;
        }

        public void Add(Loan item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Loan> All()
        {
            throw new NotImplementedException();
        }

        public void Edit(Loan item)
        {
            throw new NotImplementedException();
        }

        public Loan Find(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Loan item)
        {
            throw new NotImplementedException();
        }
    }
}
