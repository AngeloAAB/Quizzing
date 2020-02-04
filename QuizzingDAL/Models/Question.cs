using System;
using System.Collections.Generic;

namespace QuizzingDAL.Models
{
    public partial class Question
    {
        public Question()
        {
            CorrectAnswer = new HashSet<CorrectAnswer>();
            Multiplechoice = new HashSet<Multiplechoice>();
        }

        public int Id { get; set; }
        public string AQuestion { get; set; }
        public int? ExamId { get; set; }

        public virtual Exam Exam { get; set; }
        public virtual ICollection<CorrectAnswer> CorrectAnswer { get; set; }
        public virtual ICollection<Multiplechoice> Multiplechoice { get; set; }
    }
}
