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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NetAz_UpAndDown
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int Value { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Value = 5;
            TBScreen.Text = Value.ToString();
        }

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            if (Value < 9)
            {
                Value++;
                TBScreen.Text = Value.ToString();
            }

            if(Value == 9)
            {
                UpButton.IsEnabled = false;
            }

            if (Value > 0)
                DownButton.IsEnabled = true;
        }

        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            if (Value > 0)
            {
                Value--;
                TBScreen.Text = Value.ToString();
            }

            if (Value == 0)
            {
                DownButton.IsEnabled = false;
            }

            if (Value < 9)
                UpButton.IsEnabled = true;
        }
    }
}
