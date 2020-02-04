using System;
using QuizzingLogic;

namespace QuizzingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            bool doMore;
            do
            {
                var question = QFactory.getQuestion(1);

                Console.WriteLine(question.eQuestion);

                foreach (var q in question.eCorrectAnswers)
                {
                    Console.WriteLine($"Correct answer: {q}");
                }

                foreach (var m in question.eMultyChoices)
                {
                    Console.WriteLine($"O. {m}");
                }

                Console.WriteLine("Do you like to continue?");
                string resp = Console.ReadLine();
                if (Boolean.TryParse(resp, out doMore))
                {
                    if (doMore)
                    {

                    }
                }
                else
                {
                    Console.WriteLine("Not valid response, \ntry to answer with True or False");
                    doMore = true;
                }

            } while (doMore);
        }
    }
}
