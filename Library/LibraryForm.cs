﻿using Library.Models;
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
    public enum ListType { Book, Author, Loan, Member }
    public partial class LibraryForm : Form
    {
        BookService bookService;
        AuthorService authorService;
        BookCopyService bookCopyService;
        LoanService loanService;
        MemberService memberService;
        public ListType listType = new ListType();
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
            memberService.Updated += MemberService_Updated;
            loanService.Updated += LoanService_Updated;
            populateAuthorComboBox();
            populateMemberComboBox();
            ShowAllItems(bookService.All());
            listType = ListType.Book;
        }

        private void LoanService_Updated(object sender, UpdatedEventArgs e)
        {
           if(listType == ListType.Loan)
            {
                ShowAllItems(loanService.All());
            }
        }

        private void MemberService_Updated(object sender, UpdatedEventArgs e)
        {
            populateMemberComboBox();
            if (listType == ListType.Member)
            {
                ShowAllItems(memberService.All());
            }
        }

        private void AuthorService_Updated(object sender, UpdatedEventArgs e)
        {
            populateAuthorComboBox();
            if (listType == ListType.Author)
            {
                ShowAllItems(authorService.All());
            }
        }

        private void BookService_Updated(object sender, UpdatedEventArgs e)
        {
            //TODO: remove writeline and display time/action in another way
            Console.WriteLine("Sender " + sender.GetType() + " performed action " + e.Action + " on db at " + e.UpdateTime);
            if (listType == ListType.Book)
            {
                ShowAllItems(bookService.All());
            }
        }

        private void BookCopyService_Updated(object sender, UpdatedEventArgs e)
        {
            ShowAllCopies(bookCopyService.All(lbItems.SelectedItem as Book));
        }

        private void populateAuthorComboBox()
        {
            authorNameCombo.Items.Clear();
            foreach (Author a in authorService.All())
            {
                authorNameCombo.Items.Add(a);
            }
        }

        private void populateMemberComboBox()
        {
            availableMemberComboBox.Items.Clear();
            foreach (Member m in memberService.All())
            {
                availableMemberComboBox.Items.Add(m);
            }
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
            lbInfo.Items.Clear();
            switch (listType)
            {
                case ListType.Book:
                    Book b = item as Book;
                    lbInfo.Items.Add(b.Title);
                    lbInfo.Items.Add("ISBN :" + b.ISBN);
                    lbInfo.Items.Add("Description: \n" + b.Description);
                    lbInfo.Items.Add("Author: " + b.Author);
                    break;
                case ListType.Author:
                    Author a = item as Author;
                    lbInfo.Items.Add(a.Name);
                    lbInfo.Items.Add("Books :\n");
                    foreach (Book book in a.Books)
                    {
                        lbInfo.Items.Add(book);
                    }
                    break;
                case ListType.Loan:
                    Loan l = item as Loan;
                    lbInfo.Items.Add("Member: " + l.Member.Name);
                    lbInfo.Items.Add("Loaned on: " + l.TimeOfLoan);
                    lbInfo.Items.Add("Due date: " + l.DueDate);
                    if (l.BookCopy.Status == Status.LOANED && l.DueDate >= DateTime.Now)
                    {
                        lbInfo.Items.Add("Status: Loaned");
                    }
                    else if (l.BookCopy.Status == Status.LOANED && l.DueDate <= DateTime.Now)
                    {
                        lbInfo.Items.Add("Status: OVERDUE");
                        lbInfo.Items.Add("PLEASE RETURN, WILL CHARGE YOU 50kr THO MAN COME ON.");
                    }
                    else
                    {
                        lbInfo.Items.Add("Status: Returned on " + l.TimeOfReturn);
                    }
                    break;
                case ListType.Member:
                    Member m = item as Member;
                    lbInfo.Items.Add("Name: " + m.Name);
                    lbInfo.Items.Add("ID: " + m.PersonalId);
                    lbInfo.Items.Add("Member since: " + m.MembershipDate);
                    break;
            }
        }

        private void lbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbItems.SelectedItem != null)
            {
                switch (listType)
                {
                    case ListType.Book:
                        Book b = lbItems.SelectedItem as Book;
                        ShowAllInfo(b);
                        ShowAllCopies(bookCopyService.All(b));
                        bookCopySelectedBook.Text = b.ToString();
                        break;
                    case ListType.Author:
                        Author a = lbItems.SelectedItem as Author;
                        ShowAllInfo(a);
                        List<BookCopy> bcList = new List<BookCopy>();
                        foreach (Book book in a.Books)
                        {
                            bcList.AddRange(book.Copies);
                        }
                        ShowAllCopies(bcList);
                        break;
                    case ListType.Loan:
                        Loan l = lbItems.SelectedItem as Loan;
                        List<BookCopy> bc = new List<BookCopy>();
                        bc.Add(l.BookCopy);
                        ShowAllInfo(l);
                        ShowAllCopies(bc);
                        break;
                    case ListType.Member:
                        Member m = lbItems.SelectedItem as Member;
                        ShowAllInfo(m);
                        List<BookCopy> bcl = new List<BookCopy>();
                        foreach (Loan loan in m.Loans)
                        {
                            bcl.Add(loan.BookCopy);
                        }
                        ShowAllCopies(bcl);
                        break;
                }
            }
        }

        private void lbCopies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbCopies.SelectedItem != null)
            {
                selectedBookCopyLoan.Text = (lbCopies.SelectedItem as BookCopy).ToString();
            }
        }

        private void BTNChangeBook_Click(object sender, EventArgs e)
        {
            //TODO: delet
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

        private void newBookCopyBtn_Click(object sender, EventArgs e)
        {
            Book b = lbItems.SelectedItem as Book;
            if (b != null)
            {
                BookCopy bc = new BookCopy
                {
                    Book = b,
                    Condition = Convert.ToInt32(copyCondition.Value),
                    Status = Status.AVAILABLE
                };
                b.Copies.Add(bc);
                bookCopyService.Add(bc);
            }
        }

        private void authorAddBtn_Click(object sender, EventArgs e)
        {
            authorService.Add(new Author { Name = authorAddName.Text });
        }

        private void memberAddBtn_Click(object sender, EventArgs e)
        {
            Member m = new Member()
            {
                Name = memberAddName.Text,
                PersonalId = memberAddid.Text,
                MembershipDate = DateTime.Now
            };
            memberService.Add(m);
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

        private void showAllAvailableOfBookBtn_Click(object sender, EventArgs e)
        {
            listType = ListType.Book;
            ShowAllCopies(bookCopyService.AllAvailable(lbItems.SelectedItem as Book));
        }

        private void sortByAuthorBtn_Click(object sender, EventArgs e)
        {
            listType = ListType.Book;
            ShowAllItems(bookService.GetAllThatHasAuthor(authorNameBox.Text));
        }

        private void sortByTitleBtn_Click(object sender, EventArgs e)
        {
            listType = ListType.Book;
            ShowAllItems(bookService.GetAllThatHasTitle(bookTitleBox.Text));
        }

        private void showAllAvailableBooksBtn_Click(object sender, EventArgs e)
        {
            listType = ListType.Book;
            ShowAllItems(bookService.GetAllAvailable());
            ShowAllCopies(bookCopyService.AllAvailable());
        }

        private void showAllBooksBtn_Click(object sender, EventArgs e)
        {
            listType = ListType.Book;
            ShowAllItems(bookService.All());
            ShowAllCopies(bookCopyService.All());
        }

        private void showAllMembersBtn_Click(object sender, EventArgs e)
        {
            listType = ListType.Member;
            ShowAllItems(memberService.All());
        }

        private void showAllAuthorsBtn_Click(object sender, EventArgs e)
        {
            listType = ListType.Author;
            ShowAllItems(authorService.All());
        }

        private void showAllLoansBtn_Click(object sender, EventArgs e)
        {
            listType = ListType.Loan;
            ShowAllItems(loanService.All());
        }

        private void loanSortMemberBtn_Click(object sender, EventArgs e)
        {
            listType = ListType.Loan;
            ShowAllItems(loanService.GetAllOfMember(memberNameLoanSort.Text));
        }

        private void loanSortBookBtn_Click(object sender, EventArgs e)
        {
            listType = ListType.Loan;
            ShowAllItems(loanService.GetAllofBook(bookTitleLoanSort.Text));
        }

        private void newLoanBtn_Click(object sender, EventArgs e)
        {
            Loan l = new Loan()
            {
                Member = availableMemberComboBox.SelectedItem as Member,
                BookCopy = lbCopies.SelectedItem as BookCopy,
                TimeOfLoan = DateTime.Now,
                DueDate = DateTime.Now.AddDays(15)
            };
            l.BookCopy.Status = Status.LOANED;
            bookCopyService.Edit(l.BookCopy);
            loanService.Add(l);
        }
    }
}
