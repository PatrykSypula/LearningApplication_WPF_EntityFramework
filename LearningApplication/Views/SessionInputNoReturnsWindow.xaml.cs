using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logika interakcji dla klasy SessionInputNoReturnsWindow.xaml
    /// </summary>
    public partial class SessionInputNoReturnsWindow : Window
    {
        public SessionInputNoReturnsWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModels.SessionInputNoReturnsViewModel();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (ViewModels.SessionInputNoReturnsViewModel.showExitPrompt)
            {
                var result = MessageBox.Show("Czy na pewno chcesz zakończyć sesję?", "Wyjście z sesji", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }

        }
    }
}
