﻿using LearningApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LearningApplication.Views
{
    /// <summary>
    /// Logika interakcji dla klasy CustomMessageBoxOk.xaml
    /// </summary>
    public partial class CustomMessageBoxOk : Window
    {
        public CustomMessageBoxOk(string message)
        {
            InitializeComponent();
            DataContext = this;
            Message = message;
        }

        private string message;
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
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
                         this.Close();
                     });
                return closeWindow;
            }
        }
    }
}
