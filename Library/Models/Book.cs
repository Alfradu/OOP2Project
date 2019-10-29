using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    /// <summary>
    /// Defines the Book table in the database.
    /// </summary>
    public class Book {

        [Key]
        public int Id { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Author Author { get; set; }
        public List<BookCopy> Copies { get; set; }

        public Book()
        {
            Copies = new List<BookCopy>();
        }

        public override string ToString() {
            return String.Format("[{0}] -- {1}", Id, Title);
        }
    }
}