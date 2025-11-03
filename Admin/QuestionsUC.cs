using Quizfy_LKS.Admin.Modals;
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
    public partial class QuestionsUC : UserControl
    {
        public QuestionsUC()
        {
            InitializeComponent();
        }

        private void LoadSubject()
        {
            using (var _db = new DataClasses1DataContext())
            {
                var subjects = from s in _db.Subjects
                               select new { s.ID, s.Name };

                SubjectCB.DataSource = subjects;
                SubjectCB.ValueMember = "ID";
                SubjectCB.DisplayMember = "Name";
            }
        }

        private void LoadQuestions(int subjectId)
        {
            using (var _db = new DataClasses1DataContext())
            {
                var questions = from q in _db.Questions
                                join s in _db.Subjects on q.SubjectID equals s.ID
                                where s.ID == subjectId
                                select new
                                {
                                    q.ID,
                                    SubjectName = s.Name,
                                    q.Question1,
                                    q.OptionA,
                                    q.OptionB,
                                    q.OptionC,
                                    q.OptionD,
                                    q.CorrectAnswer
                                };

                StudentQuestionView.DataSource = questions;
                StudentQuestionView.Columns["ID"].Visible = false;
                StudentQuestionView.Columns["SubjectName"].Visible = false;
                StudentQuestionView.Columns["Question1"].HeaderText = "Question";

                if (StudentQuestionView.Columns["Edit"] == null)
                {
                    // === Kolom EDIT ===
                    DataGridViewImageColumn editColumn = new DataGridViewImageColumn
                    {
                        Name = "Edit",
                        HeaderText = "Edit",
                        Image = Properties.Resources.edit_icon,
                        ImageLayout = DataGridViewImageCellLayout.Zoom,
                        Width = 20
                    };
                    StudentQuestionView.Columns.Add(editColumn);
                }

                if (StudentQuestionView.Columns["Delete"] == null)
                {
                    // === Kolom DELETE ===
                    DataGridViewImageColumn deleteColumn = new DataGridViewImageColumn
                    {
                        Name = "Delete",
                        HeaderText = "Delete",
                        Image = Properties.Resources.trash,
                        ImageLayout = DataGridViewImageCellLayout.Zoom,
                        Width = 20
                    };
                    StudentQuestionView.Columns.Add(deleteColumn);
                }
            }
        }

        private void QuestionsUC_Load(object sender, EventArgs e)
        {
            LoadSubject();

            int subjectId = (int)SubjectCB.SelectedValue;
            LoadQuestions(subjectId);
        }

        private void SearchIcon_Click(object sender, EventArgs e)
        {
            int subjectId = (int)SubjectCB.SelectedValue;
            LoadQuestions(subjectId);
        }

        private void AddQuestion_Click(object sender, EventArgs e)
        {

        }

        private void StudentQuestionView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columnName = StudentQuestionView.Columns[e.ColumnIndex].Name;

            int questionId = Convert.ToInt32(StudentQuestionView.Rows[e.RowIndex].Cells["ID"].Value);

            if (columnName == "Edit")
            {
                (new EditQuestionForm(questionId)).Show();
            }
            else if (columnName == "Delete")
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this question?",
                                      "Confirm Delete",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Warning);
            }
        }
    }
}
