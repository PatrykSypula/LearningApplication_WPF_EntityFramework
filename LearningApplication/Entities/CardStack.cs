using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApplication.Entities
{
    public class CardStack
    {
        public int Id { get; set; }
        public string CardStackName { get; set; }
        public int IsDefaultCardStack { get; set; }

        public List<Word> Words { get; set; } = new List<Word>();
        public List<SessionStatistic> SessionStatistics { get; set; } = new List<SessionStatistic>();
    }
}
