using LearningApplication.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;

namespace LearningApplication.ViewModels.Statistics
{
    public class StatisticsViewModel : INotifyPropertyChanged
    {
        Models.Statistics.Statistics statistics = new Models.Statistics.Statistics();
        ApplicationHelperSingleton applicationHelperSingleton = ApplicationHelperSingleton.GetSingleton();

        public StatisticsViewModel()
        {
            StringBuilder sb = new StringBuilder();
            windowName = "Statystyki ze słownika: " + applicationHelperSingleton.cardStacks.CardStackName +" z poziomu: " + applicationHelperSingleton.sessionStatistics.Difficulty;
            DataFormat = "";
            GoodAnswers = applicationHelperSingleton.sessionStatistics.GoodAnswers;
            AllAnswers = applicationHelperSingleton.sessionStatistics.AllAnswers;
            Percentage = applicationHelperSingleton.sessionStatistics.Percentage;
        }
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

        private string windowName = null;
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

        public DateTime Data
        {
            get
            {
                return applicationHelperSingleton.sessionStatistics.SessionDate;
            }
            set
            {
                applicationHelperSingleton.sessionStatistics.SessionDate = value;
                OnPropertyChanged(nameof(Data));
            }
        }

        private string dataFormat;
        public string DataFormat
        {
            get 
            { 
                return Data.ToString("HH:mm dd.MM.yyyy"); 
            }
            set
            {
                dataFormat = applicationHelperSingleton.sessionStatistics.SessionDate.ToString("HH:mm dd.MM.yyyy");
                OnPropertyChanged(nameof(DataFormat));
            }
        }

        public int GoodAnswers
        {
            get
            {
                return applicationHelperSingleton.sessionStatistics.GoodAnswers;
            }
            set
            {
                applicationHelperSingleton.sessionStatistics.GoodAnswers = value;
                OnPropertyChanged(nameof(GoodAnswers));
            }
        }

        public int AllAnswers
        {
            get
            {
                return applicationHelperSingleton.sessionStatistics.AllAnswers;
            }
            set
            {
                applicationHelperSingleton.sessionStatistics.AllAnswers = value;
                OnPropertyChanged(nameof(AllAnswers));
            }
        }

        public string Percentage
        {
            get
            {
                return applicationHelperSingleton.sessionStatistics.Percentage;
            }
            set
            {
                applicationHelperSingleton.sessionStatistics.Percentage = value;
                OnPropertyChanged(nameof(Percentage));
            }
        }
        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string? PropertyName = null)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        #endregion
    }
}
