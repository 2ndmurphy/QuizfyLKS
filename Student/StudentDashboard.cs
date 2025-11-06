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

        public StudentDashboard()
        {
            InitializeComponent();
            collapseIcon = Properties.Resources.left;
            expandIcon = Properties.Resources.right;
        }

        #region Close Program

        private void StudentDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.form.Show();
        }

        private void SignOut_Click(object sender, EventArgs e)
        {
            Authentication.SignOut();
            Close();
        }

        #endregion End Close Program

        #region Sidebar

        /// <summary>
        /// Configures the sidebar navigation buttons by applying styles, event handlers, and setting the default active
        /// button.
        /// </summary>
        /// <remarks>This method identifies all buttons within the sidebar container that are tagged with
        /// "navButton" or, as a fallback, locates specific buttons by their control names. It applies consistent
        /// styling to the buttons, including hover effects, and assigns click event handlers. The first button in the
        /// collection is set as the default active button.</remarks>
        private void SetupSidebarNav()
        {
            // Ambil semua button yang ber tag "navButton" di container
            var navButtons = SidebarContainer.Controls
                        .OfType<Button>()
                        .Where(b => (b.Tag?.ToString() ?? "") == "navButton")
                        .ToList();

            // Fallback jika tidak menemukan tag, ambil berdasarkan nama control
            if (!navButtons.Any())
            {
                navButtons = new List<Button>();
                if (this.Controls.Find("GoDashboard", true).FirstOrDefault() is Button db) navButtons.Add(db);
                if (this.Controls.Find("GoQuestions", true).FirstOrDefault() is Button q) navButtons.Add(q);
                if (this.Controls.Find("GoResults", true).FirstOrDefault() is Button r) navButtons.Add(r);
            }

            foreach (Button btn in navButtons)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = normalColor;
                btn.ForeColor = Color.White;
                btn.TextAlign = ContentAlignment.MiddleCenter;
                btn.Padding = new Padding(8, 0, 0, 0);

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

                btn.Click += Btn_Click;
            }

            if (navButtons.Any())
            {
                SetActiveNav(navButtons.First());
            }
        }

        /// <summary>
        /// Set whether active button
        /// </summary>
        /// <param name="btn"></param>
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

        private void Btn_Click(object sender, EventArgs e)
        {
            if (!(sender is Button btn)) return;

            SetActiveNav(btn);

            switch (btn.Name)
            {
                case "GoDashboard":
                    LoadUserControl(new DashboardUC());
                    break;
                case "GoQuestions":
                    LoadUserControl(new QuestionsUC());
                    break;
                case "GoResults":
                    LoadUserControl(new ResultsUC(Authentication.UserId));
                    break;
            }
        }

        private void TimerControl_Tick_1(object sender, EventArgs e)
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

        private void CollapseLeft_Click_1(object sender, EventArgs e)
        {
            TimerControl.Start();
        }

        #endregion End Sidebar

        /// <summary>
        /// Load user control aktif/nonaktif ke panel container
        /// </summary>
        /// <param name="uc"></param>
        private void LoadUserControl(UserControl uc)
        {
            if (activeControl != null)
            {
                PanelContainer.Controls.Remove(activeControl);
                activeControl.Dispose();
            }

            activeControl = uc;
            uc.Dock = DockStyle.Fill;
            PanelContainer.Controls.Add(uc);
            uc.BringToFront();
        }

        private void StudentDashboard_Load(object sender, EventArgs e)
        {
            SetupSidebarNav();
            LoadUserControl(new DashboardUC());
        }
    }
}
