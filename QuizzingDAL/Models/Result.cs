using System;
using System.Collections.Generic;

namespace QuizzingDAL.Models
{
    public partial class Result
    {
        public Result()
        {
            Reply = new HashSet<Reply>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal? Score { get; set; }

        public virtual ICollection<Reply> Reply { get; set; }
    }
}
