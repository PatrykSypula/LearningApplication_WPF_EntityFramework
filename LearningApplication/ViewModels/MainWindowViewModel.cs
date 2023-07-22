using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Input;
using LearningApplication.Views;

namespace LearningApplication.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ICommand learnLevel1 = null;
        public ICommand LearnLevel1
        {
            get
            {
                if (learnLevel1 == null) learnLevel1 = new RelayCommand(
                    (object o) =>
                    {
                        var session = SessionHelperSingleton.GetSingleton();
                        session.sessionDifficulty = "Poznawanie słów";
                        new ChooseDictionaryWindow().Show();
                    });
                return learnLevel1;
            }
        }

        private ICommand learnLevel2 = null;
        public ICommand LearnLevel2
        {
            get
            {
                if (learnLevel2 == null) learnLevel2 = new RelayCommand(
                    (object o) =>
                    {
                        var session = SessionHelperSingleton.GetSingleton();
                        session.sessionDifficulty = "Uczenie słów";
                        new ChooseDictionaryWindow().Show();
                    });
                return learnLevel2;
            }
        }

        private ICommand learnLevel3 = null;
        public ICommand LearnLevel3
        {
            get
            {
                if (learnLevel3 == null) learnLevel3 = new RelayCommand(
                    (object o) =>
                    {
                        var session = SessionHelperSingleton.GetSingleton();
                        session.sessionDifficulty = "Sprawdzenie wiedzy";
                        new ChooseDictionaryWindow().Show();
                    });
                return learnLevel3;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName = null)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
