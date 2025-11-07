namespace Quizfy_LKS.Student.Components
{
    partial class SubjectCardUC
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
            this.SubjectLabel = new System.Windows.Forms.Label();
            this.StartQuiz = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SubjectTimeLabel = new System.Windows.Forms.Label();
            this.SubjectQuestCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SubjectLabel
            // 
            this.SubjectLabel.AutoSize = true;
            this.SubjectLabel.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubjectLabel.ForeColor = System.Drawing.Color.White;
            this.SubjectLabel.Location = new System.Drawing.Point(12, 10);
            this.SubjectLabel.Name = "SubjectLabel";
            this.SubjectLabel.Size = new System.Drawing.Size(112, 21);
            this.SubjectLabel.TabIndex = 0;
            this.SubjectLabel.Text = "[subject label]";
            // 
            // StartQuiz
            // 
            this.StartQuiz.Location = new System.Drawing.Point(11, 100);
            this.StartQuiz.Name = "StartQuiz";
            this.StartQuiz.Size = new System.Drawing.Size(192, 34);
            this.StartQuiz.TabIndex = 1;
            this.StartQuiz.Text = "Start";
            this.StartQuiz.UseVisualStyleBackColor = true;
            this.StartQuiz.Click += new System.EventHandler(this.StartQuiz_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Time:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(14, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Number of Questions:";
            // 
            // SubjectTimeLabel
            // 
            this.SubjectTimeLabel.AutoSize = true;
            this.SubjectTimeLabel.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubjectTimeLabel.ForeColor = System.Drawing.Color.White;
            this.SubjectTimeLabel.Location = new System.Drawing.Point(49, 54);
            this.SubjectTimeLabel.Name = "SubjectTimeLabel";
            this.SubjectTimeLabel.Size = new System.Drawing.Size(42, 17);
            this.SubjectTimeLabel.TabIndex = 4;
            this.SubjectTimeLabel.Text = "0 min";
            // 
            // SubjectQuestCount
            // 
            this.SubjectQuestCount.AutoSize = true;
            this.SubjectQuestCount.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubjectQuestCount.ForeColor = System.Drawing.Color.White;
            this.SubjectQuestCount.Location = new System.Drawing.Point(152, 75);
            this.SubjectQuestCount.Name = "SubjectQuestCount";
            this.SubjectQuestCount.Size = new System.Drawing.Size(15, 17);
            this.SubjectQuestCount.TabIndex = 5;
            this.SubjectQuestCount.Text = "0";
            // 
            // SubjectCardUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.SubjectQuestCount);
            this.Controls.Add(this.SubjectTimeLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StartQuiz);
            this.Controls.Add(this.SubjectLabel);
            this.Name = "SubjectCardUC";
            this.Size = new System.Drawing.Size(217, 143);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SubjectLabel;
        private System.Windows.Forms.Button StartQuiz;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label SubjectTimeLabel;
        private System.Windows.Forms.Label SubjectQuestCount;
    }
}
