﻿using System;
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
    /// Logika interakcji dla klasy StatisticsFromDictionaryWindow.xaml
    /// </summary>
    public partial class StatisticsFromDictionaryWindow : Window
    {
        public StatisticsFromDictionaryWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModels.Statistics.StatisticsFromDictionaryWindowViewModel();
            CloseDueToLackofConnection();
        }
        public void CloseDueToLackofConnection()
        {
            var applicationHelper = ApplicationHelperSingleton.GetSingleton();
            if (!applicationHelper.isConnected)
            {
                this.Close();
            }
        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            IconHelper.RemoveIcon(this);
        }
    }
}
