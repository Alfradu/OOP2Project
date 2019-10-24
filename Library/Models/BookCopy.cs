using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{

    public enum Status { AVAILABLE, LOANED, OVERDUE}
    public class BookCopy
    {
        [Key]
        public int Id { get; set; }
        public Book Book { get; set; }
        public Status Status { get; set; }
        public int Condition { get; set; }

        public override string ToString()
        {
            return String.Format("[{0}] {1}, Condition: {2}, Status: {3}", this.Id, this.Book.Title, this.Condition, this.Status);
        }
    }
}