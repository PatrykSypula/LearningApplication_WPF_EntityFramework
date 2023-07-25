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
                cardStackList = (from c in context.CardStacks
                             join w in context.Words on c.Id equals w.CardStackId
                             where c.Id == w.CardStackId
                             select c).Distinct().ToList();
            }
        }
    }
}
