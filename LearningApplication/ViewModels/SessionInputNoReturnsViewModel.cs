﻿using LearningApplication.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;

namespace LearningApplication.ViewModels
{
    class SessionInputNoReturnsViewModel : INotifyPropertyChanged
    {
        #region Binding and Fields

        Models.Session session = new Models.Session();
        public static bool showExitPrompt = false;
        ApplicationHelperSingleton applicationHelper = ApplicationHelperSingleton.GetSingleton();
        public SessionInputNoReturnsViewModel()
        {
            NumberAllAnswers = 0;
            NumberCorrectAnswers = 0;
            NumberPercent = "";
            NumberDictionaryCompleted = "";
            session.totalWords = WordsList.Count;
            WindowName = applicationHelper.sessionDifficulty + " ze słownika: " + applicationHelper.cardStacks.CardStackName;
            showExitPrompt = true;
            AfterClick();
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

        public List<Words> WordsList
        {
            get { return session.wordsList; }
            set
            {
                session.wordsList = value;
                OnPropertyChanged(nameof(WordsList));
            }
        }

        public int NumberCorrectAnswers
        {
            get
            {
                return session.numberCorrectAnswers;
            }
            set
            {
                session.numberCorrectAnswers = value;
                OnPropertyChanged(nameof(NumberCorrectAnswers));
            }
        }

        public int NumberAllAnswers
        {
            get
            {
                return session.numberAllAnswers;
            }
            set
            {
                session.numberAllAnswers = value;
                OnPropertyChanged(nameof(NumberAllAnswers));
            }
        }

        public string? NumberPercent
        {
            get
            {
                return session.numberPercent;
            }
            set
            {
                if (NumberAllAnswers > 0)
                {
                    session.numberPercent = Math.Round(((double)NumberCorrectAnswers / (double)NumberAllAnswers) * 100, 2).ToString() + "%";
                }
                else
                {
                    session.numberPercent = "0%";
                }
                OnPropertyChanged(nameof(NumberPercent));
            }
        }

        public string? NumberDictionaryCompleted
        {
            get
            {
                return session.numberDictionaryCompleted;
            }
            set
            {
                if (NumberAllAnswers > 0)
                {
                    session.numberDictionaryCompleted = Math.Round(((double)NumberAllAnswers / (double)session.totalWords) * 100, 2).ToString() + "%";
                }
                else
                {
                    session.numberDictionaryCompleted = "0%";
                }
                OnPropertyChanged(nameof(NumberDictionaryCompleted));
            }
        }

        public string? WordPolish
        {
            get
            {
                return session.wordPolish;
            }
            set
            {
                session.wordPolish = value;
                OnPropertyChanged(nameof(WordPolish));
            }
        }

        public string? WordTranslated
        {
            get
            {
                return session.wordTranslated;
            }
            set
            {
                session.wordTranslated = value;
                OnPropertyChanged(nameof(WordTranslated));
            }
        }

        #endregion

        #region Commands

        private ICommand? answerNext = null;
        public ICommand AnswerNext
        {
            get
            {
                if (answerNext == null) answerNext = new RelayCommand(
                    (object o) =>
                    {
                        //Correct answer
                        if (WordTranslated.ToLower().Trim() == WordsList[session.indexRandom].WordTranslated)
                        {
                            WordTranslated = "";
                            WordsList.RemoveAt(session.indexRandom);
                            NumberCorrectAnswers++;
                        }
                        //Incorrect answer
                        else
                        {
                            WordsList.RemoveAt(session.indexRandom);
                        }
                        NumberAllAnswers++;
                        CheckIfSessionHasEnded();
                    });
                return answerNext;
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

        #region Methods

        public async void CheckIfSessionHasEnded()
        {
            if (WordsList.Count == 0)
            {
                Entities.SessionStatistics stats = new SessionStatistics()
                {
                    SessionDate = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy")),
                    Difficulty = applicationHelper.sessionDifficulty,
                    GoodAnswers = NumberCorrectAnswers,
                    AllAnswers = NumberAllAnswers,
                    CardStackId = applicationHelper.cardStacks.Id
                };
                using (var context = new DatabaseContext())
                {
                    await context.SessionStatistics.AddAsync(stats);
                    await context.SaveChangesAsync();
                }
                showExitPrompt = false;
                foreach (Window item in System.Windows.Application.Current.Windows)
                {
                    if (item.DataContext == this) item.Close();
                }
            }
            else AfterClick();
        }
        public void AfterClick()
        {
            NumberPercent = "";
            NumberDictionaryCompleted = "";
            var word = session.PrintWord();
            WordPolish = word?.WordPolish;
            WordTranslated = "";
        }

        #endregion
    }
}
