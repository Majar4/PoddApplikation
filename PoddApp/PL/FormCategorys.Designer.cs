namespace PL
{
    partial class FormCategorys
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvCategoryList = new DataGridView();
            colCategoryId = new DataGridViewTextBoxColumn();
            colCategoryName = new DataGridViewTextBoxColumn();
            btnShowAll = new Button();
            btnSearch = new Button();
            lblNameSearch = new Label();
            tbNameSearch = new TextBox();
            btnAdd = new Button();
            btnDelete = new Button();
            btnSaveChanges = new Button();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCategoryList).BeginInit();
            SuspendLayout();
            // 
            // dgvCategoryList
            // 
            dgvCategoryList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategoryList.Columns.AddRange(new DataGridViewColumn[] { colCategoryId, colCategoryName });
            dgvCategoryList.Location = new Point(20, 23);
            dgvCategoryList.Margin = new Padding(2);
            dgvCategoryList.Name = "dgvCategoryList";
            dgvCategoryList.RowHeadersWidth = 62;
            dgvCategoryList.Size = new Size(222, 290);
            dgvCategoryList.TabIndex = 0;
            // 
            // colCategoryId
            // 
            colCategoryId.HeaderText = "KategoriID";
            colCategoryId.MinimumWidth = 8;
            colCategoryId.Name = "colCategoryId";
            colCategoryId.Visible = false;
            colCategoryId.Width = 150;
            // 
            // colCategoryName
            // 
            colCategoryName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCategoryName.HeaderText = "Benämning:";
            colCategoryName.MinimumWidth = 8;
            colCategoryName.Name = "colCategoryName";
            // 
            // btnShowAll
            // 
            btnShowAll.Location = new Point(254, 23);
            btnShowAll.Margin = new Padding(2);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(90, 27);
            btnShowAll.TabIndex = 1;
            btnShowAll.Text = "Visa Alla";
            btnShowAll.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(254, 110);
            btnSearch.Margin = new Padding(2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(90, 27);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "SÖK";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // lblNameSearch
            // 
            lblNameSearch.AutoSize = true;
            lblNameSearch.Location = new Point(246, 58);
            lblNameSearch.Margin = new Padding(2, 0, 2, 0);
            lblNameSearch.Name = "lblNameSearch";
            lblNameSearch.Size = new Size(101, 20);
            lblNameSearch.TabIndex = 3;
            lblNameSearch.Text = "Sök på Namn:";
            // 
            // tbNameSearch
            // 
            tbNameSearch.Location = new Point(246, 81);
            tbNameSearch.Margin = new Padding(2);
            tbNameSearch.Name = "tbNameSearch";
            tbNameSearch.PlaceholderText = "Skriv för att söka...";
            tbNameSearch.Size = new Size(152, 27);
            tbNameSearch.TabIndex = 4;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(254, 174);
            btnAdd.Margin = new Padding(2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(129, 27);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Lägg till Rad";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(254, 206);
            btnDelete.Margin = new Padding(2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(129, 27);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Ta bort Markerad";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Location = new Point(254, 238);
            btnSaveChanges.Margin = new Padding(2);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(129, 27);
            btnSaveChanges.TabIndex = 7;
            btnSaveChanges.Text = "Spara Ändringar";
            btnSaveChanges.UseVisualStyleBackColor = true;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(254, 286);
            btnClose.Margin = new Padding(2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(90, 27);
            btnClose.TabIndex = 8;
            btnClose.Text = "STÄNG";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // FormCategorys
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(407, 336);
            Controls.Add(btnClose);
            Controls.Add(btnSaveChanges);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(tbNameSearch);
            Controls.Add(lblNameSearch);
            Controls.Add(btnSearch);
            Controls.Add(btnShowAll);
            Controls.Add(dgvCategoryList);
            Margin = new Padding(2);
            Name = "FormCategorys";
            Text = "PoddKategorier";
            ((System.ComponentModel.ISupportInitialize)dgvCategoryList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCategoryList;
        private DataGridViewTextBoxColumn colCategoryId;
        private DataGridViewTextBoxColumn colCategoryName;
        private Button btnShowAll;
        private Button btnSearch;
        private Label lblNameSearch;
        private TextBox tbNameSearch;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnSaveChanges;
        private Button btnClose;
    }
}