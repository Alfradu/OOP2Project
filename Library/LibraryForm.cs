using Library.Models;
using Library.Repositories;
using Library.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class LibraryForm : Form
    {
        BookService bookService;
        AuthorService authorService;
        BookCopyService bookCopyService;
        LoanService loanService;
        MemberService memberService;

        public LibraryForm()
        {
            InitializeComponent();
            // we create only one context in our application, which gets shared among repositories
            LibraryContext context = new LibraryContext();
            // we use a factory object that will create the repositories as they are needed, it also makes
            // sure all the repositories created use the same context.
            RepositoryFactory repFactory = new RepositoryFactory(context);

            this.bookService = new BookService(repFactory);
            this.authorService = new AuthorService(repFactory);
            this.bookCopyService = new BookCopyService(repFactory);
            this.loanService = new LoanService(repFactory);
            this.memberService = new MemberService(repFactory);
            bookService.Updated += BookService_Updated;
            bookCopyService.Updated += BookCopyService_Updated;
            authorService.Updated += AuthorService_Updated;
            populateAuthorComboBox();
            ShowAllBooks(bookService.All());
        }

        private void AuthorService_Updated(object sender, UpdatedEventArgs e)
        {
            populateAuthorComboBox();
        }

        private void populateAuthorComboBox()
        {
            authorNameCombo.Items.Clear();
            foreach (Author a in authorService.All())
            {
                authorNameCombo.Items.Add(a);
            }
        }

        private void BookService_Updated(object sender, UpdatedEventArgs e)
        {
            Console.WriteLine("Sender " + sender.GetType() + " performed action " +e.Action+" on db at " + e.UpdateTime);
            ShowAllBooks(bookService.All());
        }

        private void BookCopyService_Updated(object sender, UpdatedEventArgs e)
        {
            ShowAllCopies(lbItems.SelectedItem as Book);
        }

        private void ShowAllBooks(IEnumerable<Book> books)
        {
            lbItems.Items.Clear();
            foreach (Book book in books)
            {
                lbItems.Items.Add(book);
            }
        }

        private void ShowAllInfo(Book book)
        {
            lbInfo.Items.Clear();
            lbInfo.Items.Add(book.Title);
            lbInfo.Items.Add("ISBN :"+book.ISBN);
            lbInfo.Items.Add("Description: \n"+book.Description);
            lbInfo.Items.Add("Author: " + book.Author);
        }
        private void ShowAllCopies()
        {
            lbCopies.Items.Clear();
            foreach (BookCopy bc in bookCopyService.All())
            {
                lbCopies.Items.Add(bc);
            }
        }
        private void ShowAllCopies(Book book)
        {
            lbCopies.Items.Clear();
            var c = bookCopyService;
            foreach (BookCopy bc in book.Copies)
            {
                lbCopies.Items.Add(bc);
            }
        }

        private void BTNChangeBook_Click(object sender, EventArgs e)
        {
            Book b = lbItems.SelectedItem as Book;
            if (b != null)
            {
                b.Title = "Yoyoma koko";
                bookService.Edit(b);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Book b = new Book()
            {
                Title = title.Text,
                ISBN = isbn.Text,
                Description = desc.Text,
                Author = authorNameCombo.SelectedItem as Author
            };
            bookService.Add(b);
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            Book b = lbItems.SelectedItem as Book;
            if (b != null)
            {
                bookService.Remove(b);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Book b = lbItems.SelectedItem as Book;
            if (b != null)
            {
                BookCopy bc = new BookCopy
                {
                    Book = b,
                    Condition = new Random().Next(1, 10),
                    Status = Status.AVAILABLE
                };
                b.Copies.Add(bc);
                bookCopyService.Add(bc);
            }
        }

        private void lbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbItems.SelectedItems != null)
            {
                ShowAllInfo(lbItems.SelectedItem as Book);
                ShowAllCopies(lbItems.SelectedItem as Book);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowAllCopies();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowAllBooks(bookService.GetAllThatHasAuthor(authorNameBox.Text));
        }

        private void memberAddBtn_Click(object sender, EventArgs e)
        {
            memberService.Add(new Member { Name = memberAddName.Text, PersonalId = memberAddid.Text, MembershipDate = DateTime.Now });
        }

        private void authorAddBtn_Click(object sender, EventArgs e)
        {
            authorService.Add(new Author { Name = authorAddName.Text });
        }
    }
}
