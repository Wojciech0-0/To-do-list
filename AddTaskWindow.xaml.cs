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


namespace ListaZadan
{
    /// <summary>
    /// Logika interakcji dla klasy AddTaskWindow.xaml
    /// </summary>
    public partial class AddTaskWindow : Window
    {
        public TaskItem NewTask { get; private set; }


        public AddTaskWindow()
        {
            InitializeComponent();
            Add_data.SelectedDate = DateTime.Today;
        }
        
        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            string nazwa = Add_nazwa.Text.Trim();
            DateTime? data = Add_data.SelectedDate;
            string priority = "Nie ważne";

            if (LowPriority.IsChecked == true)
                priority = "Nie ważne";
            else if (MediumPriority.IsChecked == true)
                priority = "Średnio ważne";
            else if (HighPriority.IsChecked == true)
                priority = "Ważne";

            if (!string.IsNullOrEmpty(nazwa))
            {
                NewTask = new TaskItem
                {
                    Name = nazwa,
                    DueDate = data.Value,
                    Priority = priority
                };

                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Nazwa zadania nie może być pusta!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Add_nazwa_GotFocus(object sender, RoutedEventArgs e)
        {
            Add_nazwa.Text = "";
        }
    }
}
