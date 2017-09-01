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

namespace offApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SystemSwitch systemSwitch = new SystemSwitch();
        public MainWindow()
        {
            InitializeComponent();
            systemSwitch = new SystemSwitch();
            editLabel("Brak zaplanowanego zamknięcia systemu Windows");
            date.DisplayDateStart = DateTime.Today;
        }

        private void editLabel(String newText)
        {
            statusLabel.Content = newText;
        }

        private void addShutdown_Click(object sender, RoutedEventArgs e)
        {
            backBorder();
            bool validForm = true;
            if (hourTextBox.Text == "" || Int32.Parse(hourTextBox.Text) > 24)
            {
                hourTextBox.BorderBrush = Brushes.Red;
                validForm = false;
            }
            if (minutesTextBox.Text == "" || Int32.Parse(minutesTextBox.Text)>60)
            {
                minutesTextBox.BorderBrush = Brushes.Red;
                validForm = false;
            }
            if (date.Text == "")
            {
                date.BorderBrush = Brushes.Red;
                validForm = false;
            }

            if (validForm)
            {
                systemSwitch.addShutdown(date.SelectedDate.Value, hourTextBox.Text, minutesTextBox.Text);
                editLabel("Zaplanowane zamknięcie na: " + systemSwitch.getShutdownDate());
            }
        }
        private void backBorder()
        {
            hourTextBox.BorderBrush = Brushes.Black;
            minutesTextBox.BorderBrush = Brushes.Black;
            date.BorderBrush = Brushes.Black;
        }
    }
}
