namespace Library {
    partial class LibraryForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lbItems = new System.Windows.Forms.ListBox();
            this.BTNChangeBook = new System.Windows.Forms.Button();
            this.lbInfo = new System.Windows.Forms.ListBox();
            this.newBookBtn = new System.Windows.Forms.Button();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.isbnTextBox = new System.Windows.Forms.TextBox();
            this.descTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.removeBtn = new System.Windows.Forms.Button();
            this.lbCopies = new System.Windows.Forms.ListBox();
            this.showAllAvailableOfBookBtn = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.bookTab = new System.Windows.Forms.TabPage();
            this.showAllAvailableBooksBtn = new System.Windows.Forms.Button();
            this.bookTitleBox = new System.Windows.Forms.TextBox();
            this.sortByTitleBtn = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.addBookTab = new System.Windows.Forms.TabPage();
            this.authorNameCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.addCopyTab = new System.Windows.Forms.TabPage();
            this.bookCopySelectedBook = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.copyCondition = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.newBookCopyBtn = new System.Windows.Forms.Button();
            this.editBookTab = new System.Windows.Forms.TabPage();
            this.authorNameBox = new System.Windows.Forms.TextBox();
            this.sortByAuthorBtn = new System.Windows.Forms.Button();
            this.loanTab = new System.Windows.Forms.TabPage();
            this.bookTitleLoanSort = new System.Windows.Forms.TextBox();
            this.loanSortMemberBtn = new System.Windows.Forms.Button();
            this.memberNameLoanSort = new System.Windows.Forms.TextBox();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.newLoanTab = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.selectedBookCopyLoan = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.newLoanBtn = new System.Windows.Forms.Button();
            this.availableMemberComboBox = new System.Windows.Forms.ComboBox();
            this.editLoanTab = new System.Windows.Forms.TabPage();
            this.loanChangeDateBtn = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.selectedLoanBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.loanReturnBookBtn = new System.Windows.Forms.Button();
            this.loanSortBookBtn = new System.Windows.Forms.Button();
            this.authorMemberTab = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.newAuthorTab = new System.Windows.Forms.TabPage();
            this.authorAddBtn = new System.Windows.Forms.Button();
            this.authorAddName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.newMemberTab = new System.Windows.Forms.TabPage();
            this.memberAddid = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.memberAddBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.memberAddName = new System.Windows.Forms.TextBox();
            this.showAllBooksBtn = new System.Windows.Forms.Button();
            this.showAllLoansBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.showAllMembersBtn = new System.Windows.Forms.Button();
            this.showAllAuthorsBtn = new System.Windows.Forms.Button();
            this.idAscRadio = new System.Windows.Forms.RadioButton();
            this.idDescRadio = new System.Windows.Forms.RadioButton();
            this.nameDescRadio = new System.Windows.Forms.RadioButton();
            this.nameAscRadio = new System.Windows.Forms.RadioButton();
            this.overtimeCheckBtn = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.bookTab.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.addBookTab.SuspendLayout();
            this.addCopyTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.copyCondition)).BeginInit();
            this.editBookTab.SuspendLayout();
            this.loanTab.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.newLoanTab.SuspendLayout();
            this.editLoanTab.SuspendLayout();
            this.authorMemberTab.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.newAuthorTab.SuspendLayout();
            this.newMemberTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbItems
            // 
            this.lbItems.FormattingEnabled = true;
            this.lbItems.Location = new System.Drawing.Point(263, 27);
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(191, 303);
            this.lbItems.TabIndex = 0;
            this.lbItems.SelectedIndexChanged += new System.EventHandler(this.lbItems_SelectedIndexChanged);
            // 
            // BTNChangeBook
            // 
            this.BTNChangeBook.Location = new System.Drawing.Point(3, 2);
            this.BTNChangeBook.Margin = new System.Windows.Forms.Padding(2);
            this.BTNChangeBook.Name = "BTNChangeBook";
            this.BTNChangeBook.Size = new System.Drawing.Size(161, 34);
            this.BTNChangeBook.TabIndex = 1;
            this.BTNChangeBook.Text = "TO BE REMOVED: Change the selected book title";
            this.BTNChangeBook.UseVisualStyleBackColor = true;
            this.BTNChangeBook.Click += new System.EventHandler(this.BTNChangeBook_Click);
            // 
            // lbInfo
            // 
            this.lbInfo.FormattingEnabled = true;
            this.lbInfo.Location = new System.Drawing.Point(460, 27);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(264, 69);
            this.lbInfo.TabIndex = 2;
            // 
            // newBookBtn
            // 
            this.newBookBtn.Location = new System.Drawing.Point(6, 114);
            this.newBookBtn.Name = "newBookBtn";
            this.newBookBtn.Size = new System.Drawing.Size(213, 23);
            this.newBookBtn.TabIndex = 3;
            this.newBookBtn.Text = "Add new book";
            this.newBookBtn.UseVisualStyleBackColor = true;
            this.newBookBtn.Click += new System.EventHandler(this.newBookBtn_Click);
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(69, 6);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(150, 20);
            this.titleTextBox.TabIndex = 4;
            // 
            // isbnTextBox
            // 
            this.isbnTextBox.Location = new System.Drawing.Point(69, 32);
            this.isbnTextBox.Name = "isbnTextBox";
            this.isbnTextBox.Size = new System.Drawing.Size(150, 20);
            this.isbnTextBox.TabIndex = 5;
            // 
            // descTextBox
            // 
            this.descTextBox.Location = new System.Drawing.Point(69, 58);
            this.descTextBox.Name = "descTextBox";
            this.descTextBox.Size = new System.Drawing.Size(150, 20);
            this.descTextBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "ISBN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Description";
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(3, 117);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(134, 23);
            this.removeBtn.TabIndex = 10;
            this.removeBtn.Text = "Remove selected book";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // lbCopies
            // 
            this.lbCopies.FormattingEnabled = true;
            this.lbCopies.Location = new System.Drawing.Point(460, 131);
            this.lbCopies.Name = "lbCopies";
            this.lbCopies.Size = new System.Drawing.Size(264, 199);
            this.lbCopies.TabIndex = 11;
            this.lbCopies.SelectedIndexChanged += new System.EventHandler(this.lbCopies_SelectedIndexChanged);
            // 
            // showAllAvailableOfBookBtn
            // 
            this.showAllAvailableOfBookBtn.Location = new System.Drawing.Point(7, 103);
            this.showAllAvailableOfBookBtn.Name = "showAllAvailableOfBookBtn";
            this.showAllAvailableOfBookBtn.Size = new System.Drawing.Size(206, 20);
            this.showAllAvailableOfBookBtn.TabIndex = 13;
            this.showAllAvailableOfBookBtn.Text = "Show Available copies of selected book";
            this.showAllAvailableOfBookBtn.UseVisualStyleBackColor = true;
            this.showAllAvailableOfBookBtn.Click += new System.EventHandler(this.showAllAvailableOfBookBtn_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.bookTab);
            this.tabControl.Controls.Add(this.loanTab);
            this.tabControl.Controls.Add(this.authorMemberTab);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(245, 370);
            this.tabControl.TabIndex = 14;
            // 
            // bookTab
            // 
            this.bookTab.Controls.Add(this.showAllAvailableBooksBtn);
            this.bookTab.Controls.Add(this.bookTitleBox);
            this.bookTab.Controls.Add(this.sortByTitleBtn);
            this.bookTab.Controls.Add(this.tabControl2);
            this.bookTab.Controls.Add(this.showAllAvailableOfBookBtn);
            this.bookTab.Controls.Add(this.authorNameBox);
            this.bookTab.Controls.Add(this.sortByAuthorBtn);
            this.bookTab.Location = new System.Drawing.Point(4, 22);
            this.bookTab.Name = "bookTab";
            this.bookTab.Padding = new System.Windows.Forms.Padding(3);
            this.bookTab.Size = new System.Drawing.Size(237, 344);
            this.bookTab.TabIndex = 0;
            this.bookTab.Text = "Books";
            this.bookTab.UseVisualStyleBackColor = true;
            // 
            // showAllAvailableBooksBtn
            // 
            this.showAllAvailableBooksBtn.Location = new System.Drawing.Point(7, 78);
            this.showAllAvailableBooksBtn.Name = "showAllAvailableBooksBtn";
            this.showAllAvailableBooksBtn.Size = new System.Drawing.Size(120, 19);
            this.showAllAvailableBooksBtn.TabIndex = 21;
            this.showAllAvailableBooksBtn.Text = "Show Available books";
            this.showAllAvailableBooksBtn.UseVisualStyleBackColor = true;
            this.showAllAvailableBooksBtn.Click += new System.EventHandler(this.showAllAvailableBooksBtn_Click);
            // 
            // bookTitleBox
            // 
            this.bookTitleBox.Location = new System.Drawing.Point(7, 49);
            this.bookTitleBox.Name = "bookTitleBox";
            this.bookTitleBox.Size = new System.Drawing.Size(148, 20);
            this.bookTitleBox.TabIndex = 20;
            // 
            // sortByTitleBtn
            // 
            this.sortByTitleBtn.Location = new System.Drawing.Point(161, 48);
            this.sortByTitleBtn.Name = "sortByTitleBtn";
            this.sortByTitleBtn.Size = new System.Drawing.Size(71, 21);
            this.sortByTitleBtn.TabIndex = 19;
            this.sortByTitleBtn.Text = "Sort by title";
            this.sortByTitleBtn.UseVisualStyleBackColor = true;
            this.sortByTitleBtn.Click += new System.EventHandler(this.sortByTitleBtn_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.addBookTab);
            this.tabControl2.Controls.Add(this.addCopyTab);
            this.tabControl2.Controls.Add(this.editBookTab);
            this.tabControl2.Location = new System.Drawing.Point(2, 173);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(233, 169);
            this.tabControl2.TabIndex = 15;
            // 
            // addBookTab
            // 
            this.addBookTab.Controls.Add(this.titleTextBox);
            this.addBookTab.Controls.Add(this.authorNameCombo);
            this.addBookTab.Controls.Add(this.isbnTextBox);
            this.addBookTab.Controls.Add(this.label4);
            this.addBookTab.Controls.Add(this.newBookBtn);
            this.addBookTab.Controls.Add(this.descTextBox);
            this.addBookTab.Controls.Add(this.label1);
            this.addBookTab.Controls.Add(this.label2);
            this.addBookTab.Controls.Add(this.label3);
            this.addBookTab.Location = new System.Drawing.Point(4, 22);
            this.addBookTab.Name = "addBookTab";
            this.addBookTab.Padding = new System.Windows.Forms.Padding(3);
            this.addBookTab.Size = new System.Drawing.Size(225, 143);
            this.addBookTab.TabIndex = 0;
            this.addBookTab.Text = "Add book";
            this.addBookTab.UseVisualStyleBackColor = true;
            // 
            // authorNameCombo
            // 
            this.authorNameCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.authorNameCombo.FormattingEnabled = true;
            this.authorNameCombo.Location = new System.Drawing.Point(69, 84);
            this.authorNameCombo.Name = "authorNameCombo";
            this.authorNameCombo.Size = new System.Drawing.Size(150, 21);
            this.authorNameCombo.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Author";
            // 
            // addCopyTab
            // 
            this.addCopyTab.Controls.Add(this.bookCopySelectedBook);
            this.addCopyTab.Controls.Add(this.label13);
            this.addCopyTab.Controls.Add(this.copyCondition);
            this.addCopyTab.Controls.Add(this.label14);
            this.addCopyTab.Controls.Add(this.newBookCopyBtn);
            this.addCopyTab.Location = new System.Drawing.Point(4, 22);
            this.addCopyTab.Name = "addCopyTab";
            this.addCopyTab.Padding = new System.Windows.Forms.Padding(3);
            this.addCopyTab.Size = new System.Drawing.Size(225, 143);
            this.addCopyTab.TabIndex = 1;
            this.addCopyTab.Text = "Add Copy";
            this.addCopyTab.UseVisualStyleBackColor = true;
            // 
            // bookCopySelectedBook
            // 
            this.bookCopySelectedBook.Location = new System.Drawing.Point(6, 88);
            this.bookCopySelectedBook.Name = "bookCopySelectedBook";
            this.bookCopySelectedBook.ReadOnly = true;
            this.bookCopySelectedBook.Size = new System.Drawing.Size(213, 20);
            this.bookCopySelectedBook.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Selected Book:";
            // 
            // copyCondition
            // 
            this.copyCondition.Location = new System.Drawing.Point(6, 43);
            this.copyCondition.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.copyCondition.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.copyCondition.Name = "copyCondition";
            this.copyCondition.Size = new System.Drawing.Size(100, 20);
            this.copyCondition.TabIndex = 22;
            this.copyCondition.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(172, 13);
            this.label14.TabIndex = 19;
            this.label14.Text = "Condition of new book copy (1-10):";
            // 
            // newBookCopyBtn
            // 
            this.newBookCopyBtn.Location = new System.Drawing.Point(6, 114);
            this.newBookCopyBtn.Name = "newBookCopyBtn";
            this.newBookCopyBtn.Size = new System.Drawing.Size(213, 23);
            this.newBookCopyBtn.TabIndex = 12;
            this.newBookCopyBtn.Text = "Add new copy of selected book";
            this.newBookCopyBtn.UseVisualStyleBackColor = true;
            this.newBookCopyBtn.Click += new System.EventHandler(this.newBookCopyBtn_Click);
            // 
            // editBookTab
            // 
            this.editBookTab.Controls.Add(this.BTNChangeBook);
            this.editBookTab.Controls.Add(this.removeBtn);
            this.editBookTab.Location = new System.Drawing.Point(4, 22);
            this.editBookTab.Name = "editBookTab";
            this.editBookTab.Size = new System.Drawing.Size(225, 143);
            this.editBookTab.TabIndex = 2;
            this.editBookTab.Text = "Edit Books";
            this.editBookTab.UseVisualStyleBackColor = true;
            // 
            // authorNameBox
            // 
            this.authorNameBox.Location = new System.Drawing.Point(7, 17);
            this.authorNameBox.Name = "authorNameBox";
            this.authorNameBox.Size = new System.Drawing.Size(138, 20);
            this.authorNameBox.TabIndex = 15;
            // 
            // sortByAuthorBtn
            // 
            this.sortByAuthorBtn.Location = new System.Drawing.Point(151, 16);
            this.sortByAuthorBtn.Name = "sortByAuthorBtn";
            this.sortByAuthorBtn.Size = new System.Drawing.Size(82, 21);
            this.sortByAuthorBtn.TabIndex = 14;
            this.sortByAuthorBtn.Text = "Sort by author";
            this.sortByAuthorBtn.UseVisualStyleBackColor = true;
            this.sortByAuthorBtn.Click += new System.EventHandler(this.sortByAuthorBtn_Click);
            // 
            // loanTab
            // 
            this.loanTab.Controls.Add(this.overtimeCheckBtn);
            this.loanTab.Controls.Add(this.bookTitleLoanSort);
            this.loanTab.Controls.Add(this.loanSortMemberBtn);
            this.loanTab.Controls.Add(this.memberNameLoanSort);
            this.loanTab.Controls.Add(this.tabControl3);
            this.loanTab.Controls.Add(this.loanSortBookBtn);
            this.loanTab.Location = new System.Drawing.Point(4, 22);
            this.loanTab.Name = "loanTab";
            this.loanTab.Size = new System.Drawing.Size(237, 344);
            this.loanTab.TabIndex = 2;
            this.loanTab.Text = "Loans";
            this.loanTab.UseVisualStyleBackColor = true;
            // 
            // bookTitleLoanSort
            // 
            this.bookTitleLoanSort.Location = new System.Drawing.Point(7, 45);
            this.bookTitleLoanSort.Name = "bookTitleLoanSort";
            this.bookTitleLoanSort.Size = new System.Drawing.Size(134, 20);
            this.bookTitleLoanSort.TabIndex = 16;
            // 
            // loanSortMemberBtn
            // 
            this.loanSortMemberBtn.Location = new System.Drawing.Point(135, 16);
            this.loanSortMemberBtn.Name = "loanSortMemberBtn";
            this.loanSortMemberBtn.Size = new System.Drawing.Size(95, 21);
            this.loanSortMemberBtn.TabIndex = 15;
            this.loanSortMemberBtn.Text = "Sort by Member";
            this.loanSortMemberBtn.UseVisualStyleBackColor = true;
            this.loanSortMemberBtn.Click += new System.EventHandler(this.loanSortMemberBtn_Click);
            // 
            // memberNameLoanSort
            // 
            this.memberNameLoanSort.Location = new System.Drawing.Point(7, 17);
            this.memberNameLoanSort.Name = "memberNameLoanSort";
            this.memberNameLoanSort.Size = new System.Drawing.Size(122, 20);
            this.memberNameLoanSort.TabIndex = 4;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.newLoanTab);
            this.tabControl3.Controls.Add(this.editLoanTab);
            this.tabControl3.Location = new System.Drawing.Point(3, 173);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(231, 169);
            this.tabControl3.TabIndex = 2;
            // 
            // newLoanTab
            // 
            this.newLoanTab.Controls.Add(this.label11);
            this.newLoanTab.Controls.Add(this.selectedBookCopyLoan);
            this.newLoanTab.Controls.Add(this.label10);
            this.newLoanTab.Controls.Add(this.newLoanBtn);
            this.newLoanTab.Controls.Add(this.availableMemberComboBox);
            this.newLoanTab.Location = new System.Drawing.Point(4, 22);
            this.newLoanTab.Name = "newLoanTab";
            this.newLoanTab.Padding = new System.Windows.Forms.Padding(3);
            this.newLoanTab.Size = new System.Drawing.Size(223, 143);
            this.newLoanTab.TabIndex = 0;
            this.newLoanTab.Text = "New Loan";
            this.newLoanTab.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(148, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Loan a book copy to member:";
            // 
            // selectedBookCopyLoan
            // 
            this.selectedBookCopyLoan.Location = new System.Drawing.Point(3, 88);
            this.selectedBookCopyLoan.Name = "selectedBookCopyLoan";
            this.selectedBookCopyLoan.ReadOnly = true;
            this.selectedBookCopyLoan.Size = new System.Drawing.Size(217, 20);
            this.selectedBookCopyLoan.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Selected Copy of Book:";
            // 
            // newLoanBtn
            // 
            this.newLoanBtn.Location = new System.Drawing.Point(48, 114);
            this.newLoanBtn.Name = "newLoanBtn";
            this.newLoanBtn.Size = new System.Drawing.Size(118, 23);
            this.newLoanBtn.TabIndex = 19;
            this.newLoanBtn.Text = "Add New Loan";
            this.newLoanBtn.UseVisualStyleBackColor = true;
            this.newLoanBtn.Click += new System.EventHandler(this.newLoanBtn_Click);
            // 
            // availableMemberComboBox
            // 
            this.availableMemberComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.availableMemberComboBox.FormattingEnabled = true;
            this.availableMemberComboBox.Location = new System.Drawing.Point(3, 48);
            this.availableMemberComboBox.Name = "availableMemberComboBox";
            this.availableMemberComboBox.Size = new System.Drawing.Size(217, 21);
            this.availableMemberComboBox.TabIndex = 18;
            // 
            // editLoanTab
            // 
            this.editLoanTab.Controls.Add(this.loanChangeDateBtn);
            this.editLoanTab.Controls.Add(this.dateTimePicker);
            this.editLoanTab.Controls.Add(this.selectedLoanBox);
            this.editLoanTab.Controls.Add(this.label15);
            this.editLoanTab.Controls.Add(this.loanReturnBookBtn);
            this.editLoanTab.Location = new System.Drawing.Point(4, 22);
            this.editLoanTab.Name = "editLoanTab";
            this.editLoanTab.Padding = new System.Windows.Forms.Padding(3);
            this.editLoanTab.Size = new System.Drawing.Size(223, 143);
            this.editLoanTab.TabIndex = 1;
            this.editLoanTab.Text = "Edit Existing Loan";
            this.editLoanTab.UseVisualStyleBackColor = true;
            // 
            // loanChangeDateBtn
            // 
            this.loanChangeDateBtn.Location = new System.Drawing.Point(62, 114);
            this.loanChangeDateBtn.Name = "loanChangeDateBtn";
            this.loanChangeDateBtn.Size = new System.Drawing.Size(103, 23);
            this.loanChangeDateBtn.TabIndex = 29;
            this.loanChangeDateBtn.Text = "Change Due Date";
            this.loanChangeDateBtn.UseVisualStyleBackColor = true;
            this.loanChangeDateBtn.Click += new System.EventHandler(this.loanChangeDateBtn_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(34, 88);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(162, 20);
            this.dateTimePicker.TabIndex = 28;
            // 
            // selectedLoanBox
            // 
            this.selectedLoanBox.Location = new System.Drawing.Point(34, 33);
            this.selectedLoanBox.Name = "selectedLoanBox";
            this.selectedLoanBox.ReadOnly = true;
            this.selectedLoanBox.Size = new System.Drawing.Size(162, 20);
            this.selectedLoanBox.TabIndex = 27;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(31, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(117, 13);
            this.label15.TabIndex = 26;
            this.label15.Text = "Selected Loaned copy:";
            // 
            // loanReturnBookBtn
            // 
            this.loanReturnBookBtn.Location = new System.Drawing.Point(77, 59);
            this.loanReturnBookBtn.Name = "loanReturnBookBtn";
            this.loanReturnBookBtn.Size = new System.Drawing.Size(75, 23);
            this.loanReturnBookBtn.TabIndex = 0;
            this.loanReturnBookBtn.Text = "Return book";
            this.loanReturnBookBtn.UseVisualStyleBackColor = true;
            this.loanReturnBookBtn.Click += new System.EventHandler(this.loanReturnBookBtn_Click);
            // 
            // loanSortBookBtn
            // 
            this.loanSortBookBtn.Location = new System.Drawing.Point(147, 45);
            this.loanSortBookBtn.Name = "loanSortBookBtn";
            this.loanSortBookBtn.Size = new System.Drawing.Size(83, 21);
            this.loanSortBookBtn.TabIndex = 1;
            this.loanSortBookBtn.Text = "Sort by Book";
            this.loanSortBookBtn.UseVisualStyleBackColor = true;
            this.loanSortBookBtn.Click += new System.EventHandler(this.loanSortBookBtn_Click);
            // 
            // authorMemberTab
            // 
            this.authorMemberTab.Controls.Add(this.tabControl1);
            this.authorMemberTab.Location = new System.Drawing.Point(4, 22);
            this.authorMemberTab.Name = "authorMemberTab";
            this.authorMemberTab.Padding = new System.Windows.Forms.Padding(3);
            this.authorMemberTab.Size = new System.Drawing.Size(237, 344);
            this.authorMemberTab.TabIndex = 1;
            this.authorMemberTab.Text = "Authors and Members";
            this.authorMemberTab.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.newAuthorTab);
            this.tabControl1.Controls.Add(this.newMemberTab);
            this.tabControl1.Location = new System.Drawing.Point(3, 200);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(230, 141);
            this.tabControl1.TabIndex = 26;
            // 
            // newAuthorTab
            // 
            this.newAuthorTab.Controls.Add(this.authorAddBtn);
            this.newAuthorTab.Controls.Add(this.authorAddName);
            this.newAuthorTab.Controls.Add(this.label9);
            this.newAuthorTab.Location = new System.Drawing.Point(4, 22);
            this.newAuthorTab.Name = "newAuthorTab";
            this.newAuthorTab.Padding = new System.Windows.Forms.Padding(3);
            this.newAuthorTab.Size = new System.Drawing.Size(222, 115);
            this.newAuthorTab.TabIndex = 0;
            this.newAuthorTab.Text = "Add Author";
            this.newAuthorTab.UseVisualStyleBackColor = true;
            // 
            // authorAddBtn
            // 
            this.authorAddBtn.Location = new System.Drawing.Point(70, 59);
            this.authorAddBtn.Name = "authorAddBtn";
            this.authorAddBtn.Size = new System.Drawing.Size(100, 23);
            this.authorAddBtn.TabIndex = 17;
            this.authorAddBtn.Text = "Add new author";
            this.authorAddBtn.UseVisualStyleBackColor = true;
            this.authorAddBtn.Click += new System.EventHandler(this.authorAddBtn_Click);
            // 
            // authorAddName
            // 
            this.authorAddName.Location = new System.Drawing.Point(70, 33);
            this.authorAddName.Name = "authorAddName";
            this.authorAddName.Size = new System.Drawing.Size(100, 20);
            this.authorAddName.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Name";
            // 
            // newMemberTab
            // 
            this.newMemberTab.Controls.Add(this.memberAddid);
            this.newMemberTab.Controls.Add(this.label5);
            this.newMemberTab.Controls.Add(this.memberAddBtn);
            this.newMemberTab.Controls.Add(this.label6);
            this.newMemberTab.Controls.Add(this.memberAddName);
            this.newMemberTab.Location = new System.Drawing.Point(4, 22);
            this.newMemberTab.Name = "newMemberTab";
            this.newMemberTab.Padding = new System.Windows.Forms.Padding(3);
            this.newMemberTab.Size = new System.Drawing.Size(222, 115);
            this.newMemberTab.TabIndex = 1;
            this.newMemberTab.Text = "Add Member";
            this.newMemberTab.UseVisualStyleBackColor = true;
            // 
            // memberAddid
            // 
            this.memberAddid.Location = new System.Drawing.Point(79, 55);
            this.memberAddid.Name = "memberAddid";
            this.memberAddid.Size = new System.Drawing.Size(100, 20);
            this.memberAddid.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "ID number";
            // 
            // memberAddBtn
            // 
            this.memberAddBtn.Location = new System.Drawing.Point(79, 81);
            this.memberAddBtn.Name = "memberAddBtn";
            this.memberAddBtn.Size = new System.Drawing.Size(100, 23);
            this.memberAddBtn.TabIndex = 10;
            this.memberAddBtn.Text = "Add new member";
            this.memberAddBtn.UseVisualStyleBackColor = true;
            this.memberAddBtn.Click += new System.EventHandler(this.memberAddBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Name";
            // 
            // memberAddName
            // 
            this.memberAddName.Location = new System.Drawing.Point(79, 29);
            this.memberAddName.Name = "memberAddName";
            this.memberAddName.Size = new System.Drawing.Size(100, 20);
            this.memberAddName.TabIndex = 11;
            // 
            // showAllBooksBtn
            // 
            this.showAllBooksBtn.Location = new System.Drawing.Point(263, 336);
            this.showAllBooksBtn.Name = "showAllBooksBtn";
            this.showAllBooksBtn.Size = new System.Drawing.Size(93, 19);
            this.showAllBooksBtn.TabIndex = 18;
            this.showAllBooksBtn.Text = "Show Books";
            this.showAllBooksBtn.UseVisualStyleBackColor = true;
            this.showAllBooksBtn.Click += new System.EventHandler(this.showAllBooksBtn_Click);
            // 
            // showAllLoansBtn
            // 
            this.showAllLoansBtn.Location = new System.Drawing.Point(362, 336);
            this.showAllLoansBtn.Name = "showAllLoansBtn";
            this.showAllLoansBtn.Size = new System.Drawing.Size(92, 19);
            this.showAllLoansBtn.TabIndex = 0;
            this.showAllLoansBtn.Text = "Show Loans";
            this.showAllLoansBtn.UseVisualStyleBackColor = true;
            this.showAllLoansBtn.Click += new System.EventHandler(this.showAllLoansBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(260, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Items";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(457, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Info";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(457, 115);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Copies";
            // 
            // showAllMembersBtn
            // 
            this.showAllMembersBtn.Location = new System.Drawing.Point(362, 361);
            this.showAllMembersBtn.Name = "showAllMembersBtn";
            this.showAllMembersBtn.Size = new System.Drawing.Size(92, 19);
            this.showAllMembersBtn.TabIndex = 19;
            this.showAllMembersBtn.Text = "Show Members";
            this.showAllMembersBtn.UseVisualStyleBackColor = true;
            this.showAllMembersBtn.Click += new System.EventHandler(this.showAllMembersBtn_Click);
            // 
            // showAllAuthorsBtn
            // 
            this.showAllAuthorsBtn.Location = new System.Drawing.Point(263, 361);
            this.showAllAuthorsBtn.Name = "showAllAuthorsBtn";
            this.showAllAuthorsBtn.Size = new System.Drawing.Size(93, 19);
            this.showAllAuthorsBtn.TabIndex = 20;
            this.showAllAuthorsBtn.Text = "Show Authors";
            this.showAllAuthorsBtn.UseVisualStyleBackColor = true;
            this.showAllAuthorsBtn.Click += new System.EventHandler(this.showAllAuthorsBtn_Click);
            // 
            // idAscRadio
            // 
            this.idAscRadio.AutoSize = true;
            this.idAscRadio.Location = new System.Drawing.Point(460, 337);
            this.idAscRadio.Name = "idAscRadio";
            this.idAscRadio.Size = new System.Drawing.Size(43, 17);
            this.idAscRadio.TabIndex = 21;
            this.idAscRadio.Text = "Id ^";
            this.idAscRadio.UseVisualStyleBackColor = true;
            // 
            // idDescRadio
            // 
            this.idDescRadio.AutoSize = true;
            this.idDescRadio.Checked = true;
            this.idDescRadio.Location = new System.Drawing.Point(460, 362);
            this.idDescRadio.Name = "idDescRadio";
            this.idDescRadio.Size = new System.Drawing.Size(43, 17);
            this.idDescRadio.TabIndex = 22;
            this.idDescRadio.TabStop = true;
            this.idDescRadio.Text = "Id v";
            this.idDescRadio.UseVisualStyleBackColor = true;
            // 
            // nameDescRadio
            // 
            this.nameDescRadio.AutoSize = true;
            this.nameDescRadio.Location = new System.Drawing.Point(551, 362);
            this.nameDescRadio.Name = "nameDescRadio";
            this.nameDescRadio.Size = new System.Drawing.Size(62, 17);
            this.nameDescRadio.TabIndex = 24;
            this.nameDescRadio.Text = "Namn v";
            this.nameDescRadio.UseVisualStyleBackColor = true;
            // 
            // nameAscRadio
            // 
            this.nameAscRadio.AutoSize = true;
            this.nameAscRadio.Location = new System.Drawing.Point(551, 337);
            this.nameAscRadio.Name = "nameAscRadio";
            this.nameAscRadio.Size = new System.Drawing.Size(62, 17);
            this.nameAscRadio.TabIndex = 23;
            this.nameAscRadio.Text = "Namn ^";
            this.nameAscRadio.UseVisualStyleBackColor = true;
            // 
            // overtimeCheckBtn
            // 
            this.overtimeCheckBtn.Location = new System.Drawing.Point(84, 70);
            this.overtimeCheckBtn.Name = "overtimeCheckBtn";
            this.overtimeCheckBtn.Size = new System.Drawing.Size(146, 23);
            this.overtimeCheckBtn.TabIndex = 17;
            this.overtimeCheckBtn.Text = "Check all loans for overtime";
            this.overtimeCheckBtn.UseVisualStyleBackColor = true;
            this.overtimeCheckBtn.Click += new System.EventHandler(this.overtimeCheckBtn_Click);
            // 
            // LibraryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 391);
            this.Controls.Add(this.nameDescRadio);
            this.Controls.Add(this.nameAscRadio);
            this.Controls.Add(this.idDescRadio);
            this.Controls.Add(this.idAscRadio);
            this.Controls.Add(this.showAllMembersBtn);
            this.Controls.Add(this.showAllAuthorsBtn);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.showAllLoansBtn);
            this.Controls.Add(this.showAllBooksBtn);
            this.Controls.Add(this.lbCopies);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.lbItems);
            this.Name = "LibraryForm";
            this.Text = "Library";
            this.tabControl.ResumeLayout(false);
            this.bookTab.ResumeLayout(false);
            this.bookTab.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.addBookTab.ResumeLayout(false);
            this.addBookTab.PerformLayout();
            this.addCopyTab.ResumeLayout(false);
            this.addCopyTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.copyCondition)).EndInit();
            this.editBookTab.ResumeLayout(false);
            this.loanTab.ResumeLayout(false);
            this.loanTab.PerformLayout();
            this.tabControl3.ResumeLayout(false);
            this.newLoanTab.ResumeLayout(false);
            this.newLoanTab.PerformLayout();
            this.editLoanTab.ResumeLayout(false);
            this.editLoanTab.PerformLayout();
            this.authorMemberTab.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.newAuthorTab.ResumeLayout(false);
            this.newAuthorTab.PerformLayout();
            this.newMemberTab.ResumeLayout(false);
            this.newMemberTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbItems;
        private System.Windows.Forms.Button BTNChangeBook;
        private System.Windows.Forms.ListBox lbInfo;
        private System.Windows.Forms.Button newBookBtn;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.TextBox isbnTextBox;
        private System.Windows.Forms.TextBox descTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.ListBox lbCopies;
        private System.Windows.Forms.Button showAllAvailableOfBookBtn;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage bookTab;
        private System.Windows.Forms.TextBox authorNameBox;
        private System.Windows.Forms.Button sortByAuthorBtn;
        private System.Windows.Forms.TabPage loanTab;
        private System.Windows.Forms.TabPage authorMemberTab;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox authorAddName;
        private System.Windows.Forms.Button authorAddBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox memberAddName;
        private System.Windows.Forms.Button memberAddBtn;
        private System.Windows.Forms.TextBox memberAddid;
        private System.Windows.Forms.ComboBox authorNameCombo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button showAllBooksBtn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage newAuthorTab;
        private System.Windows.Forms.TabPage newMemberTab;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage addBookTab;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox bookTitleBox;
        private System.Windows.Forms.Button sortByTitleBtn;
        private System.Windows.Forms.TabPage editBookTab;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button showAllAvailableBooksBtn;
        private System.Windows.Forms.TabPage addCopyTab;
        private System.Windows.Forms.NumericUpDown copyCondition;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button newBookCopyBtn;
        private System.Windows.Forms.TextBox bookCopySelectedBook;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button showAllLoansBtn;
        private System.Windows.Forms.Button loanSortMemberBtn;
        private System.Windows.Forms.TextBox memberNameLoanSort;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage newLoanTab;
        private System.Windows.Forms.ComboBox availableMemberComboBox;
        private System.Windows.Forms.TabPage editLoanTab;
        private System.Windows.Forms.Button loanSortBookBtn;
        private System.Windows.Forms.Button showAllMembersBtn;
        private System.Windows.Forms.Button showAllAuthorsBtn;
        private System.Windows.Forms.RadioButton idAscRadio;
        private System.Windows.Forms.RadioButton idDescRadio;
        private System.Windows.Forms.RadioButton nameDescRadio;
        private System.Windows.Forms.RadioButton nameAscRadio;
        private System.Windows.Forms.TextBox bookTitleLoanSort;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button newLoanBtn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox selectedBookCopyLoan;
        private System.Windows.Forms.TextBox selectedLoanBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button loanReturnBookBtn;
        private System.Windows.Forms.Button loanChangeDateBtn;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button overtimeCheckBtn;
    }
}

