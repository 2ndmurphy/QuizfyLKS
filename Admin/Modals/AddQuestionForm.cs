using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizfy_LKS.Admin.Modals
{
    public partial class AddQuestionForm : Form
    {
        private readonly int _subjectId;

        public AddQuestionForm(int subjectId)
        {
            InitializeComponent();
            _subjectId = subjectId;
        }

        private void AddQuestionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            (new QuestionsUC()).Show();
        }

        private void CancelAdd_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveQuestion_Click(object sender, EventArgs e)
        {
            var questBox = QuestionBox.Text.Trim();
            var optionA = AnswerA.Text.Trim();
            var optionB = AnswerB.Text.Trim();
            var optionC = AnswerC.Text.Trim();
            var optionD = AnswerD.Text.Trim();

            // Menemukan correct answer berdasarkan radio yang checked
            string correctAnswer = null;
            if (OptionA.Checked) correctAnswer = optionA;
            else if (OptionB.Checked) correctAnswer = optionB;
            else if (OptionC.Checked) correctAnswer = optionC;
            else if (OptionD.Checked) correctAnswer = optionD;

            // Cek jika input yang diperlukan tidak kosong
            if (_subjectId <= 0 || string.IsNullOrEmpty(questBox) ||
                string.IsNullOrEmpty(optionA) || string.IsNullOrEmpty(optionB) ||
                string.IsNullOrEmpty(optionC) || string.IsNullOrEmpty(optionD))
            {
                MessageBox.Show("Subject belum dipilih atau pertanyaan kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var _db = new DataClasses1DataContext())
            {
                try
                {
                    var newQuestion = new Question
                    {
                        SubjectID = _subjectId,
                        Question1 = questBox,
                        OptionA = optionA,
                        OptionB = optionB,
                        OptionC = optionC,
                        OptionD = optionD,
                        CorrectAnswer = correctAnswer
                    };

                    _db.Questions.InsertOnSubmit(newQuestion);
                    _db.SubmitChanges();

                    // Bersihkan semua control
                    QuestionBox.Clear();
                    AnswerA.Clear();
                    AnswerB.Clear();
                    AnswerC.Clear();
                    AnswerD.Clear();
                    OptionA.Checked = OptionB.Checked = OptionC.Checked = OptionD.Checked = false;

                    MessageBox.Show("Pertanyaan berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}
