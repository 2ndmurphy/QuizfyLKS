using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizfy_LKS.Admin
{
    public partial class ResultsUC : UserControl
    {
        public ResultsUC()
        {
            InitializeComponent();
        }

        private void LoadSubjects()
        {
            using (var _db = new DataClasses1DataContext())
            {
                var subjects = _db.Subjects
                          .Select(s => new { s.ID, s.Name })
                          .ToList();

                SubjectCB.DataSource = subjects;
                SubjectCB.ValueMember = "ID";
                SubjectCB.DisplayMember = "Name";
            }
        }

        private void LoadParticipantDates(int? subjectId = null)
        {
            using (var _db = new DataClasses1DataContext())
            {
                var query = _db.Participants.AsQueryable();

                if (subjectId.HasValue)
                    query = query.Where(p => p.SubjectID == subjectId.Value);

                var dates = query
                            .Select(p => p.Date)
                            .Distinct()
                            .OrderByDescending(d => d)
                            .ToList();

                ParticipantDate.DataSource = dates;
            }
        }


        private void LoadStudentResults(int subjectId, DateTime date)
        {
            using (var _db = new DataClasses1DataContext())
            {
                int totalQuestions = _db.Questions.Count(q => q.SubjectID == subjectId);

                var studentResult = (from p in _db.Participants
                                     where p.SubjectID == subjectId && p.Date == date
                                     join u in _db.Users on p.UserID equals u.ID
                                     // gunakan let supaya hitungan dipakai berkali-kali
                                     let answered = _db.ParticipantAnswers
                                                       .Count(a => a.ParticipantID == p.ID && a.Answer != null && a.Answer != "")
                                     let correct = _db.ParticipantAnswers
                                                       .Count(a => a.ParticipantID == p.ID
                                                                 && a.Answer != null && a.Answer != ""
                                                                 && a.Answer == a.Question.CorrectAnswer) // pakai navigasi Question
                                     select new
                                     {
                                         u.FullName,
                                         p.TimeTaken,
                                         Answered = answered,
                                         Unanswered = totalQuestions - answered,
                                         Grade = totalQuestions == 0 ? 0 : (int)Math.Round((double)correct / totalQuestions * 100, 0, MidpointRounding.AwayFromZero)
                                     }).ToList();

                StudentQuestionView.DataSource = studentResult;
            }
        }

        private void ResultsUC_Load(object sender, EventArgs e)
        {
            LoadSubjects();
            LoadParticipantDates();

            int subjectId = (int)SubjectCB.SelectedValue;
            DateTime participantDate = (DateTime)ParticipantDate.SelectedItem;
            LoadStudentResults(subjectId, participantDate);
        }


        private void SearchIcon_Click(object sender, EventArgs e)
        {
            if (SubjectCB.SelectedValue == null || ParticipantDate.SelectedItem == null)
            {
                MessageBox.Show("Pilih subject dan tanggal dulu bro.");
                return;
            }

            int subjectId = (int)SubjectCB.SelectedValue;
            DateTime participantDate = (DateTime)ParticipantDate.SelectedItem;
            LoadStudentResults(subjectId, participantDate);
        }
    }
}
