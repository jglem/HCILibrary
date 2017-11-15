using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace UserProfile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Profile : Page
    {
        public class DataObject
        {
            public string A { get; set; }
            public string B { get; set; }
            public string C { get; set; }

            public string D { get; set; }

            public string E { get; set; }
            public Button F { get; set; }

            public Button G { get; set; }
        }
        struct ItemDate
        {
            public int month;
            public int date;
            public int year;
        };
        struct CheckoutItems
        {
            public int item_number;
            public string item_title;
            public DateTime item_checkedout_date;
            public DateTime item_due_date;
            public int times_renewed;
        };
        ObservableCollection<DataObject> checkout_list;
        ObservableCollection<DataObject> hold_list;
        ObservableCollection<DataObject> fines_list;

        public Profile()
        {

            InitializeComponent();



            checkout_list = new ObservableCollection<DataObject>();

            CheckoutItems[] checkoutItems = new CheckoutItems[3];
            // item 1
            checkoutItems[0].item_number = 01234;
            checkoutItems[0].item_title = "Night School: A jack Reacher Novel";
            checkoutItems[0].item_checkedout_date = new DateTime(2017, 09, 24);
            checkoutItems[0].item_due_date = new DateTime(2017, 10, 23);
            checkoutItems[0].times_renewed = 3;
            //item2
            checkoutItems[1].item_number = 12344;
            checkoutItems[1].item_title = "Truly Madly Guilty";

            checkoutItems[1].item_checkedout_date = new DateTime(2017, 09, 24);
            checkoutItems[1].item_due_date = new DateTime(2017, 11, 13);
            checkoutItems[1].times_renewed = 5;

            //item2
            checkoutItems[2].item_number = 2124;
            checkoutItems[2].item_title = "When Breath Becomes Air";

            checkoutItems[2].item_checkedout_date = new DateTime(2017, 10, 24);
            checkoutItems[2].item_due_date = new DateTime(2017, 12, 11);
            checkoutItems[2].times_renewed = 2;


            checkout_list.Add(new DataObject() { A = checkoutItems[0].item_number.ToString(), B = checkoutItems[0].item_title, C = checkoutItems[0].item_checkedout_date.ToString("MMMM dd, yyyy"), D = checkoutItems[0].item_due_date.ToString("MMMM dd, yyyy"), E = checkoutItems[0].times_renewed.ToString() });
            checkout_list.Add(new DataObject() { A = checkoutItems[1].item_number.ToString(), B = checkoutItems[1].item_title, C = checkoutItems[1].item_checkedout_date.ToString("MMMM dd, yyyy"), D = checkoutItems[1].item_due_date.ToString("MMMM dd, yyyy"), E = checkoutItems[1].times_renewed.ToString() });
            checkout_list.Add(new DataObject() { A = checkoutItems[2].item_number.ToString(), B = checkoutItems[2].item_title, C = checkoutItems[2].item_checkedout_date.ToString("MMMM dd, yyyy"), D = checkoutItems[2].item_due_date.ToString("MMMM dd, yyyy"), E = checkoutItems[2].times_renewed.ToString() });

            this.CheckedOut.ItemsSource = checkout_list;

            hold_list = new ObservableCollection<DataObject>();
            // System.Windows.Controls.Button newBtn0 = new Button();
            // newBtn0.Content = "0";
            // newBtn0.Name = "Button0";

            //hold_list.Add(new DataObject() { A = "01", B = "Ready Player One", C = "in transit", D = " ", E = "uofc library", F = newBtn0 });

            System.Windows.Controls.Button newBtn1 = new Button();
            newBtn1.Content = "1";
            newBtn1.Name = "Button1";

            hold_list.Add(new DataObject() { A = "12", B = "The Maze Runner", C = "ready for pick up", D = "09/27/2017", E = "uofc library", F = newBtn1 });
            hold_list.Add(new DataObject() { A = "12", B = "The Maze Runner", C = "ready for pick up", D = "09/27/2017", E = "uofc library" });
            this.Holds_tab.ItemsSource = hold_list;

            fines_list = new ObservableCollection<DataObject>();
            fines_list.Add(new DataObject() { A = "01234", B = "Harry Potter and the Cursed Child, Parts 1 & 2", C = "$2.05" });
            fines_list.Add(new DataObject() { A = "10324", B = "When Breath Becomes Air", C = "$17.65" });
            fines_list.Add(new DataObject() { A = "00044", B = "The Whistler", C = "$10.99" });
            fines_list.Add(new DataObject() { A = "10034", B = "The Last Mile", C = "$3.45" });

            this.Fines.ItemsSource = fines_list;

        }


        void PopUpCloseHandler(Object sender, RoutedEventArgs args)
        {
            cancel_popup.IsOpen = false;
            confirmation_popup.IsOpen = false;
            renew_popup.IsOpen = false;
            change_location_popup.IsOpen = false;
            confirmation1_popup.IsOpen = false;
            bg.Visibility = Visibility.Hidden;
        }



        private void Renew_Click(object sender, RoutedEventArgs e)
        {
            PopUpCloseHandler(sender, e);
            bg.Visibility = Visibility.Visible;
            renew_popup.IsOpen = true;


        }
        private void No_Click(object sender, RoutedEventArgs e)
        {
            PopUpCloseHandler(sender, e);
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            PopUpCloseHandler(sender, e);

        }


        void Change_Loc_Click(object sender, RoutedEventArgs e)
        {
            PopUpCloseHandler(sender, e);
            bg.Visibility = Visibility.Visible;
            change_location_popup.IsOpen = true;
        }
        /*----------------------- HOLDS Functionality ------------------------------*/
        void ChangeLocation(object sender, RoutedEventArgs e)
        {
            bg.Visibility = Visibility.Visible;
            change_location_popup.IsOpen = true;
        }
        void Yes_ChangeLocation(object sender, RoutedEventArgs e)
        {
            PopUpCloseHandler(sender, e);
            string location = searchDropdownLocation.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
            object item = Holds_tab.SelectedItem;
            DataObject olditem = Holds_tab.SelectedItem as DataObject;
            DataObject newitem = new DataObject();
            newitem = olditem;
            newitem.E = location;

            int row = Holds_tab.SelectedIndex;
            //Remove old info
            hold_list.Remove(olditem);
            //Insert new info
            hold_list.Insert(row, newitem);


            searchDropdownLocation.SelectedIndex = 0;
        }
        void Yes_Hold(object sender, RoutedEventArgs e)
        {
            PopUpCloseHandler(sender, e);
            bg.Visibility = Visibility.Visible;
            confirmation_popup.IsOpen = true;

        }
        void CancelHoldsConfirmation(object sender, RoutedEventArgs e)
        {
            object item = Holds_tab.SelectedItem;
            string title = (Holds_tab.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;

            Console.WriteLine(title);
            string item_to_cancel = "\nAre you sure you\nwant to cancel your hold\non '" + title + "'";
            confrim_hold.Text = item_to_cancel;
            cancel_popup.IsOpen = true;
            bg.Visibility = Visibility.Visible;
        }
        void CancelHolds(object sender, RoutedEventArgs e)
        {
            PopUpCloseHandler(sender, e);

            //cancel_popup.IsOpen = true;
            DataObject item = Holds_tab.SelectedItem as DataObject;
            hold_list.Remove(item);

        }
        /*----------------------- RENEW Functionality-----------------------------*/
        void OK_Renew(object sender, RoutedEventArgs e)
        {
            renew_popup.IsOpen = false;
            bg.Visibility = Visibility.Hidden;
            RenewItem(sender, e);
        }

        void RenewItemConfirmation(object sender, RoutedEventArgs e)
        {
            renew_popup.IsOpen = true;
            bg.Visibility = Visibility.Visible;
        }
        void RenewItem(object sender, RoutedEventArgs e)
        {

            DataObject olditem = CheckedOut.SelectedItem as DataObject;
            DataObject newitem = new DataObject();
            newitem = olditem;

            object item = CheckedOut.SelectedItem;
            string strdate = (CheckedOut.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
            string strrenewCounter = (CheckedOut.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;

            int renewCounter = Int32.Parse(strrenewCounter);
            renewCounter++;

            DateTime date = Convert.ToDateTime(strdate);

            //update the date
            date = date.AddDays(21.0);

            newitem.D = date.ToString("MMMM dd, yyyy");
            newitem.E = renewCounter.ToString();


            int row = CheckedOut.SelectedIndex;

            //delete previous info
            checkout_list.Remove(olditem);
            checkout_list.Insert(row, newitem);


        }

    }
}
