using System;
using System.Collections.Generic;

namespace QuizzingDAL.Models
{
    public partial class Answer
    {
        public Answer()
        {
            CorrectAnswer = new HashSet<CorrectAnswer>();
            Multiplechoice = new HashSet<Multiplechoice>();
        }

        public int Id { get; set; }
        public string Answer1 { get; set; }

        public virtual ICollection<CorrectAnswer> CorrectAnswer { get; set; }
        public virtual ICollection<Multiplechoice> Multiplechoice { get; set; }
    }
}
