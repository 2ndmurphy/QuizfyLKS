using Quizfy_LKS.Helpers;
using Quizfy_LKS.Student.Components;
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
    public partial class DashboardUC : UserControl
    {
        private readonly int _userId;

        public DashboardUC()
        {
            InitializeComponent();
            this._userId = Authentication.UserId;
            this.GreetLabel.Text = $"Hey {Authentication.UserName},";
        }

        private void LoadSubjects()
        {
            using (var _db = new DataClasses1DataContext())
            {
                var subjects = (from s in _db.Subjects
                                join q in _db.Questions on s.ID equals q.SubjectID into qs
                                select new
                                {
                                    s.Name,
                                    s.Time,
                                    QuestionCount = qs.Count()
                                }).ToList();

                // clear flow layout sebelum bind data subjects
                FlowSubjectContainer.Controls.Clear();

                foreach (var subject in subjects)
                {
                    SubjectCardUC card = new SubjectCardUC();
                    card.SetData(subject.Name, subject.Time, subject.QuestionCount);
                    FlowSubjectContainer.Controls.Add(card);
                }
            }
        }

        private void DashboardUC_Load(object sender, EventArgs e)
        {
            LoadSubjects();
        }
    }
}
