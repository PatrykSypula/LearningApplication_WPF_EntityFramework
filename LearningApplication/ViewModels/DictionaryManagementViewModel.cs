using LearningApplication.Entities;
using LearningApplication.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media;

namespace LearningApplication.ViewModels
{
    class DictionaryManagementViewModel : INotifyPropertyChanged
    {
        #region Binding and Fields

        Models.DictionaryManagement chooseDictionary = new Models.DictionaryManagement();

        public DictionaryManagementViewModel()
        {
            if (dictionary.dictionaryAction == "Edytuj")
            {
                ButtonText = "Edytuj";
                ButtonColor = Brushes.Orange;
                Title = "Wybierz słownik do edycji.";
            }
            else
            {
                ButtonText = "Usuń";
                ButtonColor = Brushes.Red;
                Title = "Wybierz słownik do usunięcia.";
            }
        }

        public List<CardStacks> CardStackList
        {
            get { return chooseDictionary.cardStackList; }
            set
            {
                chooseDictionary.cardStackList = value;
                OnPropertyChanged(nameof(CardStackList));
            }
        }
        ApplicationHelperSingleton dictionary = ApplicationHelperSingleton.GetSingleton();
        public CardStacks? SelectedItem
        {
            get
            {
                return chooseDictionary.selectedItem;
            }
            set
            {
                chooseDictionary.selectedItem = value;
            }
        }

        private string? buttonText;
        public string? ButtonText
        {
            get
            {
                return buttonText;
            }
            set
            {
                buttonText = value;
                OnPropertyChanged(nameof(ButtonText));
            }
        }

        private Brush? buttonColor;
        public Brush ButtonColor
        {
            get
            {
                return buttonColor;
            }
            set
            {
                buttonColor = value;
                OnPropertyChanged(nameof(ButtonColor));
            }
        }

        private string? title;
        public string? Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
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

        private ICommand? dictionaryAction = null;
        public ICommand DictionaryAction
        {
            get
            {
                if (dictionaryAction == null) dictionaryAction = new RelayCommand(
                     (object o) =>
                     {
                         var dictionary = ApplicationHelperSingleton.GetSingleton();
                         dictionary.cardStacks = SelectedItem;
                         if (SelectedItem.IsDefaultCardStack != 1)
                         {
                             if (dictionary.dictionaryAction == "Edytuj")
                             {
                                 foreach (Window item in System.Windows.Application.Current.Windows)
                                 {
                                     if (item.DataContext == this) item.Close();
                                 }
                                 new DictionaryEditWindow().ShowDialog();
                             }
                             else
                             {
                                 var result = MessageBox.Show("Słownik \"" + SelectedItem.CardStackName + "\" zostanie usunięty wraz z jego zawartością! Czy na pewno chcesz kontynuować?", "Usunięcie słownika", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                                 if (result == MessageBoxResult.Yes)
                                 {

                                 }
                             }
                         }
                         else
                         {
                             string message;
                             if (dictionary.dictionaryAction == "Edytuj")
                             {
                                 message = "edytować";
                             }
                             else
                             {
                                 message = "usunąć";
                             }
                                 MessageBox.Show("Nie można "+message+" słownika standardowego.", "Czynność anulowana.");
                         }
                     },
                     (object o) =>
                     {
                         return SelectedItem != null;
                     });
                return dictionaryAction;
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
