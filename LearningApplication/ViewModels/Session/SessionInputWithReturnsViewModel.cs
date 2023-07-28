using LearningApplication.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Threading;

namespace LearningApplication.ViewModels.Session
{
    class SessionInputWithReturnsViewModel : INotifyPropertyChanged
    {
        #region Binding and Fields

        Models.Session.LearnSession session = new Models.Session.LearnSession();
        public static bool showExitPrompt = false;
        ApplicationHelperSingleton applicationHelper = ApplicationHelperSingleton.GetSingleton();
        public SessionInputWithReturnsViewModel()
        {
            NumberAllAnswers = 0;
            NumberCorrectAnswers = 0;
            NumberPercent = "";
            NumberDictionaryCompleted = "";
            session.totalWords = WordsList.Count;
            WindowName = applicationHelper.sessionDifficulty + " ze słownika: " + applicationHelper.cardStacks.CardStackName;
            showExitPrompt = true;
            AnswerBackground = Brushes.White;
            ButtonText = "Sprawdź";
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

        private Brush answerBackground;
        public Brush AnswerBackground
        {
            get
            {
                return answerBackground;
            }
            set
            {
                answerBackground = value;
                OnPropertyChanged(nameof(AnswerBackground));
            }
        }

        #endregion

        #region Commands

        private static bool isCorrect = false;
        private ICommand answerCheck = null;
        public ICommand AnswerCheck
        {
            get
            {
                if (answerCheck == null) answerCheck = new RelayCommand(
                    (o) =>
                    {
                        //Button text check
                        if (ButtonText == "Sprawdź")
                        {
                            //Correct answer
                            if (WordTranslated.ToLower().Trim() == WordsList[session.indexRandom].WordTranslated)
                            {
                                isCorrect = true;
                                AnswerBackground = Brushes.LightGreen;
                                ButtonText = "Następny";
                            }
                            //Incorrect answer
                            else
                            {
                                isCorrect = false;
                                AnswerBackground = Brushes.IndianRed;
                                ButtonText = "Następny";
                                var usersAnswer = WordTranslated;
                                WordTranslated = string.Format("Twoja odpowiedź: {0}\nPoprawna odpowiedź: {1}", usersAnswer, WordsList[session.indexRandom].WordTranslated);
                            }
                        }
                        //Button text next
                        else
                        {
                            ButtonText = "Sprawdź";
                            AnswerBackground = Brushes.White;
                            if (isCorrect)
                            {
                                WordTranslated = "";
                                WordsList.RemoveAt(session.indexRandom);
                                NumberCorrectAnswers++;

                            }
                            else
                            {
                                WordTranslated = "";
                                session.RollWord();
                            }
                            NumberAllAnswers++;
                            CheckIfSessionHasEnded();
                        }
                    });
                return answerCheck;
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
                using (var context = new DatabaseContext())
                {
                    await context.SessionStatistics.AddAsync(stats);
                    await context.SaveChangesAsync();
                }
                showExitPrompt = false;
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
