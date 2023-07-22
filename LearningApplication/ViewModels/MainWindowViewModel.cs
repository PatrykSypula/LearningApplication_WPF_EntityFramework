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
                    async (object o) =>
                    {
                        new ChooseDictionaryWindow().Show();
                    });
                return learnLevel1;
            }

        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName = null)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
