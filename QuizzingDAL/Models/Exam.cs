using System;
using System.Collections.Generic;

namespace QuizzingDAL.Models
{
    public partial class Exam
    {
        public Exam()
        {
            Question = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Theme { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Question> Question { get; set; }
    }
}
