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
using System.Collections.ObjectModel;

namespace ListaZadan
{
    public class TaskItem
    {
        public string Name { get; set; }         // Nazwa zadania
        public DateTime DueDate { get; set; }    // Data wykonania zadania
        public string Priority { get; set; }     // Priorytet zadania (np. niski, średni, wysoki)
        public bool IsCompleted { get; set; } = false;  // Status zadania (czy wykonane)

        public static implicit operator string(TaskItem v)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<TaskItem> Tasks { get; set; } = new ObservableCollection<TaskItem>();

        public MainWindow()
        {
            InitializeComponent();
            TaskList.ItemsSource = Tasks;
        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddTaskWindow();
            if (addWindow.ShowDialog() == true)
            {
                TaskItem newTask = addWindow.NewTask;

                Tasks.Add(newTask);
            }

        }

        private void SORT_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menu_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
