using NUnit.Framework;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace BehaviourDrivenTest
{
    [Binding]
    public class OrderingAnswersSteps
    {
        QuestionInfo questionInSubject;

        [Given(@"there is a question ""(.*)"" with the answers")]
        public void GivenThereIsAQuestionWithTheAnswers(string p0, Table table)
        {
            var answers = new List<QuestionInfo.Answer>();
            foreach(var row in table.Rows)
            {
                answers.Add(new QuestionInfo.Answer {Text = row[0], Vote = int.Parse(row[1])});
            }

            questionInSubject = new QuestionInfo(text: p0, answers: answers);
        }
        
        [When(@"you upvote answer ""(.*)""")]
        public void WhenYouUpvoteAnswer(string p0)
        {
            questionInSubject.UpvoteAnswer(answerText: p0);
        }
        
        [Then(@"the answer ""(.*)"" should be on the top")]
        public void ThenTheAnswerShouldBeOnTheTop(string p0)
        {
            Assert.AreEqual(p0, questionInSubject.TopAnswer.Text);
        }
    }
}
