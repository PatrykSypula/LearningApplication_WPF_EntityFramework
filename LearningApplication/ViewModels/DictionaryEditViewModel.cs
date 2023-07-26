using LearningApplication.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using LearningApplication.Models;

namespace LearningApplication.ViewModels
{
    class DictionaryEditViewModel
    {
        #region Binding and Fields

        Models.EditDictionary editDictionary = new Models.EditDictionary();
        ApplicationHelperSingleton applicationHelper = ApplicationHelperSingleton.GetSingleton();
        public DictionaryEditViewModel()
        {
            WindowName = "Edycja słownika: " + applicationHelper.cardStacks.CardStackName;
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

        public ObservableCollection<Words> WordsList
        {
            get { return editDictionary.wordsList; }
            set
            {
                editDictionary.wordsList = value;
                OnPropertyChanged(nameof(WordsList));
            }
        }

        public string? WordPolishInput
        {
            get
            {
                return editDictionary.wordPolish;
            }
            set
            {
                editDictionary.wordPolish = value;
                OnPropertyChanged(nameof(WordPolishInput));
            }
        }

        public string? WordTranslatedInput
        {
            get
            {
                return editDictionary.wordTranslated;
            }
            set
            {
                editDictionary.wordTranslated = value;
                OnPropertyChanged(nameof(WordTranslatedInput));
            }
        }

        public Words? SelectedItem
        {
            get
            {
                return editDictionary.selectedItem;
            }
            set
            {
                editDictionary.selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
                WordPolishInput = SelectedItem.WordPolish;
                WordTranslatedInput = SelectedItem.WordTranslated;
            }
        }

        #endregion

        #region Commands

        private ICommand? wordAdd = null;
        public ICommand WordAdd
        {
            get
            {
                if (wordAdd == null) wordAdd = new RelayCommand(
                    (object o) =>
                    {
                        if (WordPolishInput != "" && WordTranslatedInput != "")
                        {
                            Entities.Words word = new Words()
                            {
                                WordPolish = WordPolishInput,
                                WordTranslated = WordTranslatedInput,
                                CardStackId = applicationHelper.cardStacks.Id
                            };
                            using (var context = new DatabaseContext())
                            {
                                context.Words.Add(word);
                                context.SaveChanges();
                                WordsList.Add(word);
                            }
                            
                        }

                    });
                return wordAdd;
            }
        }

        private ICommand? wordEdit = null;
        public ICommand WordEdit
        {
            get
            {
                if (wordEdit == null) wordEdit = new RelayCommand(
                    (object o) =>
                    {

                    },
                    (object o) =>
                    {
                        return WordPolishInput != "" && WordTranslatedInput != "" && SelectedItem != null;
                    });
                return wordEdit;
            }
        }

        private ICommand? wordDelete = null;
        public ICommand WordDelete
        {
            get
            {
                if (wordDelete == null) wordDelete = new RelayCommand(
                    (object o) =>
                    {

                    },
                    (object o) =>
                    {
                        return WordPolishInput != "" && WordTranslatedInput != "" && SelectedItem != null;
                    });
                return wordDelete;
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
