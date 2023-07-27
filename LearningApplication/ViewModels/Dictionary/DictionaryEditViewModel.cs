﻿using LearningApplication.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using LearningApplication.Models.Dictionary;

namespace LearningApplication.ViewModels.Dictionary
{
    class DictionaryEditViewModel : INotifyPropertyChanged
    {
        #region Binding and Fields

        EditDictionary editDictionary = new EditDictionary();
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

        public string WordPolishInput
        {
            get
            {
                return editDictionary.wordPolish;
            }
            set
            {
                editDictionary.wordPolish = value.Trim();
                OnPropertyChanged(nameof(WordPolishInput));
            }
        }

        public string WordTranslatedInput
        {
            get
            {
                return editDictionary.wordTranslated;
            }
            set
            {
                editDictionary.wordTranslated = value.Trim();
                OnPropertyChanged(nameof(WordTranslatedInput));
            }
        }

        public Words SelectedItem
        {
            get
            {
                return editDictionary.selectedItem;
            }
            set
            {
                editDictionary.selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
                if (SelectedItem != null)
                {
                    WordPolishInput = SelectedItem.WordPolish;
                    WordTranslatedInput = SelectedItem.WordTranslated;
                }
            }
        }

        #endregion

        #region Commands

        private ICommand wordAdd = null;
        public ICommand WordAdd
        {
            get
            {
                if (wordAdd == null) wordAdd = new RelayCommand(
                    (o) =>
                    {
                    if (WordPolishInput != "" && WordTranslatedInput != "" && WordPolishInput != null && WordTranslatedInput != null)
                        {
                            Words word = new Words()
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
                            WordPolishInput = "";
                            WordTranslatedInput = "";

                        }
                        else
                        {
                            MessageBox.Show("Wprowadź poprawne słowo");
                        }

                    });
                return wordAdd;
            }
        }

        private ICommand wordEdit = null;
        public ICommand WordEdit
        {
            get
            {
                if (wordEdit == null) wordEdit = new RelayCommand(
                    (o) =>
                    {
                        Words word = new Words()
                        {
                            Id = SelectedItem.Id,
                            WordPolish = WordPolishInput,
                            WordTranslated = WordTranslatedInput,
                            CardStackId = applicationHelper.cardStacks.Id

                        };
                        using (var context = new DatabaseContext())
                        {
                            var index = WordsList.IndexOf(SelectedItem);
                            if (index >= 0)
                            {
                                WordsList[index] = word;
                            }
                            context.Words.Update(word);
                            context.SaveChanges();
                        }
                        WordPolishInput = "";
                        WordTranslatedInput = "";
                    },
                    (o) =>
                    {
                        return WordPolishInput != "" && WordTranslatedInput != "" && SelectedItem != null;
                    });
                return wordEdit;
            }
        }

        private ICommand wordDelete = null;
        public ICommand WordDelete
        {
            get
            {
                if (wordDelete == null) wordDelete = new RelayCommand(
                    (o) =>
                    {
                        var result = MessageBox.Show("Czy na pewno chcesz usunąć słowo " + SelectedItem.WordPolish + " - " + SelectedItem.WordTranslated + "? Dokonane zmiany nie mogą zostać cofnięte!", "Usunięcie słowa", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (result == MessageBoxResult.Yes)
                        {
                            Words word = SelectedItem;
                            using (var context = new DatabaseContext())
                            {
                                var index = WordsList.IndexOf(SelectedItem);
                                if (index >= 0)
                                {
                                    WordsList.RemoveAt(index);
                                }
                                context.Words.Remove(word);
                                context.SaveChanges();
                            }
                            WordPolishInput = "";
                            WordTranslatedInput = "";
                        }
                    },
                    (o) =>
                    {
                        return WordPolishInput != "" && WordTranslatedInput != "" && SelectedItem != null;
                    });
                return wordDelete;
            }
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
