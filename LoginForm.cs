using Quizfy_LKS.Admin;
using Quizfy_LKS.Helpers;
using Quizfy_LKS.Student;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizfy_LKS
{
    public partial class LoginForm : Form
    {
        private readonly DataClasses1DataContext db;

        public LoginForm()
        {
            InitializeComponent();
            db = new DataClasses1DataContext();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Authentication.TryGetCredentials(textBox1, textBox2, out string email, out string password))
                return;

            // Panggil user berdasarkan email
            var user = db.Users.FirstOrDefault(u => u.Email == email);

            if (user == null) { MessageBox.Show("User tidak ditemukan", "Login Gagal"); return; }

            if (!user.IsActive)
            {
                MessageBox.Show("Akun tidak aktif, hubungin admin untuk mengaktifkan kembali", "Akun tidak aktif");
                return;
            }

            if (user.Password == password)
            {
                if (user.Role == '1')
                {
                    Authentication.SignIn(user.ID, user.Role, user.FullName);
                    (new AdminDashboard()).Show();
                    this.Hide();
                }
                else
                {
                    Authentication.SignIn(user.ID, user.Role, user.FullName);
                    (new StudentDashboard()).Show();
                    this.Hide();
                }

                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                MessageBox.Show("Your credentials invalid, please try again", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            (new RegisterForm()).Show();
            Hide();
        }
    }
}
