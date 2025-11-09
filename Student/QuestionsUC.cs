using Quizfy_LKS.Helpers;
using Quizfy_LKS.Student.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizfy_LKS.Student
{
    public partial class QuestionsUC : UserControl
    {
        public QuestionsUC()
        {
            InitializeComponent();
        }

        private void LoadQuestions()
        {
            using (var _db = new DataClasses1DataContext())
            {
                var subjects = (from s in _db.Subjects
                                join q in _db.Questions on s.ID equals q.SubjectID into qs
                                select new
                                {
                                    SubjectID = s.ID,
                                    s.Name,
                                    s.Time,
                                    QuestionCount = qs.Count()
                                }).ToList();

                FlowSubjectContainer.Controls.Clear();

                foreach (var subj in subjects)
                {
                    var participant = _db.Participants
                        .FirstOrDefault(p => p.UserID == Authentication.UserId && p.SubjectID == subj.SubjectID);

                    if (participant == null)
                    {
                        participant = new Participant
                        {
                            UserID = Authentication.UserId,
                            SubjectID = subj.SubjectID,
                            Date = DateTime.Now,
                            TimeTaken = 0
                        };
                        _db.Participants.InsertOnSubmit(participant);
                        _db.SubmitChanges();
                    }

                    var card = new SubjectCardUC();
                    card.SetData(subj.Name, subj.Time, subj.QuestionCount, subj.SubjectID, participant.ID);
                    FlowSubjectContainer.Controls.Add(card);
                }
            }
        }

        private void QuestionsUC_Load(object sender, EventArgs e)
        {
            LoadQuestions();
        }
    }
}
