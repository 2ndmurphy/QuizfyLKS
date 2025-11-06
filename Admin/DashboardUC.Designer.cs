namespace Quizfy_LKS.Admin
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
            this.ActivateBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.StudentResultView = new System.Windows.Forms.DataGridView();
            this.StudentControlView = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.LabelTime = new System.Windows.Forms.Label();
            this.LabelDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.StudentResultView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentControlView)).BeginInit();
            this.SuspendLayout();
            // 
            // ActivateBtn
            // 
            this.ActivateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ActivateBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ActivateBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.ActivateBtn.Enabled = false;
            this.ActivateBtn.FlatAppearance.BorderSize = 2;
            this.ActivateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ActivateBtn.ForeColor = System.Drawing.Color.White;
            this.ActivateBtn.Location = new System.Drawing.Point(505, 234);
            this.ActivateBtn.Name = "ActivateBtn";
            this.ActivateBtn.Size = new System.Drawing.Size(112, 23);
            this.ActivateBtn.TabIndex = 17;
            this.ActivateBtn.Text = "IsActive";
            this.ActivateBtn.UseVisualStyleBackColor = false;
            this.ActivateBtn.Click += new System.EventHandler(this.ActivateBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Student Results";
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
            this.StudentResultView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentResultView.Location = new System.Drawing.Point(14, 274);
            this.StudentResultView.Name = "StudentResultView";
            this.StudentResultView.RowHeadersVisible = false;
            this.StudentResultView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.StudentResultView.Size = new System.Drawing.Size(603, 157);
            this.StudentResultView.TabIndex = 15;
            this.StudentResultView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.StudentResultView_CellFormatting);
            // 
            // StudentControlView
            // 
            this.StudentControlView.AllowUserToAddRows = false;
            this.StudentControlView.AllowUserToDeleteRows = false;
            this.StudentControlView.AllowUserToResizeColumns = false;
            this.StudentControlView.AllowUserToResizeRows = false;
            this.StudentControlView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StudentControlView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.StudentControlView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentControlView.Location = new System.Drawing.Point(14, 96);
            this.StudentControlView.Name = "StudentControlView";
            this.StudentControlView.RowHeadersVisible = false;
            this.StudentControlView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.StudentControlView.Size = new System.Drawing.Size(603, 131);
            this.StudentControlView.TabIndex = 14;
            this.StudentControlView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.StudentControlView_CellClick);
            this.StudentControlView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.StudentControlView_DataBindingComplete);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Student Control";
            // 
            // LabelTime
            // 
            this.LabelTime.AutoSize = true;
            this.LabelTime.Location = new System.Drawing.Point(83, 42);
            this.LabelTime.Name = "LabelTime";
            this.LabelTime.Size = new System.Drawing.Size(49, 13);
            this.LabelTime.TabIndex = 12;
            this.LabelTime.Text = "12:00:01";
            // 
            // LabelDate
            // 
            this.LabelDate.AutoSize = true;
            this.LabelDate.Location = new System.Drawing.Point(14, 42);
            this.LabelDate.Name = "LabelDate";
            this.LabelDate.Size = new System.Drawing.Size(65, 13);
            this.LabelDate.TabIndex = 11;
            this.LabelDate.Text = "01/11/2025";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Dashboard";
            // 
            // DashboardUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ActivateBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StudentResultView);
            this.Controls.Add(this.StudentControlView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LabelTime);
            this.Controls.Add(this.LabelDate);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "DashboardUC";
            this.Size = new System.Drawing.Size(632, 450);
            this.Load += new System.EventHandler(this.DashboardUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StudentResultView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentControlView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ActivateBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView StudentResultView;
        private System.Windows.Forms.DataGridView StudentControlView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LabelTime;
        private System.Windows.Forms.Label LabelDate;
        private System.Windows.Forms.Label label1;
    }
}
