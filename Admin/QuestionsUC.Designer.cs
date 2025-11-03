namespace Quizfy_LKS.Admin
{
    partial class QuestionsUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestionsUC));
            this.label1 = new System.Windows.Forms.Label();
            this.SearchIcon = new System.Windows.Forms.PictureBox();
            this.SubjectCB = new System.Windows.Forms.ComboBox();
            this.AddQuestion = new System.Windows.Forms.Button();
            this.StudentQuestionView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.SearchIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentQuestionView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Management Questions";
            // 
            // SearchIcon
            // 
            this.SearchIcon.Image = ((System.Drawing.Image)(resources.GetObject("SearchIcon.Image")));
            this.SearchIcon.Location = new System.Drawing.Point(11, 54);
            this.SearchIcon.Name = "SearchIcon";
            this.SearchIcon.Size = new System.Drawing.Size(26, 26);
            this.SearchIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SearchIcon.TabIndex = 1;
            this.SearchIcon.TabStop = false;
            this.SearchIcon.Click += new System.EventHandler(this.SearchIcon_Click);
            // 
            // SubjectCB
            // 
            this.SubjectCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SubjectCB.FormattingEnabled = true;
            this.SubjectCB.Location = new System.Drawing.Point(43, 57);
            this.SubjectCB.Name = "SubjectCB";
            this.SubjectCB.Size = new System.Drawing.Size(453, 21);
            this.SubjectCB.TabIndex = 2;
            // 
            // AddQuestion
            // 
            this.AddQuestion.BackColor = System.Drawing.Color.SteelBlue;
            this.AddQuestion.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.AddQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddQuestion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddQuestion.ForeColor = System.Drawing.Color.White;
            this.AddQuestion.Image = ((System.Drawing.Image)(resources.GetObject("AddQuestion.Image")));
            this.AddQuestion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddQuestion.Location = new System.Drawing.Point(504, 54);
            this.AddQuestion.Name = "AddQuestion";
            this.AddQuestion.Size = new System.Drawing.Size(117, 26);
            this.AddQuestion.TabIndex = 3;
            this.AddQuestion.Text = "Add";
            this.AddQuestion.UseVisualStyleBackColor = false;
            this.AddQuestion.Click += new System.EventHandler(this.AddQuestion_Click);
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
            this.StudentQuestionView.Location = new System.Drawing.Point(11, 86);
            this.StudentQuestionView.Name = "StudentQuestionView";
            this.StudentQuestionView.Size = new System.Drawing.Size(610, 353);
            this.StudentQuestionView.TabIndex = 4;
            this.StudentQuestionView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StudentQuestionView_CellContentClick);
            // 
            // QuestionsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.StudentQuestionView);
            this.Controls.Add(this.AddQuestion);
            this.Controls.Add(this.SubjectCB);
            this.Controls.Add(this.SearchIcon);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "QuestionsUC";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(632, 450);
            this.Load += new System.EventHandler(this.QuestionsUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SearchIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentQuestionView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox SearchIcon;
        private System.Windows.Forms.ComboBox SubjectCB;
        private System.Windows.Forms.Button AddQuestion;
        private System.Windows.Forms.DataGridView StudentQuestionView;
    }
}
