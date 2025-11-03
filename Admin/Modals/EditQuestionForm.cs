using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizfy_LKS.Admin.Modals
{
    public partial class EditQuestionForm : Form
    {
        private readonly int _questionId;

        public EditQuestionForm(int questionId)
        {
            InitializeComponent();
            this._questionId = questionId;
        }

        private void EditQuestionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            (new QuestionsUC()).Show();
        }

        private void CancelUpdate_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadQuestion()
        {
            using (var _db = new DataClasses1DataContext())
            {
                var question = (from q in _db.Questions
                                join s in _db.Subjects on q.SubjectID equals s.ID
                                where q.ID == _questionId
                                select new
                                {
                                    q.Question1,
                                    q.OptionA,
                                    q.OptionB,
                                    q.OptionC,
                                    q.OptionD,
                                    q.CorrectAnswer
                                }).FirstOrDefault();

                if (question != null)
                {
                    // Pisahkan teks pertanyaan dan path gambar
                    string[] parts = question.Question1.Split(',');
                    string questionText = parts[0].Trim();
                    string imageFile = parts.Length > 1 ? parts[1] : null;

                    // Set teks ke textbox
                    QuestionBox.Text = questionText;

                    // Load gambar kalau ada
                    if (!string.IsNullOrEmpty(imageFile))
                    {
                        // /bin/Debug/ImagesQuestions/
                        string imagePath = Path.Combine(Application.StartupPath, "ImagesQuestions", imageFile);

                        if (File.Exists(imagePath))
                        {
                            QuestionImage.Image = Image.FromFile(imagePath);
                            QuestionImage.Width = 113;
                            QuestionImage.Height = 112;
                            QuestionImage.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                        else
                        {
                            QuestionImage.Image = Properties.Resources.add_image; // file gak ketemu
                            QuestionImage.Width = 113;
                            QuestionImage.Height = 112;
                            QuestionImage.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                    else
                    {
                        QuestionImage.Image = Properties.Resources.add_image; // gak ada gambar
                        QuestionImage.Width = 113;
                        QuestionImage.Height = 112;
                        QuestionImage.SizeMode = PictureBoxSizeMode.Zoom;
                    }

                    // Set Semua jawaban ke textbox
                    AnswerA.Text = question.OptionA;
                    AnswerB.Text = question.OptionB;
                    AnswerC.Text = question.OptionC;
                    AnswerD.Text = question.OptionD;

                    // Validasi terkait jawaban yang benar
                    SetCorrectAnswerRadio(question.CorrectAnswer);

                }
            }
        }

        private void SetCorrectAnswerRadio(string correctAnswer, bool compareByLetter = false)
        {
            // reset dulu
            OptionA.Checked = OptionB.Checked = OptionC.Checked = OptionD.Checked = false;

            if (string.IsNullOrWhiteSpace(correctAnswer)) return;

            correctAnswer = correctAnswer.Trim();

            // Kalau betul-betul hanya huruf A/B/C/D -> treat as letter
            if (compareByLetter || Regex.IsMatch(correctAnswer, "^[ABCDabcd]$"))
            {
                switch (correctAnswer.ToUpper())
                {
                    case "A": OptionA.Checked = true; break;
                    case "B": OptionB.Checked = true; break;
                    case "C": OptionC.Checked = true; break;
                    case "D": OptionD.Checked = true; break;
                }
                return;
            }

            // Kalau bukan huruf, mungkin disimpan sebagai teks jawaban -> bandingkan dengan option text
            if (!string.IsNullOrEmpty(AnswerA.Text) && correctAnswer == AnswerA.Text) OptionA.Checked = true;
            else if (!string.IsNullOrEmpty(AnswerB.Text) && correctAnswer == AnswerB.Text) OptionB.Checked = true;
            else if (!string.IsNullOrEmpty(AnswerC.Text) && correctAnswer == AnswerC.Text) OptionC.Checked = true;
            else if (!string.IsNullOrEmpty(AnswerD.Text) && correctAnswer == AnswerD.Text) OptionD.Checked = true;
        }

        private string GetSelectedAnswerText()
        {
            if (OptionA.Checked) return AnswerA.Text;
            if (OptionB.Checked) return AnswerB.Text;
            if (OptionC.Checked) return AnswerC.Text;
            if (OptionD.Checked) return AnswerD.Text;
            return null;
        }


        private void EditQuestionForm_Load(object sender, EventArgs e)
        {
            LoadQuestion();
        }

        private void SaveQuestion_Click(object sender, EventArgs e)
        {
            string selectedText = GetSelectedAnswerText();
            if (selectedText == null)
            {
                MessageBox.Show("Pilih jawaban yang benar dulu.");
                return;
            }

            using (var _db = new DataClasses1DataContext())
            {
                try
                {
                    var question = _db.Questions.SingleOrDefault(q => q.ID == _questionId);
                    if (question == null) return;

                    question.OptionA = AnswerA.Text.Trim();
                    question.OptionB = AnswerB.Text.Trim();
                    question.OptionC = AnswerC.Text.Trim();
                    question.OptionD = AnswerD.Text.Trim();
                    question.CorrectAnswer = selectedText;

                    _db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Terjadi Kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            MessageBox.Show("Saved!");
            this.Refresh();
        }
    }
}
