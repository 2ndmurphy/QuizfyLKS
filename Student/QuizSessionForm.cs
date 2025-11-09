using Quizfy_LKS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizfy_LKS.Student
{
    public partial class QuizSessionForm : Form
    {
        private List<QuizSession> quizSessions;

        private int currentIndex = 0;

        private int _subjectId;
        private int _participantId;

        public QuizSessionForm(int subjectId, int participantId)
        {
            InitializeComponent();
            quizSessions = new List<QuizSession>();

            this._subjectId = subjectId;
            this._participantId = participantId;
        }

        private void QuizSessionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // jika quiz belum disubmit (kita anggap participant.TimeTaken == 0 berarti belum submit)
            using (var db = new DataClasses1DataContext())
            {
                var participant = db.Participants.FirstOrDefault(p => p.ID == _participantId);
                bool isFinished = participant != null && participant.TimeTaken > 0;

                if (!isFinished)
                {
                    var leaveConfirm = MessageBox.Show(
                        "Sesi belum diselesaikan. Progress akan tersimpan tapi sesi dianggap incomplete. Tetap keluar?",
                        "Konfirmasi",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (leaveConfirm == DialogResult.No)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }

        private void LoadQuestions()
        {
            using (var db = new DataClasses1DataContext())
            {
                quizSessions = (from q in db.Questions
                                where q.SubjectID == _subjectId
                                join pa in db.ParticipantAnswers
                                    .Where(p => p.ParticipantID == _participantId)
                                    on q.ID equals pa.QuestionID into paJoin
                                from pa in paJoin.DefaultIfEmpty()
                                select new QuizSession
                                {
                                    QuestionId = q.ID,
                                    SubjectName = q.Subject.Name,
                                    QuestionText = q.Question1,
                                    OptionA = q.OptionA,
                                    OptionB = q.OptionB,
                                    OptionC = q.OptionC,
                                    OptionD = q.OptionD,
                                    CorrectAnswer = q.CorrectAnswer,
                                    SelectedAnswer = pa != null ? pa.Answer : null
                                }).ToList();
            }
        }

        private void ShowQuestion(int index)
        {
            if (index < 0 || index >= quizSessions.Count) return;

            var q = quizSessions[index];

            LblQuestionNumber.Text = $"Question {index + 1} of {quizSessions.Count}";
            SubjectLabel.Text = q.SubjectName;
            QuestionLbl.Text = q.QuestionText;
            rbA.Text = q.OptionA;
            rbB.Text = q.OptionB;
            rbC.Text = q.OptionC;
            rbD.Text = q.OptionD;

            // reset checked
            rbA.Checked = rbB.Checked = rbC.Checked = rbD.Checked = false;

            // restore selected answer berdasarkan teks
            if (!string.IsNullOrEmpty(q.SelectedAnswer))
            {
                if (q.SelectedAnswer == rbA.Text) rbA.Checked = true;
                else if (q.SelectedAnswer == rbB.Text) rbB.Checked = true;
                else if (q.SelectedAnswer == rbC.Text) rbC.Checked = true;
                else if (q.SelectedAnswer == rbD.Text) rbD.Checked = true;
            }

            PrevBtn.Enabled = index > 0;
            NextBtn.Text = (index == quizSessions.Count - 1) ? "Finish" : "Next";
        }

        private void SaveAnswer(string selected)
        {
            var q = quizSessions[currentIndex];
            q.SelectedAnswer = selected;

            // langsung save ke DB
            using (var _db = new DataClasses1DataContext())
            {
                var existing = _db.ParticipantAnswers
                    .FirstOrDefault(a => a.ParticipantID == _participantId && a.QuestionID == q.QuestionId);

                if (existing != null)
                {
                    existing.Answer = selected;
                }
                else
                {
                    _db.ParticipantAnswers.InsertOnSubmit(new ParticipantAnswer
                    {
                        ParticipantID = _participantId,
                        QuestionID = q.QuestionId,
                        Answer = selected
                    });
                }
                _db.SubmitChanges();
            }
        }

        private void FinishQuiz()
        {
            // Hitung waktu elapsed dari participant.Date
            DateTime startTime;
            using (var db = new DataClasses1DataContext())
            {
                var part = db.Participants.FirstOrDefault(p => p.ID == _participantId);
                if (part == null)
                {
                    MessageBox.Show("Participant session tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                startTime = part.Date;
            }

            var elapsed = DateTime.Now - startTime;

            // 1) Cek minimal waktu 3 menit
            if (elapsed < TimeSpan.FromMinutes(3))
            {
                var res = MessageBox.Show(
                    $"Waktu pengerjaan baru {elapsed.TotalSeconds:F0} detik. Minimal waktu pengerjaan adalah 3 menit. Tetap submit sekarang?",
                    "Waktu Belum Cukup",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (res == DialogResult.No) return;
            }

            // 2) Cek unanswered
            var unansweredCount = quizSessions.Count(q => string.IsNullOrEmpty(q.SelectedAnswer));
            if (unansweredCount > 0)
            {
                var res = MessageBox.Show(
                    $"Masih ada {unansweredCount} soal yang belum dijawab. Anda yakin ingin submit sekarang?",
                    "Soal Belum Lengkap",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (res == DialogResult.No) return;
            }

            // 3) Final confirmation
            var finalConfirm = MessageBox.Show(
                "Yakin ingin submit? Pastikan jawaban yang sudah anda pilih sudah benar.",
                "Konfirmasi Submit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (finalConfirm == DialogResult.No) return;

            // 4) Simpan semua jawaban + update participant (single transaction)
            int correctCount = 0;
            using (var db = new DataClasses1DataContext())
            {
                foreach (var q in quizSessions)
                {
                    var existing = db.ParticipantAnswers
                        .FirstOrDefault(a => a.ParticipantID == _participantId && a.QuestionID == q.QuestionId);

                    if (existing != null)
                    {
                        existing.Answer = q.SelectedAnswer;
                    }
                    else
                    {
                        db.ParticipantAnswers.InsertOnSubmit(new ParticipantAnswer
                        {
                            ParticipantID = _participantId,
                            QuestionID = q.QuestionId,
                            Answer = q.SelectedAnswer
                        });
                    }

                    // Hitung correct (asumsi CorrectAnswer berisi teks jawaban) 
                    if (!string.IsNullOrEmpty(q.SelectedAnswer) && q.SelectedAnswer == q.CorrectAnswer)
                    {
                        correctCount++;
                    }
                }

                var participant = db.Participants.First(p => p.ID == _participantId);
                participant.TimeTaken = (int)(DateTime.Now - participant.Date).TotalSeconds;
                // optional: simpan score/grade jika ada kolom di Participant
                // participant.Score = (int)((double)correctCount / quizSessions.Count * 100);

                db.SubmitChanges();
            }

            var score = (int)((double)correctCount / Math.Max(1, quizSessions.Count) * 100);

            MessageBox.Show($"Quiz selesai!\nNilai kamu: {score}", "Selesai", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }


        private void QuizSessionForm_Load(object sender, EventArgs e)
        {
            LoadQuestions();
            if (quizSessions.Any())
                ShowQuestion(0);

            rbA.CheckedChanged += Rb_CheckedChanged;
            rbB.CheckedChanged += Rb_CheckedChanged;
            rbC.CheckedChanged += Rb_CheckedChanged;
            rbD.CheckedChanged += Rb_CheckedChanged;
        }

        private void Rb_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked)
            {
                SaveAnswer(rb.Text);
            }
        }

        private void PrevBtn_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                ShowQuestion(currentIndex);
            }
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            if (NextBtn.Text == "Finish")
            {
                FinishQuiz();
                return;
            }

            if (currentIndex < quizSessions.Count - 1)
            {
                currentIndex++;
                ShowQuestion(currentIndex);
            }
        }
    }
}
