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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for CheckOut.xaml
    /// </summary>
    public partial class CheckOut : Page
    {

        private List<string> bookTitles = new List<string>();
        private bool scanning = false;
        private int count = 0;

        public CheckOut()
        {
            InitializeComponent();
        }

        private void button_Scan_Click(object sender, RoutedEventArgs e)
        {
            scanning = true;
            if (this.count <= 5)
            {
                exitButton.Content = "FINISH";

                msgBlock.Text = "Continue Scanning Next Item \n or \n Press FINISH";

                SolidColorBrush newBackground = new SolidColorBrush(Colors.White);

                StackPanel1.Background = newBackground;

                var newTextBox = new TextBox();
                newTextBox.Height = 41;
                newTextBox.TextWrapping = System.Windows.TextWrapping.Wrap;
                if (bookTitles.Count > 0)
                {
                    newTextBox.Text = bookTitles[0];
                    bookTitles.RemoveAt(0);
                }
                else
                {
                    newTextBox.Text = "text";
                }
                newTextBox.FontSize = 20;
                newTextBox.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xA7, 0XD4, 0X81));

                StackPanel1.Children.Add(newTextBox);
                count++;
            }
            else
            {
                button_Scan.Visibility = Visibility.Collapsed;
            }


        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            if (scanning == false)
            {
                checkoutGrid.Visibility = Visibility.Collapsed;
                checkout_popup.IsOpen = false;
                this.NavigationService.Navigate(new Uri("MainWindow.xaml", UriKind.Relative));
               
            }
            else
            {
                checkout_popup.IsOpen = true;
                bg.Visibility = Visibility.Visible;
            }

        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            checkoutGrid.Visibility = Visibility.Collapsed;
            checkout_popup.IsOpen = false;
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            checkout_popup.IsOpen = false;
            bg.Visibility = Visibility.Hidden;
        }
    }
}
