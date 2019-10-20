using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Models {
    public class Book {

        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Author Author { get; set; }
        public List<BookCopy> Copies { get; set; }

        public Book()
        {
            ISBN = "";
            Title = "";
            Description = "";
            Author = new Author {Name = "Örjan" };
            Copies = new List<BookCopy>();
        }

        /// <summary>
        /// Useful for adding the book objects directly to a ListBox.
        /// </summary>
        public override string ToString() {
            return String.Format("[{0}] -- {1}", this.Id, this.Title);
        }
    }
}