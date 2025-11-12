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

        // timer fields
        private Timer _countdownTimer;
        private DateTime _endTime;
        private TimeSpan _duration; // duration loaded from Subject.Time (in hours)
        private bool _isFinished = false; // set true when finish was completed (manual or auto)

        public QuizSessionForm(int subjectId, int participantId)
        {
            InitializeComponent();
            quizSessions = new List<QuizSession>();

            this._subjectId = subjectId;
            this._participantId = participantId;
        }

        private void QuizSessionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // if not finished, confirm leaving (but do not show "this form cannot be closed" hard block)
            if (!_isFinished)
            {
                var res = MessageBox.Show(
                    "Sesi belum diselesaikan. Progress tersimpan, tetapi sesi dianggap incomplete. Tetap keluar?",
                    "Konfirmasi",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (res == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            // cleanup timer to avoid leaks
            try
            {
                if (_countdownTimer != null)
                {
                    _countdownTimer.Stop();
                    _countdownTimer.Tick -= CountDownTimer_Tick;
                    _countdownTimer.Dispose();
                    _countdownTimer = null;
                }
            }
            catch { }
        }

        private void QuizSessionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            quizSessions?.Clear();
            quizSessions = null;
            GC.Collect();
        }

        #region Quiz Timer State

        private void LoadDurationAndStartTime()
        {
            using (var db = new DataClasses1DataContext())
            {
                var subject = db.Subjects.FirstOrDefault(s => s.ID == _subjectId);
                if (subject == null)
                {
                    MessageBox.Show("Subject tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // assume subject.Time is number of hours (e.g., 1 = 1 hour)
                double hours = 0;
                try
                {
                    hours = Convert.ToDouble(subject.Time);
                }
                catch
                {
                    hours = 0;
                }

                _duration = TimeSpan.FromHours(hours);

                var participant = db.Participants.FirstOrDefault(p => p.ID == _participantId);
                if (participant == null)
                {
                    MessageBox.Show("Participant session tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // start time is participant.Date (which should be set by parent when creating participant)
                DateTime startTime = participant.Date;
                _endTime = startTime.Add(_duration);
            }

            // init UI timer
            _countdownTimer = new Timer { Interval = 1000 };
            _countdownTimer.Tick += CountDownTimer_Tick;
            _countdownTimer.Start();

            // initial display
            UpdateTimerLabel();
        }

        private void CountDownTimer_Tick(object sender, EventArgs e)
        {
            UpdateTimerLabel();

            var remaining = _endTime - DateTime.Now;
            if (remaining <= TimeSpan.Zero)
            {
                _countdownTimer.Stop();
                // Auto-submit without confirmations
                OnTimeExpiredAutoSubmit();
            }
        }

        private void UpdateTimerLabel()
        {
            var remaining = _endTime - DateTime.Now;
            if (remaining < TimeSpan.Zero) remaining = TimeSpan.Zero;

            // show as HH:mm:ss (if long duration), else mm:ss
            string text;
            if (remaining.TotalHours >= 1)
                text = string.Format("{0:D2}:{1:D2}:{2:D2}", (int)remaining.TotalHours, remaining.Minutes, remaining.Seconds);
            else
                text = string.Format("{0:D2}:{1:D2}", remaining.Minutes, remaining.Seconds);

            TimeLabel.Text = text; // pastikan ada label lblTimer di form
        }

        private void OnTimeExpiredAutoSubmit()
        {
            // mark as auto-finished to bypass confirmation logic
            _isFinished = true;

            // Save answers & update participant.TimeTaken using duration (or elapsed)
            AutoSaveAndFinish();

            MessageBox.Show("Waktu habis! Jawaban disubmit otomatis.", "Waktu Habis", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void AutoSaveAndFinish()
        {
            int correctCount = 0;
            using (var db = new DataClasses1DataContext())
            {
                foreach (var q in quizSessions)
                {
                    var existing = db.ParticipantAnswers
                        .FirstOrDefault(a => a.ParticipantID == _participantId && a.QuestionID == q.QuestionId);

                    if (existing != null)
                    {
                        existing.Answer = q.SelectedAnswer; // may be null
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

                    // assuming CorrectAnswer stores the answer text
                    if (!string.IsNullOrEmpty(q.SelectedAnswer) && q.SelectedAnswer == q.CorrectAnswer)
                        correctCount++;
                }

                var participant = db.Participants.First(p => p.ID == _participantId);

                // compute TimeTaken: if endTime passed, prefer full duration; else compute elapsed
                var elapsed = DateTime.Now - participant.Date;
                int timeTakenSeconds;
                if (elapsed >= _duration)
                    timeTakenSeconds = (int)_duration.TotalSeconds;
                else
                    timeTakenSeconds = (int)elapsed.TotalSeconds;

                participant.TimeTaken = timeTakenSeconds;

                // optional: store score/grade if Participant has columns for it
                // participant.Score = (int)((double)correctCount / Math.Max(1, quizSessions.Count) * 100);

                db.SubmitChanges();
            }
        }

        #endregion End Quiz Timer State


        #region Quiz Session State

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
            // if already auto-submitted by timer, ignore manual finish
            if (_isFinished) return;

            // compute elapsed from participant start
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

            // 1) minimal 3 menit check
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

            // 2) unanswered check
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

            // 3) final confirm
            var finalConfirm = MessageBox.Show(
                "Yakin ingin submit? Pastikan jawaban yang sudah anda pilih sudah benar.",
                "Konfirmasi Submit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (finalConfirm == DialogResult.No) return;

            // 4) save answers + update participant (single transaction)
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

                    if (!string.IsNullOrEmpty(q.SelectedAnswer) && q.SelectedAnswer == q.CorrectAnswer)
                        correctCount++;
                }

                var participant = db.Participants.First(p => p.ID == _participantId);
                participant.TimeTaken = (int)(DateTime.Now - participant.Date).TotalSeconds;
                // optional: participant.Score = (int)((double)correctCount / Math.Max(1, quizSessions.Count) * 100);
                db.SubmitChanges();
            }

            _isFinished = true;
            var score = (int)((double)correctCount / Math.Max(1, quizSessions.Count) * 100);
            MessageBox.Show($"Quiz selesai!\nNilai kamu: {score}", "Selesai", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        #endregion End Quiz Session State

        private void QuizSessionForm_Load(object sender, EventArgs e)
        {
            LoadDurationAndStartTime();
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
