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

namespace Quizfy_LKS.Admin
{
    public partial class AdminDashboard : Form
    {
        // Sidebar collapse/expand props
        private bool sidebarExpand = false;
        private readonly Image collapseIcon;
        private readonly Image expandIcon;

        // Active/hover/normal button props
        private Button activeBtn = null;
        private readonly Color normalColor = Color.SteelBlue;
        private readonly Color hoverColor = Color.Gray;
        private readonly Color activeColor = Color.Gray;

        // Active user control page set
        private UserControl activeControl = null;

        public AdminDashboard()
        {
            InitializeComponent();
            collapseIcon = Properties.Resources.left;
            expandIcon = Properties.Resources.right;
        }

        private void SetupSidebarNav()
        {
            // Ambil semua button dalam sidebar yang punya Tag == "nav"
            var navButtons = SidebarContainer.Controls
                                .OfType<Button>()
                                .Where(b => (b.Tag?.ToString() ?? "") == "navBtn")
                                .ToList();

            // fallback: kalau navButtons kosong, pilih berdasarkan nama (sesuaikan nama control)
            if (!navButtons.Any())
            {
                navButtons = new List<Button>();
                // masukkan nama control yang sesuai dengan project lo
                if (this.Controls.Find("GoDashboard", true).FirstOrDefault() is Button db) navButtons.Add(db);
                if (this.Controls.Find("GoQuestions", true).FirstOrDefault() is Button q) navButtons.Add(q);
                if (this.Controls.Find("GoResults", true).FirstOrDefault() is Button r) navButtons.Add(r);
            }

            foreach (var btn in navButtons)
            {
                // styling dasar
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = normalColor;
                btn.ForeColor = Color.White;
                btn.TextAlign = ContentAlignment.MiddleCenter;
                btn.Padding = new Padding(8, 0, 0, 0);

                // event handler
                btn.MouseEnter += (s, e) =>
                {
                    if (btn != activeBtn)
                        btn.BackColor = hoverColor;
                };
                btn.MouseLeave += (s, e) =>
                {
                    if (btn != activeBtn)
                        btn.BackColor = normalColor;
                };

                btn.Click += NavButton_click;
            }

            if (navButtons.Any())
            {
                SetActiveNav(navButtons.First());
            }
        }

        private void SetActiveNav(Button btn)
        {
            if (activeBtn != null && activeBtn != btn)
            {
                // reset normal
                activeBtn.BackColor = normalColor;
            }

            activeBtn = btn;
            activeBtn.BackColor = activeColor;
            activeBtn.ForeColor = Color.White;
        }

        private void LoadUserControl(UserControl uc)
        {
            if (activeControl != null)
            {
                panelContent.Controls.Remove(activeControl);
                activeControl.Dispose();
            }

            activeControl = uc;
            uc.Dock = DockStyle.Fill;
            panelContent.Controls.Add(uc);
            uc.BringToFront();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            SetupSidebarNav();
            LoadUserControl(new DashboardUC(Authentication.UserId));
        }

        private void NavButton_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            // change active
            SetActiveNav(btn);

            switch (btn.Name)
            {
                case "GoDashboard":
                    LoadUserControl(new DashboardUC(Authentication.UserId));
                    return;
                case "GoQuestions":
                    LoadUserControl(new QuestionsUC());
                    return;
                case "GoResults":
                    LoadUserControl(new ResultsUC());
                    return;
            }
        }

        private void TimeControl_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                SidebarContainer.Width -= 10;
                if (SidebarContainer.Width == SidebarContainer.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    TimeControl.Stop();
                    CollapseLeft.Image = expandIcon;
                }
            }
            else
            {
                SidebarContainer.Width += 10;
                if (SidebarContainer.Width == SidebarContainer.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    TimeControl.Stop();
                    CollapseLeft.Image = collapseIcon;
                }
            }
        }

        private void CollapseLeft_Click(object sender, EventArgs e)
        {
            TimeControl.Start();
        }

        private void AdminDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.form.Show();
        }

        private void SignOut_Click(object sender, EventArgs e)
        {
            Authentication.SignOut();
            Close();
        }
    }
}
