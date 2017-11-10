using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Models
{
    public class VoteModel
    {
        public string Name { get; set; }
        public List<string> AnswersOptions { get; set; }
        public List<int> Answers { get; set; }
        public string From { get; set; }
    }
}
