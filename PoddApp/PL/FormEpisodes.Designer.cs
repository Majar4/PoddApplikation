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
            picEpisode = new PictureBox();
            gbEpisodeInfo = new GroupBox();
            lblTitle = new Label();
            lblDate = new Label();
            lblLength = new Label();
            tbDescription = new TextBox();
            colEpisodeName = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
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
            lblPodCastName.Name = "lblPodCastName";
            lblPodCastName.Size = new Size(169, 25);
            lblPodCastName.TabIndex = 0;
            lblPodCastName.Text = "Avsnitt för PodCast:";
            // 
            // dgvEpisodeList
            // 
            dgvEpisodeList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEpisodeList.Columns.AddRange(new DataGridViewColumn[] { colEpisodeName, colDescription, colDate });
            dgvEpisodeList.Location = new Point(31, 77);
            dgvEpisodeList.Name = "dgvEpisodeList";
            dgvEpisodeList.RowHeadersWidth = 62;
            dgvEpisodeList.Size = new Size(529, 283);
            dgvEpisodeList.TabIndex = 1;
            // 
            // picEpisode
            // 
            picEpisode.Location = new Point(582, 25);
            picEpisode.Name = "picEpisode";
            picEpisode.Size = new Size(150, 127);
            picEpisode.TabIndex = 2;
            picEpisode.TabStop = false;
            // 
            // gbEpisodeInfo
            // 
            gbEpisodeInfo.Controls.Add(tbDescription);
            gbEpisodeInfo.Controls.Add(lblLength);
            gbEpisodeInfo.Controls.Add(lblDate);
            gbEpisodeInfo.Controls.Add(lblTitle);
            gbEpisodeInfo.Location = new Point(582, 170);
            gbEpisodeInfo.Name = "gbEpisodeInfo";
            gbEpisodeInfo.Size = new Size(351, 234);
            gbEpisodeInfo.TabIndex = 3;
            gbEpisodeInfo.TabStop = false;
            gbEpisodeInfo.Text = "Information om Avsnitt:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(6, 27);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(48, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Titel:";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(6, 52);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(70, 25);
            lblDate.TabIndex = 1;
            lblDate.Text = "Datum:";
            // 
            // lblLength
            // 
            lblLength.AutoSize = true;
            lblLength.Location = new Point(6, 77);
            lblLength.Name = "lblLength";
            lblLength.Size = new Size(65, 25);
            lblLength.TabIndex = 2;
            lblLength.Text = "Längd:";
            // 
            // tbDescription
            // 
            tbDescription.Location = new Point(6, 110);
            tbDescription.Name = "tbDescription";
            tbDescription.Size = new Size(339, 31);
            tbDescription.TabIndex = 3;
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
            // btnShowInfo
            // 
            btnShowInfo.Location = new Point(448, 370);
            btnShowInfo.Name = "btnShowInfo";
            btnShowInfo.Size = new Size(112, 34);
            btnShowInfo.TabIndex = 4;
            btnShowInfo.Text = "Visa mer...";
            btnShowInfo.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(821, 410);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(112, 34);
            btnClose.TabIndex = 5;
            btnClose.Text = "STÄNG";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // FormEpisodes
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(973, 450);
            Controls.Add(btnClose);
            Controls.Add(btnShowInfo);
            Controls.Add(gbEpisodeInfo);
            Controls.Add(picEpisode);
            Controls.Add(dgvEpisodeList);
            Controls.Add(lblPodCastName);
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
        private Label lblLength;
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