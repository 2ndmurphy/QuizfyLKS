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
                var questions = (from s in _db.Subjects
                                 join q in _db.Questions on s.ID equals q.SubjectID into qs
                                 select new
                                 {
                                     s.Name,
                                     s.Time,
                                     QuestionCount = qs.Count()
                                 }).ToList();

                FlowSubjectContainer.Controls.Clear();

                foreach (var q in questions)
                {
                    SubjectCardUC card = new SubjectCardUC();
                    card.SetData(q.Name, q.Time, q.QuestionCount);
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
