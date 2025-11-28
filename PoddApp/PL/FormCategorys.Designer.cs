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
            Benämning = new DataGridViewTextBoxColumn();
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
            dgvCategoryList.Columns.AddRange(new DataGridViewColumn[] { colCategoryId, Benämning });
            dgvCategoryList.Location = new Point(25, 29);
            dgvCategoryList.Margin = new Padding(2);
            dgvCategoryList.Name = "dgvCategoryList";
            dgvCategoryList.RowHeadersWidth = 62;
            dgvCategoryList.Size = new Size(278, 362);
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
            // Benämning
            // 
            Benämning.DataPropertyName = "Name";
            Benämning.HeaderText = "Benämning";
            Benämning.MinimumWidth = 6;
            Benämning.Name = "Benämning";
            Benämning.Width = 125;
            // 
            // btnShowAll
            // 
            btnShowAll.Location = new Point(318, 29);
            btnShowAll.Margin = new Padding(2);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(112, 34);
            btnShowAll.TabIndex = 1;
            btnShowAll.Text = "Visa Alla";
            btnShowAll.UseVisualStyleBackColor = true;
            btnShowAll.Click += btnShowAll_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(318, 138);
            btnSearch.Margin = new Padding(2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(112, 34);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "SÖK";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // lblNameSearch
            // 
            lblNameSearch.AutoSize = true;
            lblNameSearch.Location = new Point(308, 72);
            lblNameSearch.Margin = new Padding(2, 0, 2, 0);
            lblNameSearch.Name = "lblNameSearch";
            lblNameSearch.Size = new Size(124, 25);
            lblNameSearch.TabIndex = 3;
            lblNameSearch.Text = "Sök på Namn:";
            // 
            // tbNameSearch
            // 
            tbNameSearch.Location = new Point(308, 101);
            tbNameSearch.Margin = new Padding(2);
            tbNameSearch.Name = "tbNameSearch";
            tbNameSearch.PlaceholderText = "Skriv för att söka...";
            tbNameSearch.Size = new Size(189, 31);
            tbNameSearch.TabIndex = 4;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(318, 218);
            btnAdd.Margin = new Padding(2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(161, 34);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Lägg till Rad";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(318, 258);
            btnDelete.Margin = new Padding(2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(161, 34);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Ta bort Markerad";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Location = new Point(318, 298);
            btnSaveChanges.Margin = new Padding(2);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(161, 34);
            btnSaveChanges.TabIndex = 7;
            btnSaveChanges.Text = "Spara Ändringar";
            btnSaveChanges.UseVisualStyleBackColor = true;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(318, 358);
            btnClose.Margin = new Padding(2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(112, 34);
            btnClose.TabIndex = 8;
            btnClose.Text = "STÄNG";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // FormCategorys
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 420);
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
        private Button btnShowAll;
        private Button btnSearch;
        private Label lblNameSearch;
        private TextBox tbNameSearch;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnSaveChanges;
        private Button btnClose;
        private DataGridViewTextBoxColumn colCategoryId;
        private DataGridViewTextBoxColumn Benämning;
    }
}