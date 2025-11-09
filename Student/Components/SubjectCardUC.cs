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

namespace Quizfy_LKS.Student.Components
{
    public partial class SubjectCardUC : UserControl
    {
        public int SubjectID { get; private set; }
        public int ParticipantID { get; private set; }

        public SubjectCardUC()
        {
            InitializeComponent();
        }

        public void SetData(string name, int time, int questionCount, int subjectId, int participantId)
        {
            SubjectLabel.Text = name;
            SubjectTimeLabel.Text = $"{time} min";
            SubjectQuestCount.Text = $"{questionCount}";
            SubjectID = subjectId;
            ParticipantID = participantId;
        }

        private void StartQuiz_Click(object sender, EventArgs e)
        {
            if (Authentication.UserRole == '2')
            {
                DialogResult result = MessageBox.Show(
                                        "Apakah kamu yakin ingin melanjutkan aksi ini?",
                                        "Konfirmasi",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question
                                    );

                if (result == DialogResult.No) return;

                var parentForm = this.FindForm();
                parentForm.Hide();

                // pass subjectId dan participantId ke form session
                var quizForm = new QuizSessionForm(SubjectID, ParticipantID);
                quizForm.FormClosed += (s, args) => parentForm.Show();
                quizForm.Show();
            }
            else
            {
                MessageBox.Show("Quiz hanya bisa dilakukan oleh student", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
