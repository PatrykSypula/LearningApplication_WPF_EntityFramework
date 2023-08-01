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
using LearningApplication.Models.Dictionary;

namespace LearningApplication.ViewModels.Dictionary
{
    class DictionaryManagementViewModel : INotifyPropertyChanged
    {
        #region Binding and Fields

        DictionaryManagement chooseDictionary = new DictionaryManagement();

        public DictionaryManagementViewModel()
        {
            if (dictionary.dictionaryAction == "Edytuj")
            {
                ButtonText = "Edytuj";
                ButtonColor = Brushes.Orange;
                WindowName = "Wybór słownik do edycji";
            }
            else
            {
                ButtonText = "Usuń";
                ButtonColor = Brushes.Red;
                WindowName = "Wybór słownik do usunięcia";
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
        public CardStacks SelectedItem
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

        private string buttonText;
        public string ButtonText
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

        private Brush buttonColor;
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

        private string windowName;
        public string WindowName
        {
            get
            {
                return windowName;
            }
            set
            {
                windowName = value;
                OnPropertyChanged(nameof(WindowName));
            }
        }

        #endregion

        #region Commands

        private ICommand closeWindow = null;
        public ICommand CloseWindow
        {
            get
            {
                if (closeWindow == null) closeWindow = new RelayCommand(
                     (o) =>
                     {
                         foreach (Window item in Application.Current.Windows)
                         {
                             if (item.DataContext == this) item.Close();
                         }
                     });
                return closeWindow;
            }
        }

        private ICommand dictionaryAction = null;
        public ICommand DictionaryAction
        {
            get
            {
                if (dictionaryAction == null) dictionaryAction = new RelayCommand(
                     (o) =>
                     {
                         var dictionary = ApplicationHelperSingleton.GetSingleton();
                         dictionary.cardStacks = SelectedItem;
                         if (SelectedItem.IsDefaultCardStack != 1)
                         {
                             if (dictionary.dictionaryAction == "Edytuj")
                             {
                                 foreach (Window item in Application.Current.Windows)
                                 {
                                     if (item.DataContext == this) item.Close();
                                 }
                                 new DictionaryEditWindow().ShowDialog();
                             }
                             else
                             {
                                 var result = new Views.CustomMessageBoxYesNo("Słownik \"" + SelectedItem.CardStackName + "\" zostanie usunięty wraz z jego słowami oraz statystykami! Czy na pewno chcesz kontynuować?").ShowDialog();
                                 if ((bool)result)
                                 {
                                     ApplicationHelperSingleton connection = ApplicationHelperSingleton.GetSingleton();
                                     try
                                     {
                                         List<Words> wordsList;
                                         List<SessionStatistics> statsList;

                                         using (var context = new DatabaseContext())
                                         {
                                             wordsList = context.Words.Where(w => w.CardStackId == dictionary.cardStacks.Id).ToList();
                                             foreach (var word in wordsList)
                                             {
                                                 context.Words.Remove(word);
                                             }
                                             statsList = context.SessionStatistics.Where(s => s.CardStackId == dictionary.cardStacks.Id).ToList();
                                             foreach (var stat in statsList)
                                             {
                                                 context.SessionStatistics.Remove(stat);
                                             }
                                             context.CardStacks.Remove(dictionary.cardStacks);
                                             context.SaveChanges();
                                             foreach (Window item in Application.Current.Windows)
                                             {
                                                 if (item.DataContext == this) item.Close();
                                             }
                                             new CustomMessageBoxOk("Pomyślnie usunięto słownik.").ShowDialog();
                                             connection.isConnected = true;
                                         }
                                     }
                                     catch
                                     {
                                         new CustomMessageBoxOk("Wystąpił błąd podczas łączenia z bazą. Spróbuj ponownie później").ShowDialog();
                                         connection.isConnected = false;
                                     }
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
                             new CustomMessageBoxOk("Nie można " + message + " słownika standardowego.").ShowDialog();
                         }
                     },
                     (o) =>
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
