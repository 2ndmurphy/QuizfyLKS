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
    public partial class ResultsUC : UserControl
    {
        private readonly int _userId;

        public ResultsUC(int userId)
        {
            InitializeComponent();
            this._userId = userId;
        }

        private void LoadStudentResults_ForLoggedUser_AllAttempts(int currentUserId)
        {
            using (var _db = new DataClasses1DataContext())
            {
                var q = from p in _db.Participants
                        where p.UserID == currentUserId
                        join s in _db.Subjects on p.SubjectID equals s.ID
                        // total soal untuk subject (per subject)
                        let totalQuestions = _db.Questions.Count(qt => qt.SubjectID == s.ID)
                        // answered & correct untuk participant ini
                        let answered = _db.ParticipantAnswers.Count(a => a.ParticipantID == p.ID
                                                                          && a.Answer != null && a.Answer != "")
                        let correct = _db.ParticipantAnswers.Count(a => a.ParticipantID == p.ID
                                                                         && a.Answer != null && a.Answer != ""
                                                                         && a.Answer == a.Question.CorrectAnswer)
                        orderby p.Date descending, s.Name
                        select new
                        {
                            Subject = s.Name,
                            TimeTaken = TimeSpan.FromMinutes((double)p.TimeTaken),
                            p.Date,
                            Answered = answered,
                            Unanswered = Math.Max(0, totalQuestions - answered),
                            Grade = totalQuestions == 0 ? 0 :
                                    (int)Math.Round((double)correct / totalQuestions * 100, 0, MidpointRounding.AwayFromZero)
                        };

                var list = q.ToList();
                StudentResultView.DataSource = list;

                // formatting
                if (StudentResultView.Columns.Contains("TimeTaken"))
                    StudentResultView.Columns["TimeTaken"].DefaultCellStyle.Format = @"hh\:mm\:ss";

                // header friendly
                if (StudentResultView.Columns.Contains("Subject"))
                    StudentResultView.Columns["Subject"].HeaderText = "Subject";
            }
        }


        private void ResultsUC_Load(object sender, EventArgs e)
        {
            LoadStudentResults_ForLoggedUser_AllAttempts(_userId);
        }

        private void StudentResultView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (StudentResultView.Columns[e.ColumnIndex].Name == "Grade" && e.Value != null)
            {
                if (int.TryParse(e.Value.ToString(), out int grade))
                {
                    if (grade >= 75)
                    {
                        e.CellStyle.BackColor = Color.ForestGreen;
                        e.CellStyle.ForeColor = Color.White;
                    }
                    else if (grade < 75)
                    {
                        e.CellStyle.BackColor = Color.Salmon;
                        e.CellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.IndianRed;
                        e.CellStyle.ForeColor = Color.White;
                    }
                }
            }
        }
    }
}
