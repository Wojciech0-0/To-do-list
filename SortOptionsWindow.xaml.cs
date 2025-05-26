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
    /// Logika interakcji dla klasy SortOptionsWindow.xaml
    /// </summary>
    public partial class SortOptionsWindow : Window
    {
            public string SelectedOption { get; private set; }

            public SortOptionsWindow()
            {
                InitializeComponent();
            }

            private void Ok_Click(object sender, RoutedEventArgs e)
            {
                if (rbPriority.IsChecked == true)
                    SelectedOption = "Priority";
                else if (rbDueDate.IsChecked == true)
                    SelectedOption = "DueDate";
                else if (rbName.IsChecked == true)
                    SelectedOption = "Name";

                DialogResult = true;
                Close();
            }
        }
}
