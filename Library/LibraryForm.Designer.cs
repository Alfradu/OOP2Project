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
            this.button1 = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.TextBox();
            this.isbn = new System.Windows.Forms.TextBox();
            this.desc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.removeBtn = new System.Windows.Forms.Button();
            this.lbCopies = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.bookTab = new System.Windows.Forms.TabPage();
            this.authorMemberTab = new System.Windows.Forms.TabPage();
            this.loanTab = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.authorNameBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.memberAddName = new System.Windows.Forms.TextBox();
            this.memberAddBtn = new System.Windows.Forms.Button();
            this.memberAddid = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.authorAddName = new System.Windows.Forms.TextBox();
            this.authorAddBtn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.authorNameCombo = new System.Windows.Forms.ComboBox();
            this.tabControl.SuspendLayout();
            this.bookTab.SuspendLayout();
            this.authorMemberTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbItems
            // 
            this.lbItems.FormattingEnabled = true;
            this.lbItems.Location = new System.Drawing.Point(263, 14);
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(191, 368);
            this.lbItems.TabIndex = 0;
            this.lbItems.SelectedIndexChanged += new System.EventHandler(this.lbItems_SelectedIndexChanged);
            // 
            // BTNChangeBook
            // 
            this.BTNChangeBook.Location = new System.Drawing.Point(67, 126);
            this.BTNChangeBook.Margin = new System.Windows.Forms.Padding(2);
            this.BTNChangeBook.Name = "BTNChangeBook";
            this.BTNChangeBook.Size = new System.Drawing.Size(81, 59);
            this.BTNChangeBook.TabIndex = 1;
            this.BTNChangeBook.Text = "TEST: Change the book title";
            this.BTNChangeBook.UseVisualStyleBackColor = true;
            this.BTNChangeBook.Click += new System.EventHandler(this.BTNChangeBook_Click);
            // 
            // lbInfo
            // 
            this.lbInfo.FormattingEnabled = true;
            this.lbInfo.Location = new System.Drawing.Point(460, 12);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(264, 95);
            this.lbInfo.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(130, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add new book";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // title
            // 
            this.title.Location = new System.Drawing.Point(130, 210);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(100, 20);
            this.title.TabIndex = 4;
            // 
            // isbn
            // 
            this.isbn.Location = new System.Drawing.Point(130, 236);
            this.isbn.Name = "isbn";
            this.isbn.Size = new System.Drawing.Size(100, 20);
            this.isbn.TabIndex = 5;
            // 
            // desc
            // 
            this.desc.Location = new System.Drawing.Point(130, 262);
            this.desc.Name = "desc";
            this.desc.Size = new System.Drawing.Size(100, 20);
            this.desc.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "ISBN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Description";
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(153, 126);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(77, 58);
            this.removeBtn.TabIndex = 10;
            this.removeBtn.Text = "TEST: Remove book";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // lbCopies
            // 
            this.lbCopies.FormattingEnabled = true;
            this.lbCopies.Location = new System.Drawing.Point(460, 115);
            this.lbCopies.Name = "lbCopies";
            this.lbCopies.Size = new System.Drawing.Size(264, 264);
            this.lbCopies.TabIndex = 11;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(141, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 59);
            this.button2.TabIndex = 12;
            this.button2.Text = "TEST: Add new copy of selected book";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(155, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 49);
            this.button3.TabIndex = 13;
            this.button3.Text = "Show all available books";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.bookTab);
            this.tabControl.Controls.Add(this.loanTab);
            this.tabControl.Controls.Add(this.authorMemberTab);
            this.tabControl.Location = new System.Drawing.Point(13, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(244, 370);
            this.tabControl.TabIndex = 14;
            // 
            // bookTab
            // 
            this.bookTab.Controls.Add(this.authorNameCombo);
            this.bookTab.Controls.Add(this.label4);
            this.bookTab.Controls.Add(this.authorNameBox);
            this.bookTab.Controls.Add(this.button4);
            this.bookTab.Controls.Add(this.button3);
            this.bookTab.Controls.Add(this.button2);
            this.bookTab.Controls.Add(this.label3);
            this.bookTab.Controls.Add(this.removeBtn);
            this.bookTab.Controls.Add(this.label2);
            this.bookTab.Controls.Add(this.BTNChangeBook);
            this.bookTab.Controls.Add(this.label1);
            this.bookTab.Controls.Add(this.title);
            this.bookTab.Controls.Add(this.desc);
            this.bookTab.Controls.Add(this.button1);
            this.bookTab.Controls.Add(this.isbn);
            this.bookTab.Location = new System.Drawing.Point(4, 22);
            this.bookTab.Name = "bookTab";
            this.bookTab.Padding = new System.Windows.Forms.Padding(3);
            this.bookTab.Size = new System.Drawing.Size(236, 344);
            this.bookTab.TabIndex = 0;
            this.bookTab.Text = "Books";
            this.bookTab.UseVisualStyleBackColor = true;
            // 
            // authorMemberTab
            // 
            this.authorMemberTab.Controls.Add(this.label11);
            this.authorMemberTab.Controls.Add(this.label10);
            this.authorMemberTab.Controls.Add(this.label9);
            this.authorMemberTab.Controls.Add(this.authorAddName);
            this.authorMemberTab.Controls.Add(this.authorAddBtn);
            this.authorMemberTab.Controls.Add(this.label5);
            this.authorMemberTab.Controls.Add(this.label6);
            this.authorMemberTab.Controls.Add(this.memberAddName);
            this.authorMemberTab.Controls.Add(this.memberAddBtn);
            this.authorMemberTab.Controls.Add(this.memberAddid);
            this.authorMemberTab.Location = new System.Drawing.Point(4, 22);
            this.authorMemberTab.Name = "authorMemberTab";
            this.authorMemberTab.Padding = new System.Windows.Forms.Padding(3);
            this.authorMemberTab.Size = new System.Drawing.Size(236, 344);
            this.authorMemberTab.TabIndex = 1;
            this.authorMemberTab.Text = "Authors and Members";
            this.authorMemberTab.UseVisualStyleBackColor = true;
            // 
            // loanTab
            // 
            this.loanTab.Location = new System.Drawing.Point(4, 22);
            this.loanTab.Name = "loanTab";
            this.loanTab.Size = new System.Drawing.Size(236, 344);
            this.loanTab.TabIndex = 2;
            this.loanTab.Text = "Loans";
            this.loanTab.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 43);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(123, 30);
            this.button4.TabIndex = 14;
            this.button4.Text = "Sorty by author";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // authorNameBox
            // 
            this.authorNameBox.Location = new System.Drawing.Point(7, 17);
            this.authorNameBox.Name = "authorNameBox";
            this.authorNameBox.Size = new System.Drawing.Size(117, 20);
            this.authorNameBox.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(68, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "ID number";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(79, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Name";
            // 
            // memberAddName
            // 
            this.memberAddName.Location = new System.Drawing.Point(130, 53);
            this.memberAddName.Name = "memberAddName";
            this.memberAddName.Size = new System.Drawing.Size(100, 20);
            this.memberAddName.TabIndex = 11;
            // 
            // memberAddBtn
            // 
            this.memberAddBtn.Location = new System.Drawing.Point(130, 105);
            this.memberAddBtn.Name = "memberAddBtn";
            this.memberAddBtn.Size = new System.Drawing.Size(100, 23);
            this.memberAddBtn.TabIndex = 10;
            this.memberAddBtn.Text = "Add new member";
            this.memberAddBtn.UseVisualStyleBackColor = true;
            this.memberAddBtn.Click += new System.EventHandler(this.memberAddBtn_Click);
            // 
            // memberAddid
            // 
            this.memberAddid.Location = new System.Drawing.Point(130, 79);
            this.memberAddid.Name = "memberAddid";
            this.memberAddid.Size = new System.Drawing.Size(100, 20);
            this.memberAddid.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(79, 234);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Name";
            // 
            // authorAddName
            // 
            this.authorAddName.Location = new System.Drawing.Point(130, 233);
            this.authorAddName.Name = "authorAddName";
            this.authorAddName.Size = new System.Drawing.Size(100, 20);
            this.authorAddName.TabIndex = 18;
            // 
            // authorAddBtn
            // 
            this.authorAddBtn.Location = new System.Drawing.Point(130, 259);
            this.authorAddBtn.Name = "authorAddBtn";
            this.authorAddBtn.Size = new System.Drawing.Size(100, 23);
            this.authorAddBtn.TabIndex = 17;
            this.authorAddBtn.Text = "Add new author";
            this.authorAddBtn.UseVisualStyleBackColor = true;
            this.authorAddBtn.Click += new System.EventHandler(this.authorAddBtn_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(151, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Member";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(151, 217);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Author";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Author";
            // 
            // authorNameCombo
            // 
            this.authorNameCombo.FormattingEnabled = true;
            this.authorNameCombo.Location = new System.Drawing.Point(130, 288);
            this.authorNameCombo.Name = "authorNameCombo";
            this.authorNameCombo.Size = new System.Drawing.Size(100, 21);
            this.authorNameCombo.TabIndex = 17;
            // 
            // LibraryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 391);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.lbCopies);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.lbItems);
            this.Name = "LibraryForm";
            this.Text = "Library";
            this.tabControl.ResumeLayout(false);
            this.bookTab.ResumeLayout(false);
            this.bookTab.PerformLayout();
            this.authorMemberTab.ResumeLayout(false);
            this.authorMemberTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbItems;
        private System.Windows.Forms.Button BTNChangeBook;
        private System.Windows.Forms.ListBox lbInfo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox title;
        private System.Windows.Forms.TextBox isbn;
        private System.Windows.Forms.TextBox desc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.ListBox lbCopies;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage bookTab;
        private System.Windows.Forms.TextBox authorNameBox;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TabPage loanTab;
        private System.Windows.Forms.TabPage authorMemberTab;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
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
    }
}

