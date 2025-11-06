namespace Quizfy_LKS.Student
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
            this.StudentResultView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.StudentResultView)).BeginInit();
            this.SuspendLayout();
            // 
            // StudentResultView
            // 
            this.StudentResultView.AllowUserToAddRows = false;
            this.StudentResultView.AllowUserToDeleteRows = false;
            this.StudentResultView.AllowUserToResizeColumns = false;
            this.StudentResultView.AllowUserToResizeRows = false;
            this.StudentResultView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StudentResultView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.StudentResultView.BackgroundColor = System.Drawing.Color.White;
            this.StudentResultView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentResultView.Location = new System.Drawing.Point(9, 42);
            this.StudentResultView.Name = "StudentResultView";
            this.StudentResultView.RowHeadersVisible = false;
            this.StudentResultView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.StudentResultView.Size = new System.Drawing.Size(610, 353);
            this.StudentResultView.TabIndex = 10;
            this.StudentResultView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.StudentResultView_CellFormatting);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 37);
            this.label1.TabIndex = 11;
            this.label1.Text = "Results";
            // 
            // ResultsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StudentResultView);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ResultsUC";
            this.Size = new System.Drawing.Size(632, 450);
            this.Load += new System.EventHandler(this.ResultsUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StudentResultView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView StudentResultView;
        private System.Windows.Forms.Label label1;
    }
}
