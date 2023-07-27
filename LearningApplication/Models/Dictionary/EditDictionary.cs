using LearningApplication.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LearningApplication.Models.Dictionary
{
    class EditDictionary
    {
        public ObservableCollection<Words> wordsList = new ObservableCollection<Words>();
        public Words? selectedItem;
        public string? wordPolish;
        public string? wordTranslated;
        public EditDictionary()
        {
            GetDataFromDb();
        }
        private void GetDataFromDb()
        {
            var editWords = ApplicationHelperSingleton.GetSingleton();
            using (var context = new DatabaseContext())
            {
                var wordList = context.Words.Where(w => w.CardStackId == editWords.cardStacks.Id).ToList();
                foreach (var word in wordList)
                {
                    wordsList.Add(word);
                }
            }
        }
    }
}
