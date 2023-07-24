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

namespace LearningApplication.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel() 
        {
            using (var context = new DatabaseContext())
            {
                //Statement return nothing.
                //It is used to execute first query that takes more time so there will not be any long loading windows.
                context.CardStacks.Where(c => c.Id == 0).AsNoTracking().ToList();
            }
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
                        var session = SessionHelperSingleton.GetSingleton();
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
                        var session = SessionHelperSingleton.GetSingleton();
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
                        var session = SessionHelperSingleton.GetSingleton();
                        session.sessionDifficulty = "Sprawdzenie wiedzy";
                        new ChooseDictionaryWindow().ShowDialog();
                    });
                return wordsTest;
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
