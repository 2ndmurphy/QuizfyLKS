using Quizfy_LKS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizfy_LKS.Student
{
    public partial class DashboardUC : UserControl
    {
        private readonly int _userId;

        public DashboardUC(int userId)
        {
            InitializeComponent();
            this._userId = userId;
            this.GreetLabel.Text = $"Hey {Authentication.UserName},";
        }
    }
}
