using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourDrivenTest
{
    public class QuestionInfo
    {
        private string Text { get; set; }
        private IList<Answer> Answers { get; set; }
        
        public QuestionInfo(string text, IList<Answer> answers)
        {
            this.Text = text;
            this.Answers = answers;
        }
        
        public Answer TopAnswer 
        { 
            get
            {
                return this.Answers.OrderByDescending(answer => answer.Vote).First();
            }
        }

        public void UpvoteAnswer(string answerText)
        {
            var selectedAnswer = this.Answers.Where(answer => answer.Text.Trim().ToLower() == answerText.Trim().ToLower()).FirstOrDefault();
            if (selectedAnswer != null)
            {
                selectedAnswer.Vote++;
            }
        }
        
        public class Answer
        {
            public string Text { get; set; }
            public int Vote { get; set; }
        }
    }
}
