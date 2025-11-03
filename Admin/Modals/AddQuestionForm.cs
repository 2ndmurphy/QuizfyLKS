using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizfy_LKS.Admin.Modals
{
    public partial class AddQuestionForm : Form
    {
        public AddQuestionForm()
        {
            InitializeComponent();
        }

        private void AddQuestionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            (new QuestionsUC()).Show();
        }

        private void CancelAdd_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
