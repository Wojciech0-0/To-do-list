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
using System.Collections.ObjectModel;

namespace ListaZadan
{
    /// <summary>
    /// Logika interakcji dla klasy TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {

        private TaskItem _task;
        private ObservableCollection<TaskItem> _tasks;
        public TaskWindow(TaskItem task, ObservableCollection<TaskItem> tasks)
        {
            InitializeComponent();
            _task = task;
            _tasks = tasks;

            Name.Text = _task.Name;
            switch (_task.Priority)
            {
                case "Nie ważne":
                    Nie.IsChecked = true;
                    break;
                case "Średnio ważne":
                    medium.IsChecked = true;
                    break;
                case "Ważne":
                    bardzo.IsChecked = true;
                    break;
            }
            Data.SelectedDate = _task.DueDate;
        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            _tasks.Remove(_task);
            this.DialogResult = true;
            Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            _task.Name = Name.Text.Trim();
            if (Nie.IsChecked == true)
                _task.Priority = "Nie ważne";
            else if (medium.IsChecked == true)
                _task.Priority = "Średnio ważne";
            else if (bardzo.IsChecked == true)
                _task.Priority = "Ważne";

            if (Data.SelectedDate.HasValue)
                _task.DueDate = Data.SelectedDate.Value;
            this.DialogResult = true;
            Close();
        }
    }
}
