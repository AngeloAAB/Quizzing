using Microsoft.EntityFrameworkCore;
using QuizzingDAL.Data;
using System.Collections.Generic;
using System.Linq;

namespace QuizzingLogic
{
    public static class QFactory
    {

        static public aQuestion getQuestion(int id)
        {
            var context = new QuizzingDbContext();

            var tq = context.Question.Where(e => e.Id == id)
                                .Select(s => new aQuestion
                                {
                                    Id = s.Id,
                                    eQuestion = s.AQuestion,

                                }).FirstOrDefault();
            tq.eCorrectAnswers = context.CorrectAnswer.Where(c => c.QuestionId == id)
                                    .Include(a => a.Answer)
                                        .Select(b => b.Answer.Answer1 ).ToList();
            tq.eMultyChoices = context.Multiplechoice.Where(c => c.QuestionId == id)
                                    .Include(a => a.Answer)
                                        .Select(b => b.Answer.Answer1 ).ToList();

            return tq;
        }

        static public TheQuizzes GetTheQuiz(int id)
        {
            var context = new QuizzingDbContext();

            var tq = context.Exam.Where(e => e.Id == id)
                                .Select(q => new TheQuizzes
                                {
                                    Id = q.Id,
                                    Theme = q.Theme,
                                    Description = q.Description
                                }).FirstOrDefault();

            var Q = context.Question.Where(e => e.ExamId == id)
                                .Select(i => i.Id).ToList();
            foreach (var q in Q)
            {
                tq.theQuestions.Add(getQuestion(q));
            }

            return tq;
        }
    }
}
