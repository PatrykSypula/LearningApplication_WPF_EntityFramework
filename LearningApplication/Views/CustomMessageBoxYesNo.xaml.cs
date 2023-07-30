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
    /// Logika interakcji dla klasy CustomMessageBoxYesNo.xaml
    /// </summary>
    public partial class CustomMessageBoxYesNo : Window
    {
        public CustomMessageBoxYesNo(string message)
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

        private void ButtonYesClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
        private void ButtonNoClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
