using LearningApplication.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApplication.Models.Dictionary
{
    class DictionaryManagement
    {
        public List<CardStacks> cardStackList;
        public CardStacks? selectedItem;

        public DictionaryManagement()
        {
            GetDataFromDb();
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
