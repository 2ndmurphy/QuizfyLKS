using Quizfy_LKS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizfy_LKS.Student
{
    public partial class StudentDashboard : Form
    {
        private bool sidebarExpand = false;
        private readonly Image collapseIcon;
        private readonly Image expandIcon;

        public StudentDashboard()
        {
            InitializeComponent();
            collapseIcon = Properties.Resources.left;
            expandIcon = Properties.Resources.right;

            this.GreetLabel.Text = $"Hey {Authentication.UserName},";
        }

        private void StudentDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.form.Show();
        }

        private void SignOut_Click(object sender, EventArgs e)
        {
            Authentication.SignOut();
            Close();
        }

        private void TimerControl_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                SidebarContainer.Width -= 10;
                if (SidebarContainer.Width == SidebarContainer.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    TimerControl.Stop();
                    CollapseLeft.Image = expandIcon;
                }
            }
            else
            {
                SidebarContainer.Width += 10;
                if (SidebarContainer.Width == SidebarContainer.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    TimerControl.Stop();
                    CollapseLeft.Image = collapseIcon;
                }
            }
        }

        private void CollapseLeft_Click(object sender, EventArgs e)
        {
            TimerControl.Start();
        }
    }
}
