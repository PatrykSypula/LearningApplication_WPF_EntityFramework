using LearningApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApplication
{
    internal class ApplicationHelperSingleton
    {
        private static ApplicationHelperSingleton _instance;

        private readonly static object _instanceLock = new object();

        public static ApplicationHelperSingleton GetSingleton()
        {
            lock (_instanceLock)
            {
                if (_instance == null)
                {
                    _instance = new ApplicationHelperSingleton();
                }
                return _instance;
            }
        }
        private ApplicationHelperSingleton() { }

        public bool isConnected = true;

        public CardStacks cardStacks { get; set; }
        public SessionStatistics sessionStatistics { get; set; }
        public string sessionDifficulty { get; set; }
        public string dictionaryAction { get; set; }
        public string statisticAction { get; set; }
    }
}
