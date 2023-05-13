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
using System.Windows.Threading;
using WPFAndMVVM2.ViewModels;

namespace WPFAndMVVM2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel mvm = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();

            DataContext = mvm;
        }

        private void btnNewPerson_Click(object sender, RoutedEventArgs e)
        {
            mvm.AddDefaultPerson();
            listBox.ScrollIntoView(sender);
        }

        private void btnDeletePerson_Click(object sender, RoutedEventArgs e)
        {
            mvm.DeleteSelectedPerson();
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(listBox.SelectedItem != null) {
                mvm.UpdateSelectedPerson();
            }
            else {
                firstNametxtBox.Text = string.Empty;
                lastNametxtBox.Text= string.Empty;  
                agetxtBox.Text = "0";
                phonetxtBox.Text = string.Empty;
                Focus();
            }
        }

        // Code to mark all text as soon as the textbox has the focus
        private void firstNametxtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            firstNametxtBox.SelectAll();
        }

        private void lastNametxtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            lastNametxtBox.SelectAll();
        }

        private void agetxtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            agetxtBox.SelectAll();
        }
        private void phonetxtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            phonetxtBox.SelectAll();
        }

        private void firstNametxtBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

            TextBox textBox = (TextBox)sender;
            if (!textBox.IsKeyboardFocusWithin) {
                textBox.Focus();
                e.Handled = true;
            }
        }

        private void lastNametxtBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!textBox.IsKeyboardFocusWithin) {
                textBox.Focus();
                e.Handled = true;
            }
        }

        private void agetxtBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!textBox.IsKeyboardFocusWithin) {
                textBox.Focus();
                e.Handled = true;
            }
        }

        private void phonetxtBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!textBox.IsKeyboardFocusWithin) {
                textBox.Focus();
                e.Handled = true;
            }
        }
    }
}
