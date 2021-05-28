using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using WpfCommands.MVVM.ViewModel;

namespace WpfCommands
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 

        //private static readonly Regex _regex = new("[^0-9]+");
        public MainWindow()
        {
            DataContext = new MainViewModel();
            InitializeComponent();
         
        }

        private void agetext_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
           // var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }
        //private static bool IsTextAllowed(string text)
        //{
        //    return !_regex.IsMatch(text);
        //}

        private void agetext_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //e.Handled = IsTextAllowed(agetext.Text);
        }

        private void closebtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
