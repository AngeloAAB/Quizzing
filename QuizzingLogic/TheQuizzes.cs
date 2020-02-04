using System;
using System.Collections.Generic;
using QuizzingDAL.Models;

namespace QuizzingLogic
{
    public class TheQuizzes
    {
        public int Id { get; set; }
        public string Theme { get; set; }
        public string Description { get; set; }
        public List<aQuestion> theQuestions { get; set; }
    }
}
