using LearningApplication.Entities;
using LearningApplication.Views;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace LearningApplication.ViewModels.Session
{
    public class SessionYesNoViewModel : INotifyPropertyChanged
    {
        #region Binding and Fields

        Models.Session.LearnSession session = new Models.Session.LearnSession();
        public static bool showExitPrompt = false;
        public SessionYesNoViewModel()
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

        ApplicationHelperSingleton applicationHelper = ApplicationHelperSingleton.GetSingleton();

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

        public string NumberPercent
        {
            get
            {
                return session.numberPercent;
            }
            set
            {
                if (NumberAllAnswers > 0)
                {
                    session.numberPercent = Math.Round(NumberCorrectAnswers / (double)NumberAllAnswers * 100, 2).ToString() + "%";
                }
                else
                {
                    session.numberPercent = "0%";
                }
                OnPropertyChanged(nameof(NumberPercent));
            }
        }

        public string NumberDictionaryCompleted
        {
            get
            {
                return session.numberDictionaryCompleted;
            }
            set
            {
                if (NumberAllAnswers > 0)
                {
                    session.numberDictionaryCompleted = Math.Round(NumberCorrectAnswers / (double)session.totalWords * 100, 2).ToString() + "%";
                }
                else
                {
                    session.numberDictionaryCompleted = "0%";
                }
                OnPropertyChanged(nameof(NumberDictionaryCompleted));
            }
        }

        public string WordPolish
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

        public string WordTranslated
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

        private ICommand showWord = null;
        public ICommand ShowWord
        {
            get
            {
                if (showWord == null) showWord = new RelayCommand(
                    (o) =>
                    {
                        WordTranslated = WordsList[session.indexRandom].WordTranslated;
                    });
                return showWord;
            }
        }

        private ICommand answerIncorrect = null;
        public ICommand AnswerIncorrect
        {
            get
            {
                if (answerIncorrect == null) answerIncorrect = new RelayCommand(
                    (o) =>
                    {
                        NumberAllAnswers++;
                        session.RollWord();
                        CheckIfSessionHasEnded();
                    });
                return answerIncorrect;
            }
        }

        private ICommand answerCorrect = null;
        public ICommand AnswerCorrect
        {
            get
            {
                if (answerCorrect == null) answerCorrect = new RelayCommand(
                    (o) =>
                    {
                        WordsList.RemoveAt(session.indexRandom);
                        NumberCorrectAnswers++;
                        NumberAllAnswers++;
                        CheckIfSessionHasEnded();
                    },
                    (o) =>
                    {
                        return WordsList.Count != 0;
                    });
                return answerCorrect;
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
                SessionStatistics stats = new SessionStatistics()
                {
                    SessionDate = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy HH:mm")),
                    Difficulty = applicationHelper.sessionDifficulty,
                    GoodAnswers = NumberCorrectAnswers,
                    AllAnswers = NumberAllAnswers,
                    Percentage = NumberPercent,
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
