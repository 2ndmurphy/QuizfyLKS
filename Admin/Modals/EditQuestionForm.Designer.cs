namespace Quizfy_LKS.Admin.Modals
{
    partial class EditQuestionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditQuestionForm));
            this.label1 = new System.Windows.Forms.Label();
            this.QuestionBox = new System.Windows.Forms.TextBox();
            this.QuestionImage = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ImageOption = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CancelUpdate = new System.Windows.Forms.Button();
            this.SaveQuestion = new System.Windows.Forms.Button();
            this.OptionA = new System.Windows.Forms.RadioButton();
            this.AnswerA = new System.Windows.Forms.TextBox();
            this.AnswerB = new System.Windows.Forms.TextBox();
            this.OptionB = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.AnswerC = new System.Windows.Forms.TextBox();
            this.OptionC = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.AnswerD = new System.Windows.Forms.TextBox();
            this.OptionD = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.QuestionImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Question";
            // 
            // QuestionBox
            // 
            this.QuestionBox.Location = new System.Drawing.Point(16, 30);
            this.QuestionBox.Multiline = true;
            this.QuestionBox.Name = "QuestionBox";
            this.QuestionBox.Size = new System.Drawing.Size(315, 64);
            this.QuestionBox.TabIndex = 1;
            // 
            // QuestionImage
            // 
            this.QuestionImage.Location = new System.Drawing.Point(16, 112);
            this.QuestionImage.Name = "QuestionImage";
            this.QuestionImage.Size = new System.Drawing.Size(113, 112);
            this.QuestionImage.TabIndex = 2;
            this.QuestionImage.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Options";
            // 
            // ImageOption
            // 
            this.ImageOption.AutoSize = true;
            this.ImageOption.Location = new System.Drawing.Point(63, 239);
            this.ImageOption.Name = "ImageOption";
            this.ImageOption.Size = new System.Drawing.Size(55, 17);
            this.ImageOption.TabIndex = 4;
            this.ImageOption.Text = "Image";
            this.ImageOption.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "A.";
            // 
            // CancelUpdate
            // 
            this.CancelUpdate.BackColor = System.Drawing.Color.LightSlateGray;
            this.CancelUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CancelUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelUpdate.ForeColor = System.Drawing.Color.White;
            this.CancelUpdate.Location = new System.Drawing.Point(12, 399);
            this.CancelUpdate.Name = "CancelUpdate";
            this.CancelUpdate.Size = new System.Drawing.Size(94, 23);
            this.CancelUpdate.TabIndex = 9;
            this.CancelUpdate.Text = "cancel";
            this.CancelUpdate.UseVisualStyleBackColor = false;
            this.CancelUpdate.Click += new System.EventHandler(this.CancelUpdate_Click);
            // 
            // SaveQuestion
            // 
            this.SaveQuestion.BackColor = System.Drawing.Color.LimeGreen;
            this.SaveQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SaveQuestion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveQuestion.ForeColor = System.Drawing.Color.White;
            this.SaveQuestion.Location = new System.Drawing.Point(237, 399);
            this.SaveQuestion.Name = "SaveQuestion";
            this.SaveQuestion.Size = new System.Drawing.Size(94, 23);
            this.SaveQuestion.TabIndex = 10;
            this.SaveQuestion.Text = "save";
            this.SaveQuestion.UseVisualStyleBackColor = false;
            // 
            // OptionA
            // 
            this.OptionA.AutoSize = true;
            this.OptionA.Location = new System.Drawing.Point(35, 267);
            this.OptionA.Name = "OptionA";
            this.OptionA.Size = new System.Drawing.Size(14, 13);
            this.OptionA.TabIndex = 11;
            this.OptionA.TabStop = true;
            this.OptionA.UseVisualStyleBackColor = true;
            // 
            // AnswerA
            // 
            this.AnswerA.Location = new System.Drawing.Point(55, 264);
            this.AnswerA.Name = "AnswerA";
            this.AnswerA.Size = new System.Drawing.Size(162, 20);
            this.AnswerA.TabIndex = 15;
            // 
            // AnswerB
            // 
            this.AnswerB.Location = new System.Drawing.Point(55, 290);
            this.AnswerB.Name = "AnswerB";
            this.AnswerB.Size = new System.Drawing.Size(162, 20);
            this.AnswerB.TabIndex = 19;
            // 
            // OptionB
            // 
            this.OptionB.AutoSize = true;
            this.OptionB.Location = new System.Drawing.Point(35, 293);
            this.OptionB.Name = "OptionB";
            this.OptionB.Size = new System.Drawing.Size(14, 13);
            this.OptionB.TabIndex = 18;
            this.OptionB.TabStop = true;
            this.OptionB.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 293);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "B.";
            // 
            // AnswerC
            // 
            this.AnswerC.Location = new System.Drawing.Point(55, 316);
            this.AnswerC.Name = "AnswerC";
            this.AnswerC.Size = new System.Drawing.Size(162, 20);
            this.AnswerC.TabIndex = 22;
            // 
            // OptionC
            // 
            this.OptionC.AutoSize = true;
            this.OptionC.Location = new System.Drawing.Point(35, 319);
            this.OptionC.Name = "OptionC";
            this.OptionC.Size = new System.Drawing.Size(14, 13);
            this.OptionC.TabIndex = 21;
            this.OptionC.TabStop = true;
            this.OptionC.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 319);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "C.";
            // 
            // AnswerD
            // 
            this.AnswerD.Location = new System.Drawing.Point(55, 342);
            this.AnswerD.Name = "AnswerD";
            this.AnswerD.Size = new System.Drawing.Size(162, 20);
            this.AnswerD.TabIndex = 25;
            // 
            // OptionD
            // 
            this.OptionD.AutoSize = true;
            this.OptionD.Location = new System.Drawing.Point(35, 345);
            this.OptionD.Name = "OptionD";
            this.OptionD.Size = new System.Drawing.Size(14, 13);
            this.OptionD.TabIndex = 24;
            this.OptionD.TabStop = true;
            this.OptionD.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 345);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "D.";
            // 
            // EditQuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 434);
            this.Controls.Add(this.AnswerD);
            this.Controls.Add(this.OptionD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AnswerC);
            this.Controls.Add(this.OptionC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.AnswerB);
            this.Controls.Add(this.OptionB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.AnswerA);
            this.Controls.Add(this.OptionA);
            this.Controls.Add(this.SaveQuestion);
            this.Controls.Add(this.CancelUpdate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ImageOption);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.QuestionImage);
            this.Controls.Add(this.QuestionBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditQuestionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quizify | Edit Question";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditQuestionForm_FormClosing);
            this.Load += new System.EventHandler(this.EditQuestionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QuestionImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox QuestionBox;
        private System.Windows.Forms.PictureBox QuestionImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ImageOption;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CancelUpdate;
        private System.Windows.Forms.Button SaveQuestion;
        private System.Windows.Forms.RadioButton OptionA;
        private System.Windows.Forms.TextBox AnswerA;
        private System.Windows.Forms.TextBox AnswerB;
        private System.Windows.Forms.RadioButton OptionB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox AnswerC;
        private System.Windows.Forms.RadioButton OptionC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox AnswerD;
        private System.Windows.Forms.RadioButton OptionD;
        private System.Windows.Forms.Label label5;
    }
}