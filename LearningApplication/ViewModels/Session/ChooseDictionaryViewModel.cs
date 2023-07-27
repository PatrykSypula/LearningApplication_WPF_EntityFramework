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

namespace LearningApplication.ViewModels.Session
{
    public class ChooseDictionaryViewModel : INotifyPropertyChanged
    {
        #region Binding and Fields

        Models.Session.ChooseDictionary chooseDictionary = new Models.Session.ChooseDictionary();

        public List<CardStacks> CardStackList
        {
            get { return chooseDictionary.cardStackList; }
            set
            {
                chooseDictionary.cardStackList = value;
                OnPropertyChanged(nameof(CardStackList));
            }
        }

        public CardStacks? SelectedItem
        {
            get
            {
                return chooseDictionary.selectedItem;
            }
            set
            {
                chooseDictionary.selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        #endregion

        #region Commands

        private ICommand? closeWindow = null;
        public ICommand CloseWindow
        {
            get
            {
                if (closeWindow == null) closeWindow = new RelayCommand(
                     (o) =>
                     {
                         foreach (Window item in System.Windows.Application.Current.Windows)
                         {
                             if (item.DataContext == this) item.Close();
                         }
                     });
                return closeWindow;
            }
        }

        private ICommand? openDictionary = null;
        public ICommand OpenDictionary
        {
            get
            {
                if (openDictionary == null) openDictionary = new RelayCommand(
                     (o) =>
                     {

                         var session = ApplicationHelperSingleton.GetSingleton();
                         session.cardStacks = SelectedItem;

                         foreach (Window item in System.Windows.Application.Current.Windows)
                         {
                             if (item.DataContext == this) item.Close();
                         }
                         switch (session.sessionDifficulty)
                         {
                             case "Poznawanie słów":
                                 new SessionYesNoWindow().ShowDialog();
                                 break;
                             case "Uczenie słów":
                                 new SessionInputWithReturnsWindow().ShowDialog();
                                 break;
                             case "Sprawdzenie wiedzy":
                                 new SessionInputNoReturnsWindow().ShowDialog();
                                 break;
                             default:
                                 MessageBox.Show("Wystąpił błąd podczas ładowania słownika.");
                                 break;

                         }
                     },
                     (o) =>
                     {
                         return SelectedItem != null;
                     });
                return openDictionary;
            }
        }

        #endregion

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string? PropertyName = null)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        #endregion
    }
}
