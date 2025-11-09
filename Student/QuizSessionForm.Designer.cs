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
            this.TimeLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SubjectLabel = new System.Windows.Forms.Label();
            this.PanelBottomBar = new System.Windows.Forms.Panel();
            this.PrevBtn = new System.Windows.Forms.Button();
            this.NextBtn = new System.Windows.Forms.Button();
            this.QuestionContainer = new System.Windows.Forms.Panel();
            this.rbA = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.rbB = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.rbC = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.rbD = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.QuestionImg = new System.Windows.Forms.PictureBox();
            this.QuestionLbl = new System.Windows.Forms.Label();
            this.LblQuestionNumber = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.PanelTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PanelBottomBar.SuspendLayout();
            this.QuestionContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuestionImg)).BeginInit();
            this.panel5.SuspendLayout();
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
            // PanelBottomBar
            // 
            this.PanelBottomBar.BackColor = System.Drawing.Color.Gainsboro;
            this.PanelBottomBar.Controls.Add(this.PrevBtn);
            this.PanelBottomBar.Controls.Add(this.NextBtn);
            this.PanelBottomBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelBottomBar.Location = new System.Drawing.Point(0, 404);
            this.PanelBottomBar.Margin = new System.Windows.Forms.Padding(0);
            this.PanelBottomBar.Name = "PanelBottomBar";
            this.PanelBottomBar.Size = new System.Drawing.Size(612, 46);
            this.PanelBottomBar.TabIndex = 2;
            // 
            // PrevBtn
            // 
            this.PrevBtn.BackColor = System.Drawing.Color.DarkGray;
            this.PrevBtn.Enabled = false;
            this.PrevBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrevBtn.ForeColor = System.Drawing.Color.White;
            this.PrevBtn.Location = new System.Drawing.Point(12, 11);
            this.PrevBtn.Name = "PrevBtn";
            this.PrevBtn.Size = new System.Drawing.Size(105, 23);
            this.PrevBtn.TabIndex = 1;
            this.PrevBtn.Text = "Prev";
            this.PrevBtn.UseVisualStyleBackColor = false;
            this.PrevBtn.Click += new System.EventHandler(this.PrevBtn_Click);
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
            this.NextBtn.Click += new System.EventHandler(this.NextBtn_Click);
            // 
            // QuestionContainer
            // 
            this.QuestionContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QuestionContainer.BackColor = System.Drawing.Color.White;
            this.QuestionContainer.Controls.Add(this.panel5);
            this.QuestionContainer.Controls.Add(this.label1);
            this.QuestionContainer.Controls.Add(this.QuestionImg);
            this.QuestionContainer.Controls.Add(this.QuestionLbl);
            this.QuestionContainer.Controls.Add(this.LblQuestionNumber);
            this.QuestionContainer.Location = new System.Drawing.Point(12, 73);
            this.QuestionContainer.Name = "QuestionContainer";
            this.QuestionContainer.Size = new System.Drawing.Size(588, 317);
            this.QuestionContainer.TabIndex = 3;
            // 
            // rbA
            // 
            this.rbA.AutoSize = true;
            this.rbA.Location = new System.Drawing.Point(23, 4);
            this.rbA.Name = "rbA";
            this.rbA.Size = new System.Drawing.Size(85, 17);
            this.rbA.TabIndex = 0;
            this.rbA.TabStop = true;
            this.rbA.Text = "radioButton1";
            this.rbA.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "A.";
            // 
            // rbB
            // 
            this.rbB.AutoSize = true;
            this.rbB.Location = new System.Drawing.Point(23, 22);
            this.rbB.Name = "rbB";
            this.rbB.Size = new System.Drawing.Size(85, 17);
            this.rbB.TabIndex = 0;
            this.rbB.TabStop = true;
            this.rbB.Text = "radioButton2";
            this.rbB.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "B.";
            // 
            // rbC
            // 
            this.rbC.AutoSize = true;
            this.rbC.Location = new System.Drawing.Point(23, 40);
            this.rbC.Name = "rbC";
            this.rbC.Size = new System.Drawing.Size(85, 17);
            this.rbC.TabIndex = 0;
            this.rbC.TabStop = true;
            this.rbC.Text = "radioButton3";
            this.rbC.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "C.";
            // 
            // rbD
            // 
            this.rbD.AutoSize = true;
            this.rbD.Location = new System.Drawing.Point(23, 58);
            this.rbD.Name = "rbD";
            this.rbD.Size = new System.Drawing.Size(85, 17);
            this.rbD.TabIndex = 0;
            this.rbD.TabStop = true;
            this.rbD.Text = "radioButton4";
            this.rbD.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "D.";
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
            // QuestionImg
            // 
            this.QuestionImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.QuestionImg.Location = new System.Drawing.Point(37, 65);
            this.QuestionImg.Name = "QuestionImg";
            this.QuestionImg.Size = new System.Drawing.Size(103, 99);
            this.QuestionImg.TabIndex = 2;
            this.QuestionImg.TabStop = false;
            // 
            // QuestionLbl
            // 
            this.QuestionLbl.AutoSize = true;
            this.QuestionLbl.Location = new System.Drawing.Point(22, 49);
            this.QuestionLbl.Name = "QuestionLbl";
            this.QuestionLbl.Size = new System.Drawing.Size(75, 13);
            this.QuestionLbl.TabIndex = 1;
            this.QuestionLbl.Text = "Questions...??";
            // 
            // LblQuestionNumber
            // 
            this.LblQuestionNumber.AutoSize = true;
            this.LblQuestionNumber.Location = new System.Drawing.Point(22, 18);
            this.LblQuestionNumber.Name = "LblQuestionNumber";
            this.LblQuestionNumber.Size = new System.Drawing.Size(65, 13);
            this.LblQuestionNumber.TabIndex = 0;
            this.LblQuestionNumber.Text = "Question #1";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.rbA);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.rbB);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.rbD);
            this.panel5.Controls.Add(this.rbC);
            this.panel5.Location = new System.Drawing.Point(25, 183);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(536, 122);
            this.panel5.TabIndex = 12;
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
            this.Load += new System.EventHandler(this.QuizSessionForm_Load);
            this.PanelTopBar.ResumeLayout(false);
            this.PanelTopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PanelBottomBar.ResumeLayout(false);
            this.QuestionContainer.ResumeLayout(false);
            this.QuestionContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuestionImg)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
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
        private System.Windows.Forms.Label LblQuestionNumber;
        private System.Windows.Forms.PictureBox QuestionImg;
        private System.Windows.Forms.Label QuestionLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PrevBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbA;
        private System.Windows.Forms.RadioButton rbD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
    }
}