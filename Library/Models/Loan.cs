using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public enum State{Active, Archived}
    public class Loan
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime TimeOfLoan { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        public DateTime? TimeOfReturn { get; set; }
        [Required]
        public BookCopy BookCopy { get; set; }
        [Required]
        public Member Member { get; set; }
        public int OvertimeFine { get; set; }
        [Required]
        public State State { get; set; }

        public override string ToString()
        {
            return String.Format("[{0}] {1} Loaned by {2}", this.Id, BookCopy.Book.ISBN, this.Member);
        }
    }
}
