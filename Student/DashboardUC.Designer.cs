namespace Quizfy_LKS.Student
{
    partial class DashboardUC
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
            this.LabelTime = new System.Windows.Forms.Label();
            this.LabelDate = new System.Windows.Forms.Label();
            this.GreetLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FlowSubjectContainer
            // 
            this.FlowSubjectContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FlowSubjectContainer.Location = new System.Drawing.Point(18, 83);
            this.FlowSubjectContainer.Name = "FlowSubjectContainer";
            this.FlowSubjectContainer.Size = new System.Drawing.Size(592, 348);
            this.FlowSubjectContainer.TabIndex = 12;
            // 
            // LabelTime
            // 
            this.LabelTime.AutoSize = true;
            this.LabelTime.Location = new System.Drawing.Point(87, 40);
            this.LabelTime.Name = "LabelTime";
            this.LabelTime.Size = new System.Drawing.Size(49, 13);
            this.LabelTime.TabIndex = 11;
            this.LabelTime.Text = "12:00:01";
            // 
            // LabelDate
            // 
            this.LabelDate.AutoSize = true;
            this.LabelDate.Location = new System.Drawing.Point(18, 40);
            this.LabelDate.Name = "LabelDate";
            this.LabelDate.Size = new System.Drawing.Size(65, 13);
            this.LabelDate.TabIndex = 10;
            this.LabelDate.Text = "01/11/2025";
            // 
            // GreetLabel
            // 
            this.GreetLabel.AutoSize = true;
            this.GreetLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GreetLabel.Location = new System.Drawing.Point(13, 11);
            this.GreetLabel.Name = "GreetLabel";
            this.GreetLabel.Size = new System.Drawing.Size(157, 25);
            this.GreetLabel.TabIndex = 9;
            this.GreetLabel.Text = "[Welcome, User]";
            // 
            // DashboardUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.FlowSubjectContainer);
            this.Controls.Add(this.LabelTime);
            this.Controls.Add(this.LabelDate);
            this.Controls.Add(this.GreetLabel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "DashboardUC";
            this.Size = new System.Drawing.Size(632, 450);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel FlowSubjectContainer;
        private System.Windows.Forms.Label LabelTime;
        private System.Windows.Forms.Label LabelDate;
        private System.Windows.Forms.Label GreetLabel;
    }
}
