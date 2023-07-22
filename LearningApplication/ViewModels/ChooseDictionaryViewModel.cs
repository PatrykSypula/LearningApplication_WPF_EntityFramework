using LearningApplication.Entities;
using LearningApplication.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace LearningApplication.ViewModels
{
    public class ChooseDictionaryViewModel : INotifyPropertyChanged
    {
        private List<CardStacks> cardStackList;

        public List<CardStacks> CardStackList
        {
            get { return cardStackList; }
            set
            {
                cardStackList = value;
                OnPropertyChanged(nameof(CardStackList));
            }
        }

        public ChooseDictionaryViewModel()
        {
            using (var context = new DatabaseContext())
            {
                cardStackList = context.CardStacks.ToList();
            }
        }
        public CardStacks SelectedItem { get; set; }

        private ICommand closeWindow = null;
        public ICommand CloseWindow
        {
            get
            {
                if (closeWindow == null) closeWindow = new RelayCommand(
                     (object o) =>
                     {
                         foreach (Window item in System.Windows.Application.Current.Windows)
                         {
                             if (item.DataContext == this) item.Close();
                         }
                     });
                return closeWindow;
            }
        }

        private ICommand openDictionary = null;
        public ICommand OpenDictionary
        {
            get
            {
                if (openDictionary == null) openDictionary = new RelayCommand(
                     (object o) =>
                     {
                         var session = SessionHelperSingleton.GetSingleton();
                         session.cardStacks = (CardStacks)SelectedItem;

                         foreach (Window item in System.Windows.Application.Current.Windows)
                         {
                             if (item.DataContext == this) item.Close();
                         }

                         new SessionYesNoWindow().Show();
                     },
                     (object o) =>
                     {
                         return SelectedItem != null;
                     });
                return openDictionary;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName = null)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
