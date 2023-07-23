using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LearningApplication.Entities
{
    public class CardStacks
    {
        public int Id { get; set; }
        public string CardStackName { get; set; }
        public int IsDefaultCardStack { get; set; }

        public List<Words> Words { get; set; } = new List<Words>();
        public List<SessionStatistics> SessionStatistics { get; set; } = new List<SessionStatistics>();
    }
}
