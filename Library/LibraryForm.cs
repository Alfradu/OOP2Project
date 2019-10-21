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
            ShowAllItems(bookService.All());
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
            ShowAllItems(bookService.All());
        }

        private void BookCopyService_Updated(object sender, UpdatedEventArgs e)
        {
            ShowAllCopies(bookCopyService.All(lbItems.SelectedItem as Book));
        }

        private void ShowAllItems<T>(IEnumerable<T> item)
        {
            lbItems.Items.Clear();
            foreach (T t in item)
            {
                lbItems.Items.Add(t);
            }
        }

        private void ShowAllCopies(IEnumerable<BookCopy> copies)
        {
            lbCopies.Items.Clear();
            foreach (BookCopy bc in copies)
            {
                lbCopies.Items.Add(bc);
            }
        }

        private void ShowAllInfo<T>(T item)
        {
            //TODO: do not do this
            switch (item.GetType().ToString()) {
                case "Book":
                    Book b = item as Book;
                    lbInfo.Items.Clear();
                    lbInfo.Items.Add(b.Title);
                    lbInfo.Items.Add("ISBN :" + b.ISBN);
                    lbInfo.Items.Add("Description: \n" + b.Description);
                    lbInfo.Items.Add("Author: " + b.Author);
                    break;
                case "Author":
                    Author a = item as Author;
                    lbInfo.Items.Clear();
                    lbInfo.Items.Add(a.Name);
                    lbInfo.Items.Add("Books :\n");
                    foreach (Book book in a.Books)
                    {
                        lbInfo.Items.Add(book);
                    }
                    break;
                case "Loan":
                    break;
                case "Member":
                    break;
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

        private void newBookBtn_Click(object sender, EventArgs e)
        {
            Book b = new Book()
            {
                Title = titleTextBox.Text,
                ISBN = isbnTextBox.Text,
                Description = descTextBox.Text,
                Author = authorNameCombo.SelectedItem as Author
            };
            bookService.Add(b);
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            //TODO: remember to properly clean up tables if something is removed!
            Book b = lbItems.SelectedItem as Book;
            if (b != null)
            {
                foreach (BookCopy bc in b.Copies)
                {
                    bookCopyService.Remove(bc);
                }
                b.Author.Books.Remove(b);
                authorService.Edit(b.Author);
                bookService.Remove(b);
            }
        }

        private void newBookCopyBtn_Click(object sender, EventArgs e)
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
                Book b = lbItems.SelectedItem as Book;
                ShowAllInfo(b);
                ShowAllCopies(bookCopyService.All(b));
                bookCopySelectedBook.Text = b.ToString();
            }
        }

        private void showAllAvailableOfBookBtn_Click(object sender, EventArgs e)
        {
            ShowAllCopies(bookCopyService.AllAvailable(lbItems.SelectedItem as Book));
        }

        private void sortByAuthorBtn_Click(object sender, EventArgs e)
        {
            ShowAllItems(bookService.GetAllThatHasAuthor(authorNameBox.Text));
        }

        private void sortByTitleBtn_Click(object sender, EventArgs e)
        {
            ShowAllItems(bookService.GetAllThatHasTitle(bookTitleBox.Text));
        }

        private void memberAddBtn_Click(object sender, EventArgs e)
        {
            memberService.Add(new Member { Name = memberAddName.Text, PersonalId = memberAddid.Text, MembershipDate = DateTime.Now });
        }

        private void authorAddBtn_Click(object sender, EventArgs e)
        {
            authorService.Add(new Author { Name = authorAddName.Text });
        }

        private void showAllBooksBtn_Click(object sender, EventArgs e)
        {
            ShowAllItems(bookService.All());
            ShowAllCopies(bookCopyService.All());
        }

        private void showAllAvailableBooksBtn_Click(object sender, EventArgs e)
        {
            ShowAllItems(bookService.GetAllAvailable());
            ShowAllCopies(bookCopyService.AllAvailable());
        }

        private void showAllMembersBtn_Click(object sender, EventArgs e)
        {
            ShowAllItems(memberService.All());
        }

        private void showAllAuthorsBtn_Click(object sender, EventArgs e)
        {
            ShowAllItems(authorService.All());
        }

        private void showAllLoansBtn_Click(object sender, EventArgs e)
        {
            ShowAllItems(loanService.All());
        }
    }
}
