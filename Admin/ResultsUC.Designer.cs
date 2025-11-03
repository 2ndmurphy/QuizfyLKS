namespace Quizfy_LKS.Admin
{
    partial class ResultsUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultsUC));
            this.StudentQuestionView = new System.Windows.Forms.DataGridView();
            this.SubjectCB = new System.Windows.Forms.ComboBox();
            this.SearchIcon = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CalendarIcon = new System.Windows.Forms.PictureBox();
            this.ParticipantDate = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.StudentQuestionView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalendarIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // StudentQuestionView
            // 
            this.StudentQuestionView.AllowUserToAddRows = false;
            this.StudentQuestionView.AllowUserToDeleteRows = false;
            this.StudentQuestionView.AllowUserToResizeColumns = false;
            this.StudentQuestionView.AllowUserToResizeRows = false;
            this.StudentQuestionView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.StudentQuestionView.BackgroundColor = System.Drawing.Color.White;
            this.StudentQuestionView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentQuestionView.Location = new System.Drawing.Point(11, 88);
            this.StudentQuestionView.Name = "StudentQuestionView";
            this.StudentQuestionView.Size = new System.Drawing.Size(610, 353);
            this.StudentQuestionView.TabIndex = 9;
            // 
            // SubjectCB
            // 
            this.SubjectCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SubjectCB.FormattingEnabled = true;
            this.SubjectCB.Location = new System.Drawing.Point(43, 59);
            this.SubjectCB.Name = "SubjectCB";
            this.SubjectCB.Size = new System.Drawing.Size(260, 21);
            this.SubjectCB.TabIndex = 7;
            // 
            // SearchIcon
            // 
            this.SearchIcon.Image = ((System.Drawing.Image)(resources.GetObject("SearchIcon.Image")));
            this.SearchIcon.Location = new System.Drawing.Point(11, 56);
            this.SearchIcon.Name = "SearchIcon";
            this.SearchIcon.Size = new System.Drawing.Size(26, 26);
            this.SearchIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SearchIcon.TabIndex = 6;
            this.SearchIcon.TabStop = false;
            this.SearchIcon.Click += new System.EventHandler(this.SearchIcon_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "Student Grade Results";
            // 
            // CalendarIcon
            // 
            this.CalendarIcon.Image = ((System.Drawing.Image)(resources.GetObject("CalendarIcon.Image")));
            this.CalendarIcon.Location = new System.Drawing.Point(328, 56);
            this.CalendarIcon.Name = "CalendarIcon";
            this.CalendarIcon.Size = new System.Drawing.Size(26, 26);
            this.CalendarIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CalendarIcon.TabIndex = 10;
            this.CalendarIcon.TabStop = false;
            // 
            // ParticipantDate
            // 
            this.ParticipantDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ParticipantDate.FormattingEnabled = true;
            this.ParticipantDate.Location = new System.Drawing.Point(360, 59);
            this.ParticipantDate.Name = "ParticipantDate";
            this.ParticipantDate.Size = new System.Drawing.Size(260, 21);
            this.ParticipantDate.TabIndex = 11;
            // 
            // ResultsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ParticipantDate);
            this.Controls.Add(this.CalendarIcon);
            this.Controls.Add(this.StudentQuestionView);
            this.Controls.Add(this.SubjectCB);
            this.Controls.Add(this.SearchIcon);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ResultsUC";
            this.Size = new System.Drawing.Size(632, 450);
            this.Load += new System.EventHandler(this.ResultsUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StudentQuestionView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalendarIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView StudentQuestionView;
        private System.Windows.Forms.ComboBox SubjectCB;
        private System.Windows.Forms.PictureBox SearchIcon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox CalendarIcon;
        private System.Windows.Forms.ComboBox ParticipantDate;
    }
}
