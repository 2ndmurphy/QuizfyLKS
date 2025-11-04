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
    public partial class AddQuestionForm : Form
    {
        private readonly int _subjectId;
        private string _selectedImageFileName = null;

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

        private string SaveImageToImagesFolder(Image img, string originalFileName)
        {
            if (img == null) throw new ArgumentNullException(nameof(img));
            if (string.IsNullOrEmpty(originalFileName)) throw new ArgumentNullException(nameof(originalFileName));

            string imagesDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ImagesQuestions");
            if (!Directory.Exists(imagesDir))
                Directory.CreateDirectory(imagesDir);

            string destPath = Path.Combine(imagesDir, originalFileName);

            // Kalau file sudah ada, tambahkan timestamp supaya gak ketimpa
            if (File.Exists(destPath))
            {
                string name = Path.GetFileNameWithoutExtension(originalFileName);
                string ext = Path.GetExtension(originalFileName);
                string newName = $"{name}_{DateTime.Now:yyyyMMddHHmmss}{ext}";
                destPath = Path.Combine(imagesDir, newName);
                originalFileName = newName;
            }

            // Simpan image (disalin jadi bitmap agar tidak ter-lock)
            using (var bmp = new Bitmap(img))
            {
                bmp.Save(destPath);
            }

            return originalFileName; // contoh: "bulan.jpg"
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

            PictureBox imgPb = this.Controls.Find("QuestionsImage", true).FirstOrDefault() as PictureBox;

            // Jika ada gambar, simpan ke folder Images dan siapkan nama file yang akan ditambahkan ke question text
            string appendedFilename = null;
            if (imgPb != null && imgPb.Image != null && !string.IsNullOrEmpty(_selectedImageFileName))
            {
                try
                {
                    appendedFilename = SaveImageToImagesFolder(imgPb.Image, _selectedImageFileName);
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
                    var newQuestion = new Question
                    {
                        SubjectID = _subjectId,
                        // Jika ada file, tambahkan " filename.jpg" di akhir pertanyaan sesuai permintaan
                        Question1 = string.IsNullOrEmpty(appendedFilename) ? questBox : $"{questBox} {appendedFilename}",
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
                    _selectedImageFileName = null;

                    if (imgPb != null && imgPb.Image != null)
                    {
                        imgPb.Image.Dispose();
                        imgPb.Image = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            MessageBox.Show("Pertanyaan berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void QuestionsImage_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Title = "Select an Image";
                dlg.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                if (dlg.ShowDialog() != DialogResult.OK)
                    return;

                string filePath = dlg.FileName;
                _selectedImageFileName = Path.GetFileName(filePath);

                try
                {
                    using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    using (var img = Image.FromStream(fs))
                    {
                        var bitmapCopy = new Bitmap(img);

                        PictureBox targetPb = sender as PictureBox ?? this.Controls.Find("QuestionsImage", true).FirstOrDefault() as PictureBox;
                        if (targetPb != null)
                        {
                            if (targetPb.Image != null)
                            {
                                try { targetPb.Image.Dispose(); } catch { }
                            }
                            targetPb.Image = bitmapCopy;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
