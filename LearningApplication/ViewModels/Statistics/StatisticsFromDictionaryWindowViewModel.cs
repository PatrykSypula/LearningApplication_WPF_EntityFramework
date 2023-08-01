using LearningApplication.Entities;
using LearningApplication.Models.Statistics;
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
using System.Reflection;
using LearningApplication.Views.Statistics;
using System.Collections;

namespace LearningApplication.ViewModels.Statistics
{
    internal class StatisticsFromDictionaryWindowViewModel : INotifyPropertyChanged
    {
        #region Binding and Fields

        StatisticsFromSelectedDictionary chooseStatistic = new Models.Statistics.StatisticsFromSelectedDictionary();
        ApplicationHelperSingleton applicationHelperSingleton = ApplicationHelperSingleton.GetSingleton();
        public StatisticsFromDictionaryWindowViewModel()
        {
            if (applicationHelperSingleton.dictionaryAction == "Otwórz")
            {
                WindowName = "Wybór statystyki do obejrzenia";
                ButtonColor = "#0077D0";
                ButtonText = "Otwórz";
            }
            else
            {
                WindowName = "Wybór statystyki do usunięcia";
                ButtonColor = "#FF0000";
                ButtonText = "Usuń";
            }

        }

        public List<SessionStatistics> StatisticList
        {
            get { return chooseStatistic.statisticsList; }
            set
            {
                chooseStatistic.statisticsList = value;
                OnPropertyChanged(nameof(StatisticList));
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

        public SessionStatistics SelectedItem
        {
            get
            {
                return chooseStatistic.selectedItem;
            }
            set
            {
                chooseStatistic.selectedItem = value;
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

        private string buttonColor;
        public string ButtonColor
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

        private ICommand statisticAction = null;
        public ICommand StatisticAction
        {
            get
            {
                if (statisticAction == null) statisticAction = new RelayCommand(
                     (o) =>
                     {
                         if (applicationHelperSingleton.dictionaryAction == "Otwórz")
                         {
                             applicationHelperSingleton.sessionStatistics = SelectedItem;
                             new StatisticsWindow().ShowDialog();

                         }
                         else
                         {
                             var result = new Views.CustomMessageBoxYesNo("Czy na pewno chcesz usunąć zaznaczoną statystykę? Dokonane zmiany nie mogą zostać cofnięte!").ShowDialog();
                             if ((bool)result)
                             {
                                 ApplicationHelperSingleton connection = ApplicationHelperSingleton.GetSingleton();
                                 try
                                 {
                                     SessionStatistics stat = SelectedItem;
                                     using (var context = new DatabaseContext())
                                     {
                                         context.SessionStatistics.Remove(stat);
                                         context.SaveChanges();
                                     }
                                     new Views.CustomMessageBoxOk("Pomyślnie usunięto statystykę").ShowDialog();
                                     connection.isConnected = true;
                                 }
                                 catch
                                 {
                                     new Views.CustomMessageBoxOk("Wystąpił błąd podczas łączenia z bazą. Spróbuj ponownie później").ShowDialog();
                                     connection.isConnected = false;
                                 }
                                 foreach (Window item in Application.Current.Windows)
                                 {
                                     if (item.DataContext == this) item.Close();
                                 }
                             }
                         }
                     },
                     (o) =>
                     {
                         return SelectedItem != null;
                     });
                return statisticAction;
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
