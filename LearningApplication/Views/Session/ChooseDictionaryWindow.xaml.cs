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
    /// Logika interakcji dla klasy ChooseDictionaryWindow.xaml
    /// </summary>
    public partial class ChooseDictionaryWindow : Window
    {
        public ChooseDictionaryWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModels.Session.ChooseDictionaryViewModel();
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
    }
}
