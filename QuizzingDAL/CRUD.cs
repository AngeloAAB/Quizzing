using QuizzingDAL.Data;
using QuizzingDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizzingDAL
{
    public static class CRUD
    {
        public static Exam CreateExam(string theme, string description)
        {
            var context = new QuizzingDbContext();

            Exam NewExam = new Exam { Theme = theme, Description = description };
            context.Exam.Add(NewExam);
            context.SaveChanges();
            NewExam.Id = context.Exam.FirstOrDefault(e => e.Theme == theme).Id;

            return NewExam;
        }

        public static void ReadExam(int id)
        {
            var context = new QuizzingDbContext();
            var foundExam = context.Exam.FirstOrDefault(e => e.Id == id );

            if (foundExam != null)
            {
                Console.WriteLine($"Id          : {foundExam.Id}");
                Console.WriteLine($"Theme       : {foundExam.Theme}");
                Console.WriteLine($"Description : {foundExam.Description}");
            }

        }
    }
}
