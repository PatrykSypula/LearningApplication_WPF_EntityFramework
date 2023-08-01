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
    /// Logika interakcji dla klasy SessionYesNoWindow.xaml
    /// </summary>
    public partial class SessionYesNoWindow : Window
    {
        public SessionYesNoWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModels.Session.SessionYesNoViewModel();
            CloseDueToLackofConnection();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (SessionYesNoViewModel.showExitPrompt)
            {
                var result = new Views.CustomMessageBoxYesNo("Czy na pewno chcesz zakończyć sesję?").ShowDialog();
                if (!(bool)result)
                {
                    e.Cancel = true;
                }
            }
        }
        public void CloseDueToLackofConnection()
        {
            var applicationHelper = ApplicationHelperSingleton.GetSingleton();
            if (!applicationHelper.isConnected)
            {
                this.Close();
            }
        }

    }
}
