using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizfy_LKS.Helpers
{
    public class QuizSession
    {
        public int QuestionId { get; set; }
        public string SubjectName { get; set; }
        public string QuestionText { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string CorrectAnswer { get; set; }
        public string SelectedAnswer { get; set; }
    }
}
