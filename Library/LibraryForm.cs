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
    public enum ListType { Book, Author, Loan, Member }
    public enum SortType { IdDesc, IdAsc, TextDesc, TextAsc}
    public partial class LibraryForm : Form
    {
        BookService bookService;
        AuthorService authorService;
        BookCopyService bookCopyService;
        LoanService loanService;
        MemberService memberService;
        public ListType listType = new ListType();
        public SortType sortType = SortType.IdDesc;
        public LibraryForm()
        {
            InitializeComponent();
            LibraryContext context = new LibraryContext();
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

        private void BookService_Updated(object sender, UpdatedEventArgs e)
        {
            if (listType == ListType.Book)
            {
                ShowAllItems(bookService.All());
            }
            dbUpdatedMsg(sender, e);
        }

        private void BookCopyService_Updated(object sender, UpdatedEventArgs e)
        {
            ShowAllCopies(bookCopyService.All(lbItems.SelectedItem as Book));
            dbUpdatedMsg(sender, e);
        }

        private void AuthorService_Updated(object sender, UpdatedEventArgs e)
        {
            populateAuthorComboBox();
            if (listType == ListType.Author)
            {
                ShowAllItems(authorService.All());
            }
            dbUpdatedMsg(sender, e);
        }

        private void MemberService_Updated(object sender, UpdatedEventArgs e)
        {
            populateMemberComboBox();
            if (listType == ListType.Member)
            {
                ShowAllItems(memberService.All());
            }
            dbUpdatedMsg(sender, e);
        }

        private void LoanService_Updated(object sender, UpdatedEventArgs e)
        {
           if(listType == ListType.Loan)
           {
               ShowAllItems(loanService.All());
           }
            dbUpdatedMsg(sender, e);
        }

        private void dbUpdatedMsg(object sender, UpdatedEventArgs e)
        {
            dbUpdateInfo.Text = String.Format("" +
                "{0} performed " +
                "{1} on db at " +
                "{2}",
                sender.GetType().ToString().Split('.')[2], e.Action,e.UpdateTime.TimeOfDay);
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
            IEnumerable<T> sItem = sortList(item.ToList());
            foreach (T t in sItem)
            {
                lbItems.Items.Add(t);
            }
        }

        private void ShowAllCopies<T>(IEnumerable<T> items)
        {
            lbCopies.Items.Clear();
            IEnumerable<BookCopy> copies = sortList((items as IEnumerable<BookCopy>).ToList());
            switch (listType)
            {
                case ListType.Book:
                    foreach (BookCopy bc in copies)
                    {
                        lbCopies.Items.Add(bc);
                    }
                    break;
                case ListType.Author:
                    foreach (BookCopy bc in copies)
                    {
                        if (!lbCopies.Items.Contains(bc.Book))
                        {
                            lbCopies.Items.Add(bc.Book);
                        }
                    }
                    break;
                case ListType.Loan:
                    foreach (BookCopy bc in copies)
                    {
                        lbCopies.Items.Add(bc);
                    }
                    break;
                case ListType.Member:
                    foreach (BookCopy bc in copies)
                    {
                        lbCopies.Items.Add(bc);
                    }
                    break;
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
                    lbInfo.Items.Add("Books :");
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
                    if (l.DueDate >= DateTime.Now && l.TimeOfReturn == null)
                    {
                        lbInfo.Items.Add("Status: "+ l.BookCopy.Status);
                    }
                    else if (l.DueDate <= DateTime.Now && l.TimeOfReturn == null)
                    {
                        lbInfo.Items.Add("Status: "+ l.BookCopy.Status);
                        lbInfo.Items.Add("Missed due date; a fee of "+l.OvertimeFine+"kr will be applied.");
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
                    lbInfo.Items.Add("Loans: ");
                    foreach(Loan loan in m.Loans)
                    {
                        lbInfo.Items.Add(loan);
                    }
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
                        bookCopySelectedBook.Text = String.Format("{0}",b.Title);
                        break;
                    case ListType.Author:
                        Author a = lbItems.SelectedItem as Author;
                        ShowAllInfo(a);
                        List<BookCopy> bList = new List<BookCopy>();
                        foreach (Book book in a.Books)
                        {
                            bList.AddRange(book.Copies);
                        }
                        ShowAllCopies(bList);
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
                BookCopy bc = lbCopies.SelectedItem as BookCopy;
                switch (listType)
                {
                    case ListType.Book:
                        selectedBookCopyLoan.Text = String.Format("{0} - {1}", bc.Id, bc.Book.Title);
                        break;
                    case ListType.Loan:
                        selectedLoanBox.Text = String.Format("{0} - {1}", bc.Id, bc.Book.Title);
                        break;
                }
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
            authorNameCombo.SelectedItem = 0;
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
            resetSelection();
        }

        private void authorAddBtn_Click(object sender, EventArgs e)
        {
            authorService.Add(new Author { Name = authorAddName.Text });
            authorAddName.Clear();
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
            memberAddName.Clear();
            memberAddid.Clear();
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

        private void showBooksWithoutCopies_Click(object sender, EventArgs e)
        {
            listType = ListType.Book;
            ShowAllItems(bookService.GetAllWithoutCopies());
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
            if (lbCopies.SelectedItem == null) { return; }
            Loan l = new Loan()
            {
                Member = availableMemberComboBox.SelectedItem as Member,
                BookCopy = lbCopies.SelectedItem as BookCopy,
                TimeOfLoan = DateTime.Now,
                DueDate = DateTime.Now.AddDays(15),
                State = State.Active
            };
            l.BookCopy.Status = Status.LOANED;
            bookCopyService.Edit(l.BookCopy);
            loanService.Add(l);
            resetSelection();
        }

        private void loanReturnBookBtn_Click(object sender, EventArgs e)
        {
            BookCopy bc = lbCopies.SelectedItem as BookCopy;
            if (bc == null) { return; }
            Loan l = loanService.Find(bc);
            l.BookCopy.Status = Status.AVAILABLE;
            bookCopyService.Edit(l.BookCopy);
            l.State = State.Archived;
            l.TimeOfReturn = DateTime.Now;
            loanService.Edit(l);
            resetSelection();
        }

        private void loanChangeDateBtn_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker.Value;
            BookCopy bc = lbCopies.SelectedItem as BookCopy;
            if (bc == null) { return; }
            Loan l = loanService.Find(bc);
            l.DueDate = date;
            loanService.Edit(l);
            overtimeCheckBtn_Click(sender,e);
            resetSelection();
        }

        private void overtimeCheckBtn_Click(object sender, EventArgs e)
        {
            List<Loan> loans = loanService.getOvertimedLoans().ToList();
            foreach (Loan l in loans)
            {
                l.OvertimeFine = 0;
                l.OvertimeFine += ((DateTime.Now - l.DueDate).Days * 10);
                loanService.Edit(l);
                l.BookCopy.Status = Status.OVERDUE;
                bookCopyService.Edit(l.BookCopy);
            }
            resetSelection();
        }

        private void resetSelection()
        {
            lbCopies.ClearSelected();
            lbItems.ClearSelected();
        }

        private List<Book> sortList(List<Book> list)
        {
            List<Book>sList = new List<Book>();
            switch (sortType)
            {
                case SortType.IdAsc:
                    sList = bookService.sortIdAsc(list);
                    break;
                case SortType.IdDesc:
                    sList = bookService.sortIdDesc(list);
                    break;
                case SortType.TextAsc:
                    sList = bookService.sortTextAsc(list);
                    break;
                case SortType.TextDesc:
                    sList = bookService.sortTextDesc(list);
                    break;
            }
            return sList;
        }

        private List<BookCopy> sortList(List<BookCopy> list)
        {
            List<BookCopy> sList = new List<BookCopy>();
            switch (sortType)
            {
                case SortType.IdAsc:
                    sList = bookCopyService.sortIdAsc(list);
                    break;
                case SortType.IdDesc:
                    sList = bookCopyService.sortIdDesc(list);
                    break;
                case SortType.TextAsc:
                    sList = bookCopyService.sortTextAsc(list);
                    break;
                case SortType.TextDesc:
                    sList = bookCopyService.sortTextDesc(list);
                    break;
            }
            return sList;
        }

        private List<Author> sortList(List<Author> list)
        {
            List<Author> sList = new List<Author>();
            switch (sortType)
            {
                case SortType.IdAsc:
                    sList = authorService.sortIdAsc(list);
                    break;
                case SortType.IdDesc:
                    sList = authorService.sortIdDesc(list);
                    break;
                case SortType.TextAsc:
                    sList = authorService.sortTextAsc(list);
                    break;
                case SortType.TextDesc:
                    sList = authorService.sortTextDesc(list);
                    break;
            }
            return sList;
        }

        private List<Member> sortList(List<Member> list)
        {
            List<Member> sList = new List<Member>();
            switch (sortType)
            {
                case SortType.IdAsc:
                    sList = memberService.sortIdAsc(list);
                    break;
                case SortType.IdDesc:
                    sList = memberService.sortIdDesc(list);
                    break;
                case SortType.TextAsc:
                    sList = memberService.sortTextAsc(list);
                    break;
                case SortType.TextDesc:
                    sList = memberService.sortTextDesc(list);
                    break;
            }
            return sList;
        }

        private List<Loan> sortList(List<Loan> list)
        {
            List<Loan> sList = new List<Loan>();
            switch (sortType)
            {
                case SortType.IdAsc:
                    sList = loanService.sortIdAsc(list);
                    break;
                case SortType.IdDesc:
                    sList = loanService.sortIdDesc(list);
                    break;
                case SortType.TextAsc:
                    sList = loanService.sortTextAsc(list);
                    break;
                case SortType.TextDesc:
                    sList = loanService.sortTextDesc(list);
                    break;
            }
            return sList;
        }

        private IEnumerable<T> sortList<T>(List<T> list)
        {

            switch (listType)
            {
                case (ListType.Author):
                    return sortList(list as List<Author>) as IEnumerable<T>;
                case (ListType.Loan):
                    return sortList(list as List<Loan>) as IEnumerable<T>;
                case (ListType.Member):
                    return sortList(list as List<Member>) as IEnumerable<T>;
                default:
                    return sortList(list as List<Book>) as IEnumerable<T>;
            }
        }

        private void idAscRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (idAscRadio.Checked)
            {
                sortType = SortType.IdAsc;
            }
        }

        private void idDescRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (idDescRadio.Checked)
            {
                sortType = SortType.IdDesc;
            }
        }

        private void nameAscRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (nameAscRadio.Checked)
            {
                sortType = SortType.TextAsc;
            }
        }

        private void nameDescRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (nameDescRadio.Checked)
            {
                sortType = SortType.TextDesc;
            }
        }
    }
}
