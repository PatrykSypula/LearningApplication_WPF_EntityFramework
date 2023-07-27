using LearningApplication.Entities;
using LearningApplication.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;
using LearningApplication.Models.Statistics;

namespace LearningApplication.ViewModels.Statistics
{
    internal class ChooseStatisticDictionaryViewModel : INotifyPropertyChanged
    {
        #region Binding and Fields

        ChooseStatisticDictionary chooseDictionaryStatistic = new Models.Statistics.ChooseStatisticDictionary();

        public List<CardStacks> StatisticDictionaryList
        {
            get { return chooseDictionaryStatistic.statisticDictionaryList; }
            set
            {
                chooseDictionaryStatistic.statisticDictionaryList = value;
                OnPropertyChanged(nameof(StatisticDictionaryList));
            }
        }
        public CardStacks SelectedItem
        {
            get
            {
                return chooseDictionaryStatistic.selectedItem;
            }
            set
            {
                chooseDictionaryStatistic.selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
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

        private ICommand statisticOpen = null;
        public ICommand StatisticOpen
        {
            get
            {
                if (statisticOpen == null) statisticOpen = new RelayCommand(
                     (o) =>
                     {
                         var dictionary = ApplicationHelperSingleton.GetSingleton();
                         dictionary.cardStacks = SelectedItem;
                         foreach (Window item in Application.Current.Windows)
                         {
                             if (item.DataContext == this) item.Close();
                         }
                         new StatisticsFromDictionaryWindow().ShowDialog();
                     },
                     (o) =>
                     {
                         return SelectedItem != null;
                     });
                return statisticOpen;
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
