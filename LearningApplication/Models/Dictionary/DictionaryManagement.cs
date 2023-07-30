using LearningApplication.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LearningApplication.Models.Dictionary
{
    class DictionaryManagement
    {
        public List<CardStacks> cardStackList;
        public CardStacks selectedItem;

        public DictionaryManagement()
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
                cardStackList = context.CardStacks.AsNoTracking().ToList();
            }
        }
    }
}
