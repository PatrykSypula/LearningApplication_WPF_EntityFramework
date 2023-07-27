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
using LearningApplication.ViewModels.Session;

namespace LearningApplication.Views
{
    /// <summary>
    /// Logika interakcji dla klasy SessionInputWindow.xaml
    /// </summary>
    public partial class SessionInputWithReturnsWindow : Window
    {
        public SessionInputWithReturnsWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModels.Session.SessionInputWithReturnsViewModel();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (SessionInputWithReturnsViewModel.showExitPrompt)
            {
                var result = MessageBox.Show("Czy na pewno chcesz zakończyć sesję?", "Wyjście z sesji", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
