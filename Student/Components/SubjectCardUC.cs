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

        public SubjectCardUC()
        {
            InitializeComponent();
        }

        public void SetData(string name, int time, int questionCount, int subjectId)
        {
            SubjectLabel.Text = name;
            SubjectTimeLabel.Text = $"{time} min";
            SubjectQuestCount.Text = $"{questionCount}";
            SubjectID = subjectId;
        }

        private void StartQuiz_Click(object sender, EventArgs e)
        {
            if (Authentication.UserRole != '2')
            {
                MessageBox.Show("Quiz hanya bisa dilakukan oleh student.", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                "Apakah kamu yakin ingin melanjutkan aksi ini?",
                "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.No) return;

            // ganti dengan nama Form utama
            if (!(this.FindForm() is StudentDashboard parentForm))
            {
                MessageBox.Show("Parent form tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // create a fresh participant for this attempt
            int participantId = parentForm.CreateNewParticipant(SubjectID);

            parentForm.Hide();

            var quizForm = new QuizSessionForm(SubjectID, participantId);
            quizForm.FormClosed += (s, args) => parentForm.Show();
            quizForm.Show();
        }
    }
}
