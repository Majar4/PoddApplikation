namespace PL
{
    partial class FormPoddApp
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblUrl = new Label();
            lblName = new Label();
            lblCategory = new Label();
            txtUrl = new TextBox();
            txtName = new TextBox();
            cbCategory = new ComboBox();
            btnSearch = new Button();
            btnSave = new Button();
            picPod = new PictureBox();
            lblPodList = new Label();
            dataGridView1 = new DataGridView();
            colName = new DataGridViewTextBoxColumn();
            colCategory = new DataGridViewComboBoxColumn();
            colPodId = new DataGridViewComboBoxColumn();
            btnCategorys = new Button();
            btnShow = new Button();
            btnRemove = new Button();
            ((System.ComponentModel.ISupportInitialize)picPod).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lblUrl
            // 
            lblUrl.AutoSize = true;
            lblUrl.Location = new Point(23, 25);
            lblUrl.Name = "lblUrl";
            lblUrl.Size = new Size(47, 25);
            lblUrl.TabIndex = 0;
            lblUrl.Text = "URL:";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(23, 328);
            lblName.Name = "lblName";
            lblName.Size = new Size(64, 25);
            lblName.TabIndex = 1;
            lblName.Text = "Namn:";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(23, 364);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(82, 25);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Kategori:";
            // 
            // txtUrl
            // 
            txtUrl.Location = new Point(104, 19);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(150, 31);
            txtUrl.TabIndex = 3;
            // 
            // txtName
            // 
            txtName.Location = new Point(104, 322);
            txtName.Name = "txtName";
            txtName.Size = new Size(150, 31);
            txtName.TabIndex = 4;
            // 
            // cbCategory
            // 
            cbCategory.FormattingEnabled = true;
            cbCategory.Location = new Point(104, 356);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(182, 33);
            cbCategory.TabIndex = 5;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(260, 16);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(112, 34);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "SÖK";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(104, 408);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 7;
            btnSave.Text = "SPARA";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // picPod
            // 
            picPod.Location = new Point(104, 71);
            picPod.Name = "picPod";
            picPod.Size = new Size(268, 224);
            picPod.TabIndex = 8;
            picPod.TabStop = false;
            // 
            // lblPodList
            // 
            lblPodList.AutoSize = true;
            lblPodList.Font = new Font("Segoe UI", 13F);
            lblPodList.Location = new Point(478, 16);
            lblPodList.Name = "lblPodList";
            lblPodList.Size = new Size(283, 36);
            lblPodList.TabIndex = 9;
            lblPodList.Text = "Mina Sparade PodCasts";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colName, colCategory, colPodId });
            dataGridView1.Location = new Point(469, 71);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(363, 318);
            dataGridView1.TabIndex = 10;
            // 
            // colName
            // 
            colName.HeaderText = "Namn";
            colName.MinimumWidth = 8;
            colName.Name = "colName";
            colName.Width = 150;
            // 
            // colCategory
            // 
            colCategory.HeaderText = "Kategori";
            colCategory.MinimumWidth = 8;
            colCategory.Name = "colCategory";
            colCategory.Width = 150;
            // 
            // colPodId
            // 
            colPodId.HeaderText = "PodCastId";
            colPodId.MinimumWidth = 8;
            colPodId.Name = "colPodId";
            colPodId.Visible = false;
            colPodId.Width = 150;
            // 
            // btnCategorys
            // 
            btnCategorys.Location = new Point(307, 322);
            btnCategorys.Name = "btnCategorys";
            btnCategorys.Size = new Size(112, 67);
            btnCategorys.TabIndex = 11;
            btnCategorys.Text = "Hantera Kategorier...";
            btnCategorys.UseVisualStyleBackColor = true;
            btnCategorys.Click += btnCategorys_Click;
            // 
            // btnShow
            // 
            btnShow.Location = new Point(469, 408);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(162, 34);
            btnShow.TabIndex = 12;
            btnShow.Text = "Visa Markerad...";
            btnShow.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(668, 408);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(164, 34);
            btnRemove.TabIndex = 13;
            btnRemove.Text = "Ta Bort Markerad";
            btnRemove.UseVisualStyleBackColor = true;
            // 
            // FormPoddApp
            // 
            ClientSize = new Size(873, 454);
            Controls.Add(btnRemove);
            Controls.Add(btnShow);
            Controls.Add(btnCategorys);
            Controls.Add(dataGridView1);
            Controls.Add(lblPodList);
            Controls.Add(picPod);
            Controls.Add(btnSave);
            Controls.Add(btnSearch);
            Controls.Add(cbCategory);
            Controls.Add(txtName);
            Controls.Add(txtUrl);
            Controls.Add(lblCategory);
            Controls.Add(lblName);
            Controls.Add(lblUrl);
            Name = "FormPoddApp";
            Text = "PoddApp";
            ((System.ComponentModel.ISupportInitialize)picPod).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUrl;
        private Label lblName;
        private Label lblCategory;
        private TextBox txtUrl;
        private TextBox txtName;
        private ComboBox cbCategory;
        private Button btnSearch;
        private Button btnSave;
        private PictureBox picPod;
        private Label lblPodList;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewComboBoxColumn colCategory;
        private DataGridViewComboBoxColumn colPodId;
        private Button btnCategorys;
        private Button btnShow;
        private Button btnRemove;
    }
}
