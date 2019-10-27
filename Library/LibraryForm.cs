using Library.Models;
using Library.Repositories;
using Library.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Library

{   /// <summary>
    /// Defines what type of model the ui will currently show.
    /// </summary>
    public enum ListType { Book, Author, Loan, Member }

    /// <summary>
    /// Defines what type of sorting the ui will currently show.
    /// </summary>
    public enum SortType { IdDesc, IdAsc, TextDesc, TextAsc}

    /// <summary>
    /// UI class.
    /// </summary>
    public partial class LibraryForm : Form
    {
        BookService bookService;
        AuthorService authorService;
        BookCopyService bookCopyService;
        LoanService loanService;
        MemberService memberService;
        public ListType listType = new ListType();
        public SortType sortType = SortType.IdAsc;
        public LibraryForm()
        {
            InitializeComponent();
            LibraryContext context = new LibraryContext();
            RepositoryFactory repFactory = new RepositoryFactory(context);

            bookService = new BookService(repFactory);
            authorService = new AuthorService(repFactory);
            bookCopyService = new BookCopyService(repFactory);
            loanService = new LoanService(repFactory);
            memberService = new MemberService(repFactory);
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
            IEnumerable<T> sItem = SortList(item.ToList());
            foreach (T t in sItem)
            {
                lbItems.Items.Add(t);
            }
        }

        private void ShowAllCopies<T>(IEnumerable<T> items)
        {
            lbCopies.Items.Clear();
            IEnumerable<BookCopy> copies = SortList((items as IEnumerable<BookCopy>).ToList());
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

        private void LbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbItems.SelectedItem != null)
            {
                switch (listType)
                {
                    case ListType.Book:
                        Book b = lbItems.SelectedItem as Book;
                        ShowAllInfo(b);
                        ShowAllCopies(bookCopyService.All(b));
                        bookCopySelectedBook.Text = b.Title;
                        bookSelectedEdit.Text = b.Title;
                        bookEditTitleBox.Text = b.Title;
                        bookEditIsbnBox.Text = b.ISBN;
                        BookEditDescBox.Text = b.Description;
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
                    default:
                        break;
                }
            }
        }

        private void LbCopies_SelectedIndexChanged(object sender, EventArgs e)
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
                    default:
                        break;
                }
            }
            else
            {
                selectedBookCopyLoan.Clear();
                selectedLoanBox.Clear();
            }
        }

        private void ResetSelection()
        {
            lbCopies.ClearSelected();
            lbItems.ClearSelected();
            selectedBookCopyLoan.Clear();
            selectedLoanBox.Clear();
            bookCopySelectedBook.Clear();
        }

        private IEnumerable<Book> SortList(List<Book> list)
        {
            IEnumerable<Book> sList = new List<Book>();
            switch (sortType)
            {
                case SortType.IdAsc:
                    sList = bookService.SortIdAsc(list);
                    break;
                case SortType.IdDesc:
                    sList = bookService.SortIdDesc(list);
                    break;
                case SortType.TextAsc:
                    sList = bookService.SortTextAsc(list);
                    break;
                case SortType.TextDesc:
                    sList = bookService.SortTextDesc(list);
                    break;
                default:
                    sList = list;
                    break;
            }
            return sList;
        }

        private IEnumerable<BookCopy> SortList(List<BookCopy> list)
        {
            IEnumerable<BookCopy> sList = new List<BookCopy>();
            switch (sortType)
            {
                case SortType.IdAsc:
                    sList = bookCopyService.SortIdAsc(list);
                    break;
                case SortType.IdDesc:
                    sList = bookCopyService.SortIdDesc(list);
                    break;
                case SortType.TextAsc:
                    sList = bookCopyService.SortTextAsc(list);
                    break;
                case SortType.TextDesc:
                    sList = bookCopyService.SortTextDesc(list);
                    break;
                default:
                    sList = list;
                    break;
            }
            return sList;
        }

        private IEnumerable<Author> SortList(List<Author> list)
        {
            IEnumerable<Author> sList = new List<Author>();
            switch (sortType)
            {
                case SortType.IdAsc:
                    sList = authorService.SortIdAsc(list);
                    break;
                case SortType.IdDesc:
                    sList = authorService.SortIdDesc(list);
                    break;
                case SortType.TextAsc:
                    sList = authorService.SortTextAsc(list);
                    break;
                case SortType.TextDesc:
                    sList = authorService.SortTextDesc(list);
                    break;
                default:
                    sList = list;
                    break;
            }
            return sList;
        }

        private IEnumerable<Member> SortList(List<Member> list)
        {
            IEnumerable<Member> sList = new List<Member>();
            switch (sortType)
            {
                case SortType.IdAsc:
                    sList = memberService.SortIdAsc(list);
                    break;
                case SortType.IdDesc:
                    sList = memberService.SortIdDesc(list);
                    break;
                case SortType.TextAsc:
                    sList = memberService.SortTextAsc(list);
                    break;
                case SortType.TextDesc:
                    sList = memberService.SortTextDesc(list);
                    break;
                default:
                    sList = list;
                    break;
            }
            return sList;
        }

        private IEnumerable<Loan> SortList(List<Loan> list)
        {
            IEnumerable<Loan> sList = new List<Loan>();
            switch (sortType)
            {
                case SortType.IdAsc:
                    sList = loanService.SortIdAsc(list);
                    break;
                case SortType.IdDesc:
                    sList = loanService.SortIdDesc(list);
                    break;
                case SortType.TextAsc:
                    sList = loanService.SortTextAsc(list);
                    break;
                case SortType.TextDesc:
                    sList = loanService.SortTextDesc(list);
                    break;
                default:
                    sList = list;
                    break;
            }
            return sList;
        }

        private IEnumerable<T> SortList<T>(List<T> list)
        {

            switch (listType)
            {
                case ListType.Author:
                    return SortList(list as List<Author>) as IEnumerable<T>;
                case ListType.Loan:
                    return SortList(list as List<Loan>) as IEnumerable<T>;
                case ListType.Member:
                    return SortList(list as List<Member>) as IEnumerable<T>;
                default:
                    return SortList(list as List<Book>) as IEnumerable<T>;
            }
        }

        private void UpdateLists()
        {
            switch (listType)
            {
                case ListType.Author:
                    ShowAllItems(lbItems.Items.Cast<Author>().ToList());
                    break;
                case ListType.Loan:
                    ShowAllItems(lbItems.Items.Cast<Loan>().ToList());
                    break;
                case ListType.Member:
                    ShowAllItems(lbItems.Items.Cast<Member>().ToList());
                    break;
                default:
                    ShowAllItems(lbItems.Items.Cast<Book>().ToList());
                    break;
            }
            ShowAllCopies(lbCopies.Items.Cast<BookCopy>().ToList());
        }

        private void IdAscRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (idAscRadio.Checked)
            {
                sortType = SortType.IdAsc;
                UpdateLists();
            }
        }

        private void IdDescRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (idDescRadio.Checked)
            {
                sortType = SortType.IdDesc;
                UpdateLists();
            }
        }

        private void NameAscRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (nameAscRadio.Checked)
            {
                sortType = SortType.TextAsc;
                UpdateLists();
            }
        }

        private void NameDescRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (nameDescRadio.Checked)
            {
                sortType = SortType.TextDesc;
                UpdateLists();
            }
        }

        public void ShowMsgBox(DbEntityValidationException ex)
        {
            string Caption = "Database Error!";
            StringBuilder errorMsg = new StringBuilder();
            foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
            {
                foreach (DbValidationError subItem in item.ValidationErrors)
                {
                    errorMsg.Append(subItem.ErrorMessage + "\n");
                }
            }
            MessageBox.Show(errorMsg.ToString(), Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowMsgBox(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //----------------------- BOOK SERVICE -----------------------
        private void BookNewBtn_Click(object sender, EventArgs e)
        {
            try
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
            catch (DbEntityValidationException ex)
            {
                ShowMsgBox(ex);
                bookService.Reset();
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex);
            }
            authorNameCombo.SelectedItem = 0;
        }

        private void BookSortByAuthorBtn_Click(object sender, EventArgs e)
        {
            try
            {
                listType = ListType.Book;
                ShowAllItems(bookService.GetAllThatHasAuthor(authorNameBox.Text));
            }
            catch (DbEntityValidationException ex)
            {
                ShowMsgBox(ex);
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex);
            }
        }

        private void BookSortByTitleBtn_Click(object sender, EventArgs e)
        {
            try
            {
                listType = ListType.Book;
                ShowAllItems(bookService.GetAllThatHasTitle(bookTitleBox.Text));
            }
            catch (DbEntityValidationException ex)
            {
                ShowMsgBox(ex);
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex);
            }
        }

        private void BookShowAllAvailableBtn_Click(object sender, EventArgs e)
        {
            try
            {
                listType = ListType.Book;
                ShowAllItems(bookService.GetAllAvailable());
                ShowAllCopies(bookCopyService.AllAvailable());
            }
            catch (DbEntityValidationException ex)
            {
                ShowMsgBox(ex);
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex);
            }
        }

        private void BookShowAllBtn_Click(object sender, EventArgs e)
        {
            try
            {
                listType = ListType.Book;
                ShowAllItems(bookService.All());
                ShowAllCopies(bookCopyService.All());
            }
            catch (DbEntityValidationException ex)
            {
                ShowMsgBox(ex);
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex);
            }
        }

        private void BookShowWithoutCopies_Click(object sender, EventArgs e)
        {
            try
            {
                listType = ListType.Book;
                ShowAllItems(bookService.GetAllWithoutCopies());
            }
            catch (DbEntityValidationException ex)
            {
                ShowMsgBox(ex);
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex);
            }
        }

        private void BookEditSelectedBtn_Click(object sender, EventArgs e)
        {
            try
            {
                listType = ListType.Book;
                Book selectedBook = lbItems.SelectedItem as Book;
                selectedBook.Title = bookEditTitleBox.Text;
                selectedBook.ISBN = bookEditIsbnBox.Text;
                selectedBook.Description = BookEditDescBox.Text;
                bookService.Edit(selectedBook);
            }
            catch (DbEntityValidationException ex)
            {
                ShowMsgBox(ex);
                bookService.Reset();
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex);
            }
            bookEditTitleBox.Clear();
            bookEditIsbnBox.Clear();
            BookEditDescBox.Clear();
        }
        
        //----------------------- BOOKCOPY SERVICE -----------------------
        private void BookCopyNewBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Book b = lbItems.SelectedItem as Book;
                BookCopy bc = new BookCopy
                {
                    Book = b,
                    Condition = Convert.ToInt32(copyCondition.Value),
                    Status = Status.AVAILABLE
                };
                bookCopyService.Add(bc);
                b.Copies.Add(bc);
            }
            catch (DbEntityValidationException ex)
            {
                ShowMsgBox(ex);
                bookCopyService.Reset();
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex);
            }
            ResetSelection();
        }

        private void BookCopyShowAllAvailableBtn_Click(object sender, EventArgs e)
        {
            try
            {
                listType = ListType.Book;
                ShowAllCopies(bookCopyService.AllAvailable(lbItems.SelectedItem as Book));
            }
            catch (DbEntityValidationException ex)
            {
                ShowMsgBox(ex);
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex);
            }
        }

        //----------------------- AUTHOR SERVICE -----------------------
        private void AuthorAddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Author a = new Author { Name = authorAddName.Text };
                authorService.Add(a);
            }
            catch (DbEntityValidationException ex)
            {
                ShowMsgBox(ex);
                authorService.Reset();
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex);
            }
            authorAddName.Clear();
        }

        private void AuthorsShowWithoutBooks_Click(object sender, EventArgs e)
        {
            try
            {
                listType = ListType.Author;
                ShowAllItems(authorService.GetAllWithoutBooks());
            }
            catch (DbEntityValidationException ex)
            {
                ShowMsgBox(ex);
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex);
            }

        }

        private void AuthorShowAllBtn_Click(object sender, EventArgs e)
        {
            try
            {
                listType = ListType.Author;
                ShowAllItems(authorService.All());
            }
            catch (DbEntityValidationException ex)
            {
                ShowMsgBox(ex);
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex);
            }
        }

        private void AuthorSortByBook_Click(object sender, EventArgs e)
        {
            try
            {
                listType = ListType.Author;
                Book b = bookService.GetBook(authorSortBookText.Text);
                IEnumerable<Author> a = authorService.GetAuthorByBook(b);
                ShowAllItems(a);
            }
            catch (DbEntityValidationException ex)
            {
                ShowMsgBox(ex);
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex);
            }
        }

        //----------------------- MEMBER SERVICE -----------------------
        private void MemberAddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Member m = new Member()
                {
                    Name = memberAddName.Text,
                    PersonalId = memberAddid.Text,
                    MembershipDate = DateTime.Now
                };
                memberService.Add(m);
            }
            catch (DbEntityValidationException ex)
            {
                ShowMsgBox(ex);
                memberService.Reset();
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex);
            }
            memberAddName.Clear();
            memberAddid.Clear();
        }

        private void MemberShowAllBtn_Click(object sender, EventArgs e)
        {
            try
            {
                listType = ListType.Member;
                ShowAllItems(memberService.All());
            }
            catch (DbEntityValidationException ex)
            {
                ShowMsgBox(ex);
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex);
            }
        }

        //----------------------- LOAN SERVICE -----------------------
        private void LoanShowAllBtn_Click(object sender, EventArgs e)
        {
            try
            {
                listType = ListType.Loan;
                ShowAllItems(loanService.All());
            }
            catch (DbEntityValidationException ex)
            {
                ShowMsgBox(ex);
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex);
            }
        }

        private void LoanSortMemberBtn_Click(object sender, EventArgs e)
        {
            try
            {
                listType = ListType.Loan;
                ShowAllItems(loanService.GetAllOfMember(memberNameLoanSort.Text));
            }
            catch (DbEntityValidationException ex)
            {
                ShowMsgBox(ex);
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex);
            }
        }

        private void LoanSortBookBtn_Click(object sender, EventArgs e)
        {
            try
            {
                listType = ListType.Loan;
                ShowAllItems(loanService.GetAllofBook(bookTitleLoanSort.Text));
            }
            catch (DbEntityValidationException ex)
            {
                ShowMsgBox(ex);
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex);
            }
        }

        private void LoanNewBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Member m = availableMemberComboBox.SelectedItem as Member;
                BookCopy bc = lbCopies.SelectedItem as BookCopy;
                Loan l = new Loan()
                {
                    Member = m,
                    BookCopy = bc,
                    TimeOfLoan = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(15),
                    State = State.Active
                };
                loanService.Add(l);
                if (bc.Status != Status.AVAILABLE)
                {
                    throw new Exception("Cannot loan a book copy that is not available.");
                }
                l.BookCopy.Status = Status.LOANED;
                bookCopyService.Edit(bc);
                ResetSelection();
            }
            catch (DbEntityValidationException ex)
            {
                ShowMsgBox(ex);
                bookCopyService.Reset();
                loanService.Reset();
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex);
            }
            ResetSelection();
        }

        private void LoanReturnBookBtn_Click(object sender, EventArgs e)
        {
            try
            {
                BookCopy bc = lbCopies.SelectedItem as BookCopy;
                Loan l = loanService.Find(bc);
                l.BookCopy.Status = Status.AVAILABLE;
                bookCopyService.Edit(l.BookCopy);
                l.State = State.Archived;
                l.TimeOfReturn = DateTime.Now;
                loanService.Edit(l);
            }
            catch (DbEntityValidationException ex)
            {
                ShowMsgBox(ex);
                bookCopyService.Reset();
                loanService.Reset();
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex);
            }
            ResetSelection();
        }

        private void LoanChangeDateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime date = dateTimePicker.Value;
                BookCopy bc = lbCopies.SelectedItem as BookCopy;
                Loan l = loanService.Find(bc);
                l.DueDate = date;
                loanService.Edit(l);
                LoanOvertimeCheckBtn_Click(sender, e);
            }
            catch (DbEntityValidationException ex)
            {
                ShowMsgBox(ex);
                loanService.Reset();
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex);
            }
            ResetSelection();
        }

        private void LoanShowAllActiveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                listType = ListType.Loan;
                ShowAllItems(loanService.GetAllActiveLoans());
            }
            catch (DbEntityValidationException ex)
            {
                ShowMsgBox(ex);
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex);
            }
        }

        private void LoanShowAllArchivedBtn_Click(object sender, EventArgs e)
        {
            try
            {
                listType = ListType.Loan;
                ShowAllItems(loanService.GetAllArchivedLoans());
            }
            catch (DbEntityValidationException ex)
            {
                ShowMsgBox(ex);
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex);
            }
        }

        private void LoanOvertimeCheckBtn_Click(object sender, EventArgs e)
        {
            try
            {
                List<Loan> loans = loanService.GetOvertimedLoans().ToList();
                foreach (Loan l in loans)
                {
                    l.OvertimeFine = (DateTime.Now - l.DueDate).Days * 10;
                    loanService.Edit(l);
                    l.BookCopy.Status = Status.OVERDUE;
                    bookCopyService.Edit(l.BookCopy);
                }
            }
            catch (DbEntityValidationException ex)
            {
                ShowMsgBox(ex);
                loanService.Reset();
                bookCopyService.Reset();
            }
            catch (Exception ex)
            {
                ShowMsgBox(ex);
            }
            ResetSelection();
        }
    }
}
