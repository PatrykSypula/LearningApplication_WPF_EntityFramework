using LearningApplication.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApplication.Models.Dictionary
{
    public class DictionaryCreate
    {

        public List<CardStacks> cardStackList;
        public CardStacks selectedItem;

        public DictionaryCreate()
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
                cardStackList = context.CardStacks.AsNoTracking().ToList();
            }
        }

    }
}
