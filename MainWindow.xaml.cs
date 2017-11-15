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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Page
    {
        public MainWindow()
        {
            InitializeComponent();      
        }

      


        private void checkOutButtonClick1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("CheckOut.xaml", UriKind.Relative));
            // Main.NavigationService.Navigate(new CheckOut());
            //HomeScreen.Visibility = Visibility.Collapsed;
            //Toolbar.Visibility = Visibility.Collapsed;


        }

        
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Main.Navigate(new Browse());
            HomeScreen.Visibility = Visibility.Collapsed;

        }

    }
}
