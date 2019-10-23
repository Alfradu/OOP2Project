using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Loan
    {
        [Key]
        public int Id { get; set; }
        public DateTime TimeOfLoan { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? TimeOfReturn { get; set; }
        public BookCopy BookCopy { get; set; }
        public Member Member { get; set; }
        public int overtimeFine { get; set; }

        public override string ToString()
        {
            return String.Format("{0} -- {1} Loaned by {2}.",Id,BookCopy.Book.ISBN,Member);
        }
    }
}
