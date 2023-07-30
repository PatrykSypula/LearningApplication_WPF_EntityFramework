using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Input;
using LearningApplication.Views;
using Microsoft.EntityFrameworkCore;
using MaterialDesignThemes.Wpf;
using System.Windows;

namespace LearningApplication.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            ApplicationHelperSingleton connection = ApplicationHelperSingleton.GetSingleton();
            try
            {
                using (var context = new DatabaseContext())
                {
                    //Statement return nothing.
                    //It is used to execute first query that takes more time so there will not be any long loading windows.
                    context.CardStacks.Where(c => c.Id == 0).AsNoTracking().ToList();
                }
            }
            catch
            {
                MessageBox.Show("Wystąpił błąd podczas łączenia z bazą. Spróbuj ponownie później");
                connection.isConnected = false;
            }
            connection.isConnected = true;
        }
        #region Commands

        private ICommand? wordsKnow = null;
        public ICommand WordsKnow
        {
            get
            {
                if (wordsKnow == null) wordsKnow = new RelayCommand(
                    (object o) =>
                    {
                        var session = ApplicationHelperSingleton.GetSingleton();
                        session.sessionDifficulty = "Poznawanie słów";
                        new ChooseDictionaryWindow().ShowDialog();
                    });
                return wordsKnow;
            }
        }

        private ICommand? wordsLearn = null;
        public ICommand WordsLearn
        {
            get
            {
                if (wordsLearn == null) wordsLearn = new RelayCommand(
                    (object o) =>
                    {
                        var session = ApplicationHelperSingleton.GetSingleton();
                        session.sessionDifficulty = "Uczenie słów";
                        new ChooseDictionaryWindow().ShowDialog();
                    });
                return wordsLearn;
            }
        }

        private ICommand? wordsTest = null;
        public ICommand WordsTest
        {
            get
            {
                if (wordsTest == null) wordsTest = new RelayCommand(
                    (object o) =>
                    {
                        var session = ApplicationHelperSingleton.GetSingleton();
                        session.sessionDifficulty = "Sprawdzenie wiedzy";
                        new ChooseDictionaryWindow().ShowDialog();
                    });
                return wordsTest;
            }
        }

        private ICommand? dictionaryCreate = null;
        public ICommand DictionaryCreate
        {
            get
            {
                if (dictionaryCreate == null) dictionaryCreate = new RelayCommand(
                    (object o) =>
                    {
                        new DictionaryCreateWindow().ShowDialog();
                    });
                return dictionaryCreate;
            }
        }

        private ICommand? dictionaryEdit = null;
        public ICommand DictionaryEdit
        {
            get
            {
                if (dictionaryEdit == null) dictionaryEdit = new RelayCommand(
                    (object o) =>
                    {
                        var dictionary = ApplicationHelperSingleton.GetSingleton();
                        dictionary.dictionaryAction = "Edytuj";
                        new DictionaryManagementWindow().ShowDialog();
                    });
                return dictionaryEdit;
            }
        }

        private ICommand? dictionaryDelete = null;
        public ICommand DictionaryDelete
        {
            get
            {
                if (dictionaryDelete == null) dictionaryDelete = new RelayCommand(
                    (object o) =>
                    {
                        var dictionary = ApplicationHelperSingleton.GetSingleton();
                        dictionary.dictionaryAction = "Usuń";
                        new DictionaryManagementWindow().ShowDialog();
                    });
                return dictionaryDelete;
            }
        }

        private ICommand? statisticsShow = null;
        public ICommand StatisticsShow
        {
            get
            {
                if (statisticsShow == null) statisticsShow = new RelayCommand(
                    (object o) =>
                    {
                        var dictionary = ApplicationHelperSingleton.GetSingleton();
                        dictionary.dictionaryAction = "Otwórz";
                        new ChooseStatisticDictionaryWindow().ShowDialog();
                    });
                return statisticsShow;
            }
        }

        private ICommand? statisticsDelete = null;
        public ICommand StatisticsDelete
        {
            get
            {
                if (statisticsDelete == null) statisticsDelete = new RelayCommand(
                    (object o) =>
                    {
                        var dictionary = ApplicationHelperSingleton.GetSingleton();
                        dictionary.dictionaryAction = "Usuń";
                        new ChooseStatisticDictionaryWindow().ShowDialog();
                    });
                return statisticsDelete;
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
