using LearningApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApplication.Models.Statistics
{
    internal class Statistics
    {
        public SessionStatistics sessionStatistics { get; private set; }
        ApplicationHelperSingleton applicationHelperSingleton = ApplicationHelperSingleton.GetSingleton();

        public Statistics()
        {
            sessionStatistics = applicationHelperSingleton.sessionStatistics;
        }
    }
}
