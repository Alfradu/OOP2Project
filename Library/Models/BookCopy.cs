using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    /// <summary>
    /// Defines the different statuses a bookCopy can have.
    /// </summary>
    public enum Status { AVAILABLE, LOANED, OVERDUE}

    /// <summary>
    /// Defines the BookCopy table in the database.
    /// </summary>
    public class BookCopy
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Book Book { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public int Condition { get; set; }

        public override string ToString()
        {
            return String.Format("[{0}] {1}, Condition: {2}, Status: {3}", Id, Book.Title, Condition, Status);
        }
    }
}