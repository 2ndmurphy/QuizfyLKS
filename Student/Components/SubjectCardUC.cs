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
    }
}
