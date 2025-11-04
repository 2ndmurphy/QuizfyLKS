using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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

        // new fields to track image state
        private string _selectedImageFileName = null; // filename currently associated (may be original or newly chosen)
        private bool _imageChanged = false; // true if user picked a new image in this edit session

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
                    // Database stores Question1 as either "Question text" or "Question text filename.ext"
                    string fullQuestion = question.Question1 ?? string.Empty;
                    string questionText = fullQuestion;
                    string imageFile = null;

                    // Try detect a trailing filename (space-separated). We check last token for extension and file existence.
                    var tokens = fullQuestion.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (tokens.Length > 1)
                    {
                        var lastToken = tokens.Last();
                        // basic extension check
                        if (Regex.IsMatch(lastToken, @"\.(jpg|jpeg|png)$", RegexOptions.IgnoreCase))
                        {
                            // check if file exists in ImagesQuestions folder
                            string imagePathCheck = Path.Combine(Application.StartupPath, "ImagesQuestions", lastToken);
                            if (File.Exists(imagePathCheck))
                            {
                                imageFile = lastToken;
                                // remove the last token from questionText
                                questionText = string.Join(" ", tokens.Take(tokens.Length - 1));
                            }
                        }
                    }

                    // fallback: if no file found, questionText stays fullQuestion
                    QuestionBox.Text = questionText.Trim();

                    // Set answers
                    AnswerA.Text = question.OptionA;
                    AnswerB.Text = question.OptionB;
                    AnswerC.Text = question.OptionC;
                    AnswerD.Text = question.OptionD;

                    // Set radio based on stored correct answer
                    SetCorrectAnswerRadio(question.CorrectAnswer);

                    // Load image preview if we found one
                    if (!string.IsNullOrEmpty(imageFile))
                    {
                        string imagePath = Path.Combine(Application.StartupPath, "ImagesQuestions", imageFile);
                        try
                        {
                            // load without locking file: read stream then clone bitmap
                            using (var fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                            using (var img = Image.FromStream(fs))
                            {
                                // dispose previous if any
                                if (QuestionImage.Image != null)
                                {
                                    try { QuestionImage.Image.Dispose(); } catch { }
                                }
                                QuestionImage.Image = new Bitmap(img);
                            }

                            QuestionImage.Width = 113;
                            QuestionImage.Height = 112;
                            QuestionImage.SizeMode = PictureBoxSizeMode.Zoom;

                            // set current filename (not marking changed)
                            _selectedImageFileName = imageFile;
                            _imageChanged = false;
                        }
                        catch
                        {
                            // if load fail, show fallback resource
                            SetQuestionImageFallback();
                        }
                    }
                    else
                    {
                        SetQuestionImageFallback();
                        _selectedImageFileName = null;
                        _imageChanged = false;
                    }
                }
            }
        }

        private void SetQuestionImageFallback()
        {
            if (QuestionImage.Image != null)
            {
                try { QuestionImage.Image.Dispose(); } catch { }
            }
            // assume you have a resource named add_image
            QuestionImage.Image = Properties.Resources.add_image;
            QuestionImage.Width = 113;
            QuestionImage.Height = 112;
            QuestionImage.SizeMode = PictureBoxSizeMode.Zoom;
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

            // prepare the Question1 field value: QuestionBox text + optional filename
            string questionText = QuestionBox.Text.Trim();

            // If user changed image (picked new one), ensure we copy it to ImagesQuestions and update filename
            string finalImageFileName = _selectedImageFileName;
            PictureBox imgPb = this.Controls.Find("QuestionImage", true).FirstOrDefault() as PictureBox;

            if (imgPb != null && imgPb.Image != null && _imageChanged)
            {
                try
                {
                    // Save the new image; this will return actual filename used (maybe with timestamp)
                    finalImageFileName = SaveImageToImagesQuestionsFolder(imgPb.Image, _selectedImageFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal menyimpan image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
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

                    // update Question1 to include filename if there is any
                    question.Question1 = string.IsNullOrEmpty(finalImageFileName)
                        ? questionText
                        : $"{questionText} {finalImageFileName}";

                    _db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Terjadi Kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            MessageBox.Show("Question updated succesfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void QuestionImage_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Title = "Select an Image";
                dlg.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                if (dlg.ShowDialog() != DialogResult.OK)
                    return;

                string filePath = dlg.FileName;
                string fileName = Path.GetFileName(filePath);

                try
                {
                    using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    using (var img = Image.FromStream(fs))
                    {
                        // dispose previous preview if any
                        if (QuestionImage.Image != null)
                        {
                            try { QuestionImage.Image.Dispose(); } catch { }
                        }
                        QuestionImage.Image = new Bitmap(img);
                        QuestionImage.SizeMode = PictureBoxSizeMode.Zoom;
                        QuestionImage.Width = 113;
                        QuestionImage.Height = 112;
                    }

                    // mark that user selected a new image in this session
                    _selectedImageFileName = fileName;
                    _imageChanged = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // helper: copy image to ImagesQuestions folder; returns the filename actually used (may include timestamp)
        private string SaveImageToImagesQuestionsFolder(Image img, string originalFileName)
        {
            if (img == null) throw new ArgumentNullException(nameof(img));
            if (string.IsNullOrEmpty(originalFileName)) throw new ArgumentNullException(nameof(originalFileName));

            string imagesDir = Path.Combine(Application.StartupPath, "ImagesQuestions");
            if (!Directory.Exists(imagesDir))
                Directory.CreateDirectory(imagesDir);

            string destPath = Path.Combine(imagesDir, originalFileName);
            string finalFileName = originalFileName;

            // If file exists, append timestamp to avoid overwrite
            if (File.Exists(destPath))
            {
                string name = Path.GetFileNameWithoutExtension(originalFileName);
                string ext = Path.GetExtension(originalFileName);
                string newName = $"{name}_{DateTime.Now:yyyyMMddHHmmss}{ext}";
                destPath = Path.Combine(imagesDir, newName);
                finalFileName = newName;
            }

            // determine image format from extension
            var extLower = Path.GetExtension(finalFileName).ToLowerInvariant();
            ImageFormat fmt = ImageFormat.Jpeg;
            if (extLower == ".png") fmt = ImageFormat.Png;
            else if (extLower == ".bmp") fmt = ImageFormat.Bmp;
            else if (extLower == ".gif") fmt = ImageFormat.Gif;
            else if (extLower == ".jpeg" || extLower == ".jpg") fmt = ImageFormat.Jpeg;

            // Save cloned bitmap to avoid locking
            using (var bmp = new Bitmap(img))
            {
                bmp.Save(destPath, fmt);
            }

            // mark image is now saved (not changed anymore)
            _imageChanged = false;
            _selectedImageFileName = finalFileName;

            return finalFileName;
        }
    }
}
