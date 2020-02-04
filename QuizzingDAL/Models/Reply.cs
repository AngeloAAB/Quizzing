using System;
using System.Collections.Generic;

namespace QuizzingDAL.Models
{
    public partial class Reply
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Answered { get; set; }
        public int ResultId { get; set; }

        public virtual Result Result { get; set; }
    }
}
