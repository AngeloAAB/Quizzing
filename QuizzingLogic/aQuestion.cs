using Microsoft.EntityFrameworkCore;
using QuizzingDAL.Data;
using QuizzingDAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace QuizzingLogic
{
    public class aQuestion
    {
        public int Id { get; set; }
        public string eQuestion { get; set; }
        public List<string> eCorrectAnswers { get; set; } = new List<string>();
        public List<string> eMultyChoices { get; set; } = new List<string>();

    }
}