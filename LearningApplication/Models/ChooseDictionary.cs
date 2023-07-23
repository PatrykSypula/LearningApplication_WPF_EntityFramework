using LearningApplication.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApplication.Models
{
    public class ChooseDictionary
    {
        public List<CardStacks> cardStackList;
        public CardStacks? selectedItem;

        public ChooseDictionary()
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
