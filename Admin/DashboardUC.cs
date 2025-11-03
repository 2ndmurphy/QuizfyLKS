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
    public partial class DashboardUC : UserControl
    {
        private readonly int _userId;
        private int selectedRowIndex = -1; // Cek row mana yang diklik

        public DashboardUC(int userId)
        {
            InitializeComponent();
            this._userId = userId;
        }

        private void LoadStudentControl()
        {
            using (var _db = new DataClasses1DataContext())
            {
                var studentControl = _db.Users.Where(u => u.Role == '2').ToList();

                StudentControlView.EnableHeadersVisualStyles = false;
                StudentControlView.AutoGenerateColumns = true;
                StudentControlView.AllowUserToAddRows = false;

                StudentControlView.DataSource = studentControl;
            }
        }

        private void LoadStudentResult()
        {
            using (var _db = new DataClasses1DataContext())
            {
                var studentResult = (from p in _db.Participants
                                     join u in _db.Users on p.UserID equals u.ID
                                     join s in _db.Subjects on p.SubjectID equals s.ID
                                     select new
                                     {
                                         u.FullName,
                                         s.Name,
                                         p.Date,
                                         p.TimeTaken,
                                         Answered = _db.ParticipantAnswers
                                            .Count(a => a.ParticipantID == p.ID && a.Answer != null && a.Answer != ""),
                                         Unanswered = _db.Questions
                                              .Count(q => q.SubjectID == s.ID)
                                              - _db.ParticipantAnswers
                                                   .Count(a => a.ParticipantID == p.ID && a.Answer != null && a.Answer != "")
                                     }).ToList();

                StudentResultView.DataSource = studentResult;
                StudentResultView.Columns["FullName"].HeaderText = "User";
                StudentResultView.Columns["Name"].HeaderText = "Subject";
            }
        }

        private void ApplyRowStyle(DataGridViewRow row)
        {
            // pastikan column IsActive ada dan value nya bool
            var cell = row.Cells["IsActive"];
            if (cell == null)
                return;

            if (cell.Value is bool isActive && !isActive)
            {
                row.DefaultCellStyle.BackColor = Color.Salmon;
                row.DefaultCellStyle.SelectionBackColor = Color.Salmon;
                row.DefaultCellStyle.ForeColor = Color.White;
                row.DefaultCellStyle.SelectionForeColor = Color.White;
            }
            else
            {
                // reset ke default DataGridView style agar tidak meninggalkan sisa style
                row.DefaultCellStyle.BackColor = StudentControlView.RowsDefaultCellStyle.BackColor;
                row.DefaultCellStyle.ForeColor = StudentControlView.RowsDefaultCellStyle.ForeColor;
                row.DefaultCellStyle.SelectionBackColor = StudentControlView.RowsDefaultCellStyle.SelectionBackColor;
                row.DefaultCellStyle.SelectionForeColor = StudentControlView.RowsDefaultCellStyle.SelectionForeColor;
            }
        }

        private void DashboardUC_Load(object sender, EventArgs e)
        {
            LoadStudentControl();
            LoadStudentResult();
        }

        private void StudentControlView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // hide / rename kolom setelah binding
            if (StudentControlView.Columns.Contains("ID"))
                StudentControlView.Columns["ID"].Visible = false;
            if (StudentControlView.Columns.Contains("FullName"))
                StudentControlView.Columns["FullName"].HeaderText = "User";
            if (StudentControlView.Columns.Contains("Role"))
                StudentControlView.Columns["Role"].Visible = false;
            if (StudentControlView.Columns.Contains("Email"))
                StudentControlView.Columns["Email"].Visible = false;
            if (StudentControlView.Columns.Contains("Password"))
                StudentControlView.Columns["Password"].Visible = false;

            // apply style ke tiap baris
            foreach (DataGridViewRow row in StudentControlView.Rows)
            {
                ApplyRowStyle(row);
            }

            StudentControlView.Refresh();
        }

        private void StudentResultView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null || e.RowIndex < 0 || e.Value == null) return;

            string colName = dgv.Columns[e.ColumnIndex].Name;

            // jika mau selalu warnai (Answer = green, Unanswered = salmon)
            if (colName == "Answered")
            {
                e.CellStyle.BackColor = Color.ForestGreen;
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.ForestGreen;
                e.CellStyle.SelectionForeColor = Color.White;
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else if (colName == "Unanswered")
            {
                e.CellStyle.BackColor = Color.Salmon;
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.Salmon;
                e.CellStyle.SelectionForeColor = Color.White;
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void ActivateBtn_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0) return;

            // ambil data user yang dipilih
            var row = StudentControlView.Rows[selectedRowIndex];
            bool currentStatus = Convert.ToBoolean(row.Cells["IsActive"].Value);
            bool newStatus = !currentStatus;

            // Ambil satu nilai untuk clause
            string username = StudentControlView.Rows[selectedRowIndex].Cells["FullName"].Value.ToString();

            try
            {
                using (var _db = new DataClasses1DataContext())
                {
                    var student = _db.Users.SingleOrDefault(u => u.FullName == username);

                    if (student == null)
                    {
                        MessageBox.Show("Student not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    student.IsActive = !student.IsActive;
                    _db.SubmitChanges();

                    row.Cells["IsActive"].Value = student.IsActive;
                    ActivateBtn.Text = student.IsActive ? "InActive" : "IsActive";
                    StudentControlView.Refresh();

                    MessageBox.Show($"Status berhasil diupdate", "Update Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi Kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StudentControlView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ActivateBtn.Enabled = true;

                bool isActive = Convert.ToBoolean(StudentControlView.Rows[e.RowIndex].Cells["IsActive"].Value);

                ActivateBtn.Text = isActive ? "InActive" : "IsActive";

                selectedRowIndex = e.RowIndex;
            }
        }
    }
}
