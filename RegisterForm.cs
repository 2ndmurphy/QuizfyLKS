using Quizfy_LKS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizfy_LKS
{
    public partial class RegisterForm : Form
    {
        private readonly DataClasses1DataContext db;

        public RegisterForm()
        {
            InitializeComponent();
            db = new DataClasses1DataContext();
        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.form.Show();
        }

        private void RegisterSubmit_Click(object sender, EventArgs e)
        {
            string fullname = textBox1.Text.Trim();
            string email = textBox2.Text.Trim();
            char gender = radioButton1.Checked ? '1' : (radioButton2.Checked ? '2' : '\0');
            var birthday = maskedTextBox1.Text.Trim();
            var birthdate = DateTime.Parse(birthday);
            string password = textBox4.Text.Trim();
            string confirmPassword = textBox5.Text.Trim();

            // Validasi Input
            if (string.IsNullOrEmpty(fullname) ||
                string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) ||
                gender == '\0')
            {
                MessageBox.Show("Tolong lengkapi data anda", "Register Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validasi format email
            if (!Authentication.ValidateEmail(email))
            {
                MessageBox.Show("Email tidak valid", "Register Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validasi konfirmasi password
            if (password != confirmPassword)
            {
                MessageBox.Show("Pastikan konfirmasi password sama", "Register Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // cek email unik
            var user = db.Users.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                MessageBox.Show("Email sudah terdaftar, gunakan email lain.", "Register Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // User baru
            var newUser = new User
            {
                FullName = fullname,
                Email = email,
                Gender = gender,
                Role = '2',
                BirthDate = birthdate,
                Password = password,
                IsActive = false
            };

            try
            {
                db.Users.InsertOnSubmit(newUser);
                db.SubmitChanges();
                MessageBox.Show("Akun anda akan diaktifkan oleh admin segera", "Registrasi berhasil!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
