using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    /// <summary>
    /// Defines what state a loan is currently in.
    /// </summary>
    public enum State{Active, Archived}

    /// <summary>
    /// Defines the Loan table in the database.
    /// </summary>
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
        /// <summary>
        /// Stores the fine a member needs to pay in the loan data.
        /// </summary>
        public int OvertimeFine { get; set; }
        [Required]
        public State State { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}] {1} Loaned by {2}", Id, BookCopy.Book.ISBN, Member);
        }
    }
}
