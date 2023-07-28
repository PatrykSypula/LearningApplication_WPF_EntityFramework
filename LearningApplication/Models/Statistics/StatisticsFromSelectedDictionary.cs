using LearningApplication.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LearningApplication.Models.Statistics
{
    public class StatisticsFromSelectedDictionary
    {
        public List<SessionStatistics> statisticsList;
        public SessionStatistics selectedItem;

        public StatisticsFromSelectedDictionary()
        {
            GetDataFromDb();
        }
        private void GetDataFromDb()
        {
            var dictionary = ApplicationHelperSingleton.GetSingleton();
            using (var context = new DatabaseContext())
            {
                statisticsList = context.SessionStatistics.Where(s => s.CardStackId == dictionary.cardStacks.Id).AsNoTracking().ToList();
            }
        }
    }
}
