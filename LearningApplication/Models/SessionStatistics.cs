using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApplication.Entities
{
    public class SessionStatistics
    {
        public int Id { get; set; }
        public DateTime SessionDate { get; set; }
        public string Difficulty { get; set; }
        public int GoodAnswers { get; set; }
        public int AllAnswers { get; set; }
        public int CardStackId { get; set; }
        public CardStacks CardStack { get; set; }
    }
}
