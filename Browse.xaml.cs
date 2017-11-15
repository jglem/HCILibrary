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
    /// Interaction logic for Browse.xaml
    /// </summary>
    public partial class Browse : Page
    {
        public Browse()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            InfoPopUp.IsOpen = true;
            InfoPopUp.StaysOpen = true;
            graybg.Visibility = Visibility.Visible;
        }

        private void exitInfoPopUpButton_Click(object sender, RoutedEventArgs e)
        {
            InfoPopUp.IsOpen = false;
            InfoPopUp.StaysOpen = false;
            graybg.Visibility = Visibility.Hidden;
        }

        private void travelLabel_Copy_TextChanged()
        {

        }

        private void MysteryButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void printInfoButton_Click(object sender, RoutedEventArgs e)
        {
            bg.Visibility = Visibility.Visible;
            PrintInfoPopUp.IsOpen = true;
            PrintInfoPopUp.StaysOpen = true;
        }

        private void exitPrintInfoButton_Click(object sender, RoutedEventArgs e)
        {
            PrintInfoPopUp.IsOpen = false;
            PrintInfoPopUp.StaysOpen = false;
            bg.Visibility = Visibility.Hidden;
        }

        private void allCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            titleCheckBox.IsChecked = true;
            synopsisCheckBox.IsChecked = true;
            copyAvailabilityCheckBox.IsChecked = true;
            itemImageCheckBox.IsChecked = true;
        }

        private void allCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (titleCheckBox.IsChecked == true && synopsisCheckBox.IsChecked == true && copyAvailabilityCheckBox.IsChecked == true && itemImageCheckBox.IsChecked == true)
            {
                titleCheckBox.IsChecked = false;
                synopsisCheckBox.IsChecked = false;
                copyAvailabilityCheckBox.IsChecked = false;
                itemImageCheckBox.IsChecked = false;
            }

        }

        private void titleCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            allCheckBox.IsChecked = false;
        }

        private void synopsisCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            allCheckBox.IsChecked = false;
        }

        private void copyAvailabilityCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            allCheckBox.IsChecked = false;
        }

        private void itemImageCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            allCheckBox.IsChecked = false;
        }

        private void titleCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (synopsisCheckBox.IsChecked == true && copyAvailabilityCheckBox.IsChecked == true && itemImageCheckBox.IsChecked == true)
            {
                allCheckBox.IsChecked = true;
            }
        }

        private void synopsisCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (titleCheckBox.IsChecked == true && copyAvailabilityCheckBox.IsChecked == true && itemImageCheckBox.IsChecked == true)
            {
                allCheckBox.IsChecked = true;
            }
        }

        private void copyAvailabilityCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (synopsisCheckBox.IsChecked == true && synopsisCheckBox.IsChecked == true && itemImageCheckBox.IsChecked == true)
            {
                allCheckBox.IsChecked = true;
            }
        }

        private void itemImageCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (synopsisCheckBox.IsChecked == true && copyAvailabilityCheckBox.IsChecked == true && titleCheckBox.IsChecked == true)
            {
                allCheckBox.IsChecked = true;
            }
        }

        private void printNowbutton_Click(object sender, RoutedEventArgs e)
        {
            titleCheckBox.IsChecked = false;
            synopsisCheckBox.IsChecked = false;
            copyAvailabilityCheckBox.IsChecked = false;
            itemImageCheckBox.IsChecked = false;

            PrintInfoPopUp.IsOpen = false;
            PrintInfoPopUp.StaysOpen = false;
            bg.Visibility = Visibility.Hidden;
        }

        private void placeHoldButton_Click(object sender, RoutedEventArgs e)
        {
            bg.Visibility = Visibility.Visible;
            change_location_popup.IsOpen = true;
            change_location_popup.StaysOpen = true;
        }

        private void exitButtonLocation_Click(object sender, RoutedEventArgs e)
        {
            bg.Visibility = Visibility.Hidden;
            change_location_popup.IsOpen = false;
            change_location_popup.StaysOpen = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bg.Visibility = Visibility.Hidden;
            change_location_popup.IsOpen = false;
            change_location_popup.StaysOpen = false;
            searchDropdownLocation.SelectedIndex = 0;
        }
    }
}

