using LearningApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LearningApplication.Models.Statistics
{
    public class ChooseStatisticDictionary
    {
        public List<CardStacks> statisticDictionaryList;
        public CardStacks selectedItem;

        public ChooseStatisticDictionary()
        {
            ApplicationHelperSingleton connection = ApplicationHelperSingleton.GetSingleton();
            try
            {
                GetDataFromDb();
                connection.isConnected = true;
            }
            catch
            {
                new Views.CustomMessageBoxOk("Wystąpił błąd podczas łączenia z bazą. Spróbuj ponownie później").ShowDialog();
                connection.isConnected = false;
            }
        }
        private void GetDataFromDb()
        {
            using (var context = new DatabaseContext())
            {
                statisticDictionaryList = (from c in context.CardStacks
                                           join s in context.SessionStatistics on c.Id equals s.CardStackId
                                           where c.Id == s.CardStackId
                                           select c).Distinct().ToList();
            }
        }
    }
}
