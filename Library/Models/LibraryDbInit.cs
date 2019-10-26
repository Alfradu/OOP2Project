using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models {
    /// <summary>
    /// Database strategy is chosen as the base class to LibraryDbInit.
    /// Here in the Seed method you can create the default objects you want in the database.
    /// </summary>
    class LibraryDbInit : DropCreateDatabaseAlways<LibraryContext>
    {
        //TODO: swap to DropCreateDatabaseIfModelChanges DropCreateDatabaseAlways
        protected override void Seed(LibraryContext context) {
            base.Seed(context);
            Author a = new Author { Name = "Örjan" };
            Book monteCristo = new Book() {
                Title = "The Count of Monte Cristo",
                ISBN = "1323343",
                Description = "this is a book about the count of monte cristo.",
                Author = a
            };
            Member memb = new Member()
            {
                Name = "Markus",
                PersonalId = "13092345",
                MembershipDate = DateTime.Now
            };

            // Add the book to the DbSet of books.
            context.Authors.Add(a);
            context.Books.Add(monteCristo);
            context.Members.Add(memb);
            // Persist changes to the database
            context.SaveChanges();
        }
    }
}
