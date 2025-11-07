namespace Quizfy_LKS.Student
{
    partial class QuizSessionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuizSessionForm));
            this.PanelTopBar = new System.Windows.Forms.Panel();
            this.SubjectLabel = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.PanelBottomBar = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.QuestionContainer = new System.Windows.Forms.Panel();
            this.NextBtn = new System.Windows.Forms.Button();
            this.QuestionIndex = new System.Windows.Forms.Label();
            this.QuestionLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CorrectAnsCont = new System.Windows.Forms.FlowLayoutPanel();
            this.PanelTopBar.SuspendLayout();
            this.PanelBottomBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.QuestionContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelTopBar
            // 
            this.PanelTopBar.BackColor = System.Drawing.Color.Gainsboro;
            this.PanelTopBar.Controls.Add(this.TimeLabel);
            this.PanelTopBar.Controls.Add(this.pictureBox1);
            this.PanelTopBar.Controls.Add(this.SubjectLabel);
            this.PanelTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTopBar.Location = new System.Drawing.Point(0, 0);
            this.PanelTopBar.Margin = new System.Windows.Forms.Padding(0);
            this.PanelTopBar.Name = "PanelTopBar";
            this.PanelTopBar.Size = new System.Drawing.Size(612, 61);
            this.PanelTopBar.TabIndex = 0;
            // 
            // SubjectLabel
            // 
            this.SubjectLabel.AutoSize = true;
            this.SubjectLabel.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubjectLabel.Location = new System.Drawing.Point(7, 15);
            this.SubjectLabel.Name = "SubjectLabel";
            this.SubjectLabel.Size = new System.Drawing.Size(160, 30);
            this.SubjectLabel.TabIndex = 0;
            this.SubjectLabel.Text = "[Subject Name]";
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLabel.Location = new System.Drawing.Point(459, 17);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(95, 30);
            this.TimeLabel.TabIndex = 2;
            this.TimeLabel.Text = "00:00:00";
            // 
            // PanelBottomBar
            // 
            this.PanelBottomBar.BackColor = System.Drawing.Color.Gainsboro;
            this.PanelBottomBar.Controls.Add(this.NextBtn);
            this.PanelBottomBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelBottomBar.Location = new System.Drawing.Point(0, 404);
            this.PanelBottomBar.Margin = new System.Windows.Forms.Padding(0);
            this.PanelBottomBar.Name = "PanelBottomBar";
            this.PanelBottomBar.Size = new System.Drawing.Size(612, 46);
            this.PanelBottomBar.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(560, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // QuestionContainer
            // 
            this.QuestionContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QuestionContainer.BackColor = System.Drawing.Color.White;
            this.QuestionContainer.Controls.Add(this.CorrectAnsCont);
            this.QuestionContainer.Controls.Add(this.label1);
            this.QuestionContainer.Controls.Add(this.pictureBox2);
            this.QuestionContainer.Controls.Add(this.QuestionLabel);
            this.QuestionContainer.Controls.Add(this.QuestionIndex);
            this.QuestionContainer.Location = new System.Drawing.Point(12, 73);
            this.QuestionContainer.Name = "QuestionContainer";
            this.QuestionContainer.Size = new System.Drawing.Size(588, 317);
            this.QuestionContainer.TabIndex = 3;
            // 
            // NextBtn
            // 
            this.NextBtn.BackColor = System.Drawing.Color.LimeGreen;
            this.NextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextBtn.ForeColor = System.Drawing.Color.Black;
            this.NextBtn.Location = new System.Drawing.Point(495, 11);
            this.NextBtn.Name = "NextBtn";
            this.NextBtn.Size = new System.Drawing.Size(105, 23);
            this.NextBtn.TabIndex = 0;
            this.NextBtn.Text = "Next";
            this.NextBtn.UseVisualStyleBackColor = false;
            // 
            // QuestionIndex
            // 
            this.QuestionIndex.AutoSize = true;
            this.QuestionIndex.Location = new System.Drawing.Point(22, 18);
            this.QuestionIndex.Name = "QuestionIndex";
            this.QuestionIndex.Size = new System.Drawing.Size(65, 13);
            this.QuestionIndex.TabIndex = 0;
            this.QuestionIndex.Text = "Question #1";
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.AutoSize = true;
            this.QuestionLabel.Location = new System.Drawing.Point(22, 49);
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.Size = new System.Drawing.Size(75, 13);
            this.QuestionLabel.TabIndex = 1;
            this.QuestionLabel.Text = "Questions...??";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(37, 65);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(103, 99);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Choose the correct answer..";
            // 
            // CorrectAnsCont
            // 
            this.CorrectAnsCont.Location = new System.Drawing.Point(25, 184);
            this.CorrectAnsCont.Name = "CorrectAnsCont";
            this.CorrectAnsCont.Size = new System.Drawing.Size(536, 122);
            this.CorrectAnsCont.TabIndex = 4;
            // 
            // QuizSessionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 450);
            this.Controls.Add(this.QuestionContainer);
            this.Controls.Add(this.PanelBottomBar);
            this.Controls.Add(this.PanelTopBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuizSessionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "QuestForm";
            this.Text = "Quizify | Quiz Session";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuizSessionForm_FormClosing);
            this.PanelTopBar.ResumeLayout(false);
            this.PanelTopBar.PerformLayout();
            this.PanelBottomBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.QuestionContainer.ResumeLayout(false);
            this.QuestionContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelTopBar;
        private System.Windows.Forms.Label SubjectLabel;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel PanelBottomBar;
        private System.Windows.Forms.Panel QuestionContainer;
        private System.Windows.Forms.Button NextBtn;
        private System.Windows.Forms.Label QuestionIndex;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label QuestionLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel CorrectAnsCont;
    }
}