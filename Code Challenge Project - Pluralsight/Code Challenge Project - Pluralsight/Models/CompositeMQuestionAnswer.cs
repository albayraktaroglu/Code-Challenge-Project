using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Code_Challenge_Project___Pluralsight.Models
{
    public class CompositeMQuestionAnswer
    {
        public int QuestionID { get; set; }
        public int FirstOperand  { get; set; }
        public int SecondOperand { get; set; }
        public char MathOperation { get; set; }
        public List<Distractor> Options { get; set; }

        public int Answer { get; set; }

    }
}