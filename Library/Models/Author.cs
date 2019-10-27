using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    /// <summary>
    /// Defines the Author table in the database.
    /// </summary>
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Book> Books { get; set; }

        public Author()
        {
            Books = new List<Book>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}