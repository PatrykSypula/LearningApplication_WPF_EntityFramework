using LearningApplication.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;
using LearningApplication.Views.Statistics;

namespace LearningApplication.ViewModels.Session
{
    class SessionInputNoReturnsViewModel : INotifyPropertyChanged
    {
        #region Binding and Fields

        Models.Session.LearnSession session = new Models.Session.LearnSession();
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
                    session.numberDictionaryCompleted = Math.Round(NumberAllAnswers / (double)session.totalWords * 100, 2).ToString() + "%";
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

        private ICommand answerNext = null;
        public ICommand AnswerNext
        {
            get
            {
                if (answerNext == null) answerNext = new RelayCommand(
                    (o) =>
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
                SessionStatistics stats = new SessionStatistics()
                {
                    SessionDate = DateTime.Now,
                    Difficulty = applicationHelper.sessionDifficulty,
                    GoodAnswers = NumberCorrectAnswers,
                    AllAnswers = NumberAllAnswers,
                    Percentage = NumberPercent,
                    CardStackId = applicationHelper.cardStacks.Id
                };
                ApplicationHelperSingleton connection = ApplicationHelperSingleton.GetSingleton();
                try
                {
                using (var context = new DatabaseContext())
                {
                    await context.SessionStatistics.AddAsync(stats);
                    await context.SaveChangesAsync();
                }
                showExitPrompt = false;
                applicationHelper.sessionStatistics = stats;
                new StatisticsWindow().ShowDialog();
                }
                catch
                {
                    MessageBox.Show("Wystąpił błąd podczas łączenia z bazą. Spróbuj ponownie później");
                    connection.isConnected = false;
                }
                connection.isConnected = true;

                foreach (Window item in Application.Current.Windows)
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
