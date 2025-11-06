namespace Quizfy_LKS.Student
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
            this.FlowSubjectContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.GreetLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FlowSubjectContainer
            // 
            this.FlowSubjectContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlowSubjectContainer.AutoScroll = true;
            this.FlowSubjectContainer.Location = new System.Drawing.Point(20, 70);
            this.FlowSubjectContainer.Name = "FlowSubjectContainer";
            this.FlowSubjectContainer.Size = new System.Drawing.Size(597, 365);
            this.FlowSubjectContainer.TabIndex = 16;
            // 
            // GreetLabel
            // 
            this.GreetLabel.AutoSize = true;
            this.GreetLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GreetLabel.Location = new System.Drawing.Point(15, 16);
            this.GreetLabel.Name = "GreetLabel";
            this.GreetLabel.Size = new System.Drawing.Size(100, 25);
            this.GreetLabel.TabIndex = 13;
            this.GreetLabel.Text = "Questions";
            // 
            // QuestionsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.FlowSubjectContainer);
            this.Controls.Add(this.GreetLabel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "QuestionsUC";
            this.Size = new System.Drawing.Size(632, 450);
            this.Load += new System.EventHandler(this.QuestionsUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel FlowSubjectContainer;
        private System.Windows.Forms.Label GreetLabel;
    }
}
