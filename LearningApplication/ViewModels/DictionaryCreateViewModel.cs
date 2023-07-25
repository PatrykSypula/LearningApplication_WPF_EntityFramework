﻿using LearningApplication.Entities;
using LearningApplication.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace LearningApplication.ViewModels
{
    public class DictionaryCreateViewModel
    {
        #region Binding and Fields

        Models.ChooseDictionary chooseDictionary = new Models.ChooseDictionary();

        public List<CardStacks> CardStackList
        {
            get { return chooseDictionary.cardStackList; }
            set
            {
                chooseDictionary.cardStackList = value;
                OnPropertyChanged(nameof(CardStackList));
            }
        }

        public CardStacks? SelectedItem
        {
            get
            {
                return chooseDictionary.selectedItem;
            }
            set
            {
                chooseDictionary.selectedItem = value;
            }
        }

        private string dictionaryName;
        public string DictionaryName
        {
            get
            {
                return dictionaryName;
            }
            set
            {
                dictionaryName = value;
                OnPropertyChanged(nameof(DictionaryName));
            }
        }

        #endregion

        #region Commands

        private ICommand? closeWindow = null;
        public ICommand CloseWindow
        {
            get
            {
                if (closeWindow == null) closeWindow = new RelayCommand(
                     (object o) =>
                     {
                         foreach (Window item in System.Windows.Application.Current.Windows)
                         {
                             if (item.DataContext == this) item.Close();
                         }
                     });
                return closeWindow;
            }
        }

        private ICommand? createDictionary = null;
        public ICommand CreateDictionary
        {
            get
            {
                if (createDictionary == null) createDictionary = new RelayCommand(
                     (object o) =>
                     {
                         var canCreateDictionary = true;
                         foreach (var dictionary in CardStackList)
                         {
                             if (dictionary.CardStackName.ToLower().Trim() == DictionaryName.ToLower().Trim())
                             {
                                 MessageBox.Show("Słownik o takiej nazwie już istnieje", "Błąd podczas dodawania słownika.");
                                 canCreateDictionary = false;
                                 break;
                             }
                         }
                         if (canCreateDictionary)
                         {
                             var dictionary = new CardStacks() { CardStackName = DictionaryName, IsDefaultCardStack = 0 };
                             using (var context = new DatabaseContext())
                             {
                                 context.CardStacks.Add(dictionary);
                                 context.SaveChanges();
                                 SelectedItem = dictionary;
                                 var dictionaryhelper = ApplicationHelperSingleton.GetSingleton();
                                 dictionaryhelper.cardStacks = SelectedItem;
                             }
                             foreach (Window item in System.Windows.Application.Current.Windows)
                             {
                                 if (item.DataContext == this) item.Close();
                             }
                             new DictionaryEditWindow().ShowDialog();
                         }

                     });
                return createDictionary;
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
