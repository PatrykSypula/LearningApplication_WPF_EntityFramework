using LearningApplication.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace LearningApplication.ViewModels
{
    public class ChooseDictionaryViewModel : INotifyPropertyChanged
    {
        public List<CardStacks> CardStackList { get; set; }

        public ChooseDictionaryViewModel()
        {
            using (var context = new DatabaseContext())
            {
                CardStackList = context.CardStacks.ToList();
            }
        }
        public CardStacks SelectedItem { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName = null)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
