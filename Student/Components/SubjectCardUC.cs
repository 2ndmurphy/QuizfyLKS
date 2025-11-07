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
        public SubjectCardUC()
        {
            InitializeComponent();
        }

        public void SetData(string name, int time, int questionCount)
        {
            SubjectLabel.Text = name;
            SubjectTimeLabel.Text = $"{time} min";
            SubjectQuestCount.Text = $"{questionCount}";
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

                (new QuizSessionForm()).Show();
            }
            else
            {
                MessageBox.Show("Quiz hanya bisa dilakukan oleh student", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
