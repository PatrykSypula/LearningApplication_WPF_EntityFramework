using LearningApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LearningApplication.Models.Session
{
    public class ChooseDictionary
    {
        public List<CardStacks> cardStackList;
        public CardStacks selectedItem;

        public ChooseDictionary()
        {
            ApplicationHelperSingleton connection = ApplicationHelperSingleton.GetSingleton();
            try
            {
                GetDataFromDb();
            }
            catch
            {
                MessageBox.Show("Wystąpił błąd podczas łączenia z bazą. Spróbuj ponownie później");
                connection.isConnected = false;
            }
            connection.isConnected = true;
        }
        private void GetDataFromDb()
        {
            using (var context = new DatabaseContext())
            {
                cardStackList = (from c in context.CardStacks
                                 join w in context.Words on c.Id equals w.CardStackId
                                 where c.Id == w.CardStackId
                                 select c).Distinct().ToList();
            }
        }
    }
}
