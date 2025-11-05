namespace Quizfy_LKS.Student
{
    partial class StudentDashboard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentDashboard));
            this.SidebarContainer = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.GoResults = new System.Windows.Forms.Button();
            this.CollapseLeft = new System.Windows.Forms.Button();
            this.SignOut = new System.Windows.Forms.Button();
            this.GoDashboard = new System.Windows.Forms.Button();
            this.GoQuestions = new System.Windows.Forms.Button();
            this.TimerControl = new System.Windows.Forms.Timer(this.components);
            this.PanelContainer = new System.Windows.Forms.Panel();
            this.SidebarContainer.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // SidebarContainer
            // 
            this.SidebarContainer.BackColor = System.Drawing.Color.SteelBlue;
            this.SidebarContainer.Controls.Add(this.panel4);
            this.SidebarContainer.Controls.Add(this.panel6);
            this.SidebarContainer.Controls.Add(this.panel5);
            this.SidebarContainer.Controls.Add(this.panel2);
            this.SidebarContainer.Controls.Add(this.panel3);
            this.SidebarContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.SidebarContainer.Location = new System.Drawing.Point(0, 0);
            this.SidebarContainer.MaximumSize = new System.Drawing.Size(168, 450);
            this.SidebarContainer.MinimumSize = new System.Drawing.Size(51, 450);
            this.SidebarContainer.Name = "SidebarContainer";
            this.SidebarContainer.Size = new System.Drawing.Size(168, 450);
            this.SidebarContainer.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SteelBlue;
            this.panel4.Controls.Add(this.GoResults);
            this.panel4.Location = new System.Drawing.Point(0, 242);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(168, 56);
            this.panel4.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.SteelBlue;
            this.panel6.Controls.Add(this.CollapseLeft);
            this.panel6.Location = new System.Drawing.Point(-4, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(58, 56);
            this.panel6.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SteelBlue;
            this.panel5.Controls.Add(this.SignOut);
            this.panel5.Location = new System.Drawing.Point(0, 394);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(168, 56);
            this.panel5.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.GoDashboard);
            this.panel2.Location = new System.Drawing.Point(0, 130);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(168, 56);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Controls.Add(this.GoQuestions);
            this.panel3.Location = new System.Drawing.Point(0, 186);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(168, 56);
            this.panel3.TabIndex = 2;
            // 
            // GoResults
            // 
            this.GoResults.BackColor = System.Drawing.Color.SteelBlue;
            this.GoResults.FlatAppearance.BorderSize = 0;
            this.GoResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GoResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoResults.ForeColor = System.Drawing.Color.White;
            this.GoResults.Image = ((System.Drawing.Image)(resources.GetObject("GoResults.Image")));
            this.GoResults.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GoResults.Location = new System.Drawing.Point(0, 0);
            this.GoResults.Margin = new System.Windows.Forms.Padding(0);
            this.GoResults.Name = "GoResults";
            this.GoResults.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.GoResults.Size = new System.Drawing.Size(168, 56);
            this.GoResults.TabIndex = 2;
            this.GoResults.Tag = "navButton";
            this.GoResults.Text = "Results";
            this.GoResults.UseVisualStyleBackColor = false;
            // 
            // CollapseLeft
            // 
            this.CollapseLeft.BackColor = System.Drawing.Color.SteelBlue;
            this.CollapseLeft.FlatAppearance.BorderSize = 0;
            this.CollapseLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CollapseLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CollapseLeft.ForeColor = System.Drawing.Color.White;
            this.CollapseLeft.Image = ((System.Drawing.Image)(resources.GetObject("CollapseLeft.Image")));
            this.CollapseLeft.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CollapseLeft.Location = new System.Drawing.Point(0, 0);
            this.CollapseLeft.Margin = new System.Windows.Forms.Padding(0);
            this.CollapseLeft.Name = "CollapseLeft";
            this.CollapseLeft.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.CollapseLeft.Size = new System.Drawing.Size(168, 56);
            this.CollapseLeft.TabIndex = 2;
            this.CollapseLeft.UseVisualStyleBackColor = false;
            this.CollapseLeft.Click += new System.EventHandler(this.CollapseLeft_Click_1);
            // 
            // SignOut
            // 
            this.SignOut.BackColor = System.Drawing.Color.SteelBlue;
            this.SignOut.FlatAppearance.BorderSize = 0;
            this.SignOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SignOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignOut.ForeColor = System.Drawing.Color.Red;
            this.SignOut.Image = ((System.Drawing.Image)(resources.GetObject("SignOut.Image")));
            this.SignOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SignOut.Location = new System.Drawing.Point(0, 0);
            this.SignOut.Margin = new System.Windows.Forms.Padding(0);
            this.SignOut.Name = "SignOut";
            this.SignOut.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.SignOut.Size = new System.Drawing.Size(168, 56);
            this.SignOut.TabIndex = 2;
            this.SignOut.Text = "Logout";
            this.SignOut.UseVisualStyleBackColor = false;
            this.SignOut.Click += new System.EventHandler(this.SignOut_Click);
            // 
            // GoDashboard
            // 
            this.GoDashboard.BackColor = System.Drawing.Color.SteelBlue;
            this.GoDashboard.FlatAppearance.BorderSize = 0;
            this.GoDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GoDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoDashboard.ForeColor = System.Drawing.Color.White;
            this.GoDashboard.Image = ((System.Drawing.Image)(resources.GetObject("GoDashboard.Image")));
            this.GoDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GoDashboard.Location = new System.Drawing.Point(0, 0);
            this.GoDashboard.Margin = new System.Windows.Forms.Padding(0);
            this.GoDashboard.Name = "GoDashboard";
            this.GoDashboard.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.GoDashboard.Size = new System.Drawing.Size(168, 56);
            this.GoDashboard.TabIndex = 2;
            this.GoDashboard.Tag = "navButton";
            this.GoDashboard.Text = "Dashboard";
            this.GoDashboard.UseVisualStyleBackColor = false;
            // 
            // GoQuestions
            // 
            this.GoQuestions.BackColor = System.Drawing.Color.SteelBlue;
            this.GoQuestions.FlatAppearance.BorderSize = 0;
            this.GoQuestions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GoQuestions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoQuestions.ForeColor = System.Drawing.Color.White;
            this.GoQuestions.Image = ((System.Drawing.Image)(resources.GetObject("GoQuestions.Image")));
            this.GoQuestions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GoQuestions.Location = new System.Drawing.Point(0, 0);
            this.GoQuestions.Margin = new System.Windows.Forms.Padding(0);
            this.GoQuestions.Name = "GoQuestions";
            this.GoQuestions.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.GoQuestions.Size = new System.Drawing.Size(168, 56);
            this.GoQuestions.TabIndex = 2;
            this.GoQuestions.Tag = "navButton";
            this.GoQuestions.Text = "Questions";
            this.GoQuestions.UseVisualStyleBackColor = false;
            // 
            // TimerControl
            // 
            this.TimerControl.Interval = 10;
            this.TimerControl.Tick += new System.EventHandler(this.TimerControl_Tick_1);
            // 
            // PanelContainer
            // 
            this.PanelContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PanelContainer.BackColor = System.Drawing.Color.White;
            this.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContainer.Location = new System.Drawing.Point(168, 0);
            this.PanelContainer.Margin = new System.Windows.Forms.Padding(0);
            this.PanelContainer.Name = "PanelContainer";
            this.PanelContainer.Size = new System.Drawing.Size(632, 450);
            this.PanelContainer.TabIndex = 4;
            // 
            // StudentDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PanelContainer);
            this.Controls.Add(this.SidebarContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StudentDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quizify | Dashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StudentDashboard_FormClosing);
            this.Load += new System.EventHandler(this.StudentDashboard_Load);
            this.SidebarContainer.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SidebarContainer;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button GoResults;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button CollapseLeft;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button SignOut;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button GoDashboard;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button GoQuestions;
        private System.Windows.Forms.Timer TimerControl;
        private System.Windows.Forms.Panel PanelContainer;
    }
}