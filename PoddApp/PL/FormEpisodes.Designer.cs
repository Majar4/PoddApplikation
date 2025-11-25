namespace PL
{
    partial class FormEpisodes
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
            lblPodCastName = new Label();
            dgvEpisodeList = new DataGridView();
            colEpisodeName = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            picEpisode = new PictureBox();
            gbEpisodeInfo = new GroupBox();
            tbDescription = new TextBox();
            lblDate = new Label();
            lblTitle = new Label();
            btnShowInfo = new Button();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEpisodeList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picEpisode).BeginInit();
            gbEpisodeInfo.SuspendLayout();
            SuspendLayout();
            // 
            // lblPodCastName
            // 
            lblPodCastName.AutoSize = true;
            lblPodCastName.Location = new Point(44, 25);
            lblPodCastName.Margin = new Padding(2, 0, 2, 0);
            lblPodCastName.Name = "lblPodCastName";
            lblPodCastName.Size = new Size(169, 25);
            lblPodCastName.TabIndex = 0;
            lblPodCastName.Text = "Avsnitt för PodCast:";
            // 
            // dgvEpisodeList
            // 
            dgvEpisodeList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEpisodeList.Columns.AddRange(new DataGridViewColumn[] { colEpisodeName, colDescription, colDate });
            dgvEpisodeList.Location = new Point(31, 66);
            dgvEpisodeList.Margin = new Padding(2, 3, 2, 3);
            dgvEpisodeList.Name = "dgvEpisodeList";
            dgvEpisodeList.RowHeadersWidth = 62;
            dgvEpisodeList.Size = new Size(529, 283);
            dgvEpisodeList.TabIndex = 1;
            // 
            // colEpisodeName
            // 
            colEpisodeName.HeaderText = "Avsnittsnamn:";
            colEpisodeName.MinimumWidth = 8;
            colEpisodeName.Name = "colEpisodeName";
            colEpisodeName.Width = 150;
            // 
            // colDescription
            // 
            colDescription.HeaderText = "Beskrivning:";
            colDescription.MinimumWidth = 8;
            colDescription.Name = "colDescription";
            colDescription.Width = 150;
            // 
            // colDate
            // 
            colDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colDate.HeaderText = "Publiceringsdatum:";
            colDate.MinimumWidth = 8;
            colDate.Name = "colDate";
            colDate.Width = 199;
            // 
            // picEpisode
            // 
            picEpisode.Location = new Point(582, 25);
            picEpisode.Margin = new Padding(2, 3, 2, 3);
            picEpisode.Name = "picEpisode";
            picEpisode.Size = new Size(150, 128);
            picEpisode.SizeMode = PictureBoxSizeMode.Zoom;
            picEpisode.TabIndex = 2;
            picEpisode.TabStop = false;
            // 
            // gbEpisodeInfo
            // 
            gbEpisodeInfo.Controls.Add(tbDescription);
            gbEpisodeInfo.Controls.Add(lblDate);
            gbEpisodeInfo.Controls.Add(lblTitle);
            gbEpisodeInfo.Location = new Point(582, 170);
            gbEpisodeInfo.Margin = new Padding(2, 3, 2, 3);
            gbEpisodeInfo.Name = "gbEpisodeInfo";
            gbEpisodeInfo.Padding = new Padding(2, 3, 2, 3);
            gbEpisodeInfo.Size = new Size(351, 234);
            gbEpisodeInfo.TabIndex = 3;
            gbEpisodeInfo.TabStop = false;
            gbEpisodeInfo.Text = "Information om Avsnitt:";
            // 
            // tbDescription
            // 
            tbDescription.Location = new Point(6, 80);
            tbDescription.Margin = new Padding(2, 3, 2, 3);
            tbDescription.Multiline = true;
            tbDescription.Name = "tbDescription";
            tbDescription.ScrollBars = ScrollBars.Vertical;
            tbDescription.Size = new Size(339, 132);
            tbDescription.TabIndex = 3;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(6, 53);
            lblDate.Margin = new Padding(2, 0, 2, 0);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(70, 25);
            lblDate.TabIndex = 1;
            lblDate.Text = "Datum:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(6, 28);
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(48, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Titel:";
            // 
            // btnShowInfo
            // 
            btnShowInfo.Location = new Point(448, 370);
            btnShowInfo.Margin = new Padding(2, 3, 2, 3);
            btnShowInfo.Name = "btnShowInfo";
            btnShowInfo.Size = new Size(112, 34);
            btnShowInfo.TabIndex = 4;
            btnShowInfo.Text = "Visa mer...";
            btnShowInfo.UseVisualStyleBackColor = true;
            btnShowInfo.Click += btnShowInfo_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(821, 411);
            btnClose.Margin = new Padding(2, 3, 2, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(112, 34);
            btnClose.TabIndex = 5;
            btnClose.Text = "STÄNG";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // FormEpisodes
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(972, 450);
            Controls.Add(btnClose);
            Controls.Add(btnShowInfo);
            Controls.Add(gbEpisodeInfo);
            Controls.Add(picEpisode);
            Controls.Add(dgvEpisodeList);
            Controls.Add(lblPodCastName);
            Margin = new Padding(2, 3, 2, 3);
            Name = "FormEpisodes";
            Text = "PoddAvsnitt";
            ((System.ComponentModel.ISupportInitialize)dgvEpisodeList).EndInit();
            ((System.ComponentModel.ISupportInitialize)picEpisode).EndInit();
            gbEpisodeInfo.ResumeLayout(false);
            gbEpisodeInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPodCastName;
        private DataGridView dgvEpisodeList;
        private PictureBox picEpisode;
        private GroupBox gbEpisodeInfo;
        private Label lblDate;
        private Label lblTitle;
        private TextBox tbDescription;
        private DataGridViewTextBoxColumn colEpisodeName;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colDate;
        private Button btnShowInfo;
        private Button btnClose;
    }
}