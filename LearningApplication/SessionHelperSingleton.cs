using LearningApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApplication
{
    internal class SessionHelperSingleton
    {
        private static SessionHelperSingleton _instance;

        private readonly static object _instanceLock = new object();

        public static SessionHelperSingleton GetSingleton()
        {
            lock (_instanceLock)
            {
                if (_instance == null)
                {
                    _instance = new SessionHelperSingleton();
                }
                return _instance;
            }
        }
        private SessionHelperSingleton() { }

        public CardStacks cardStacks { get; set; }
        public string sessionDifficulty { get; set; }
    }
}
