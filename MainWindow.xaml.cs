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
using System.ComponentModel;

namespace ListaZadan
{

    public class TaskItem : INotifyPropertyChanged
    {
        private string name;
        private DateTime dueDate;
        private string priority;
        private bool isCompleted;

        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public DateTime DueDate
        {
            get => dueDate;
            set
            {
                if (dueDate != value)
                {
                    dueDate = value;
                    OnPropertyChanged(nameof(DueDate));
                }
            }
        }

        public string Priority
        {
            get => priority;
            set
            {
                if (priority != value)
                {
                    priority = value;
                    OnPropertyChanged(nameof(Priority));
                }
            }
        }

        public bool IsCompleted
        {
            get => isCompleted;
            set
            {
                if (isCompleted != value)
                {
                    isCompleted = value;
                    OnPropertyChanged(nameof(IsCompleted));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
            var sortWindow = new SortOptionsWindow();
            sortWindow.Owner = this;

            if (sortWindow.ShowDialog() == true)
            {
                var option = sortWindow.SelectedOption;

                switch (option)
                {
                    case "Priority":
                        int PriorityValue(string p)
                        {
                            if (p == "Nie ważne")
                                return 0;
                            else if (p == "Średnio ważne")
                                return 1;
                            else if (p == "Ważne")
                                return 2;
                            else
                                return 0;
                        }

                        var sortedByPriority = Tasks.OrderByDescending(t => PriorityValue(t.Priority)).ToList();
                        Tasks.Clear();
                        foreach (var task in sortedByPriority)
                            Tasks.Add(task);
                        break;

                    case "DueDate":
                        var sortedByDate = Tasks.OrderBy(t => t.DueDate).ToList();
                        Tasks.Clear();
                        foreach (var task in sortedByDate)
                            Tasks.Add(task);
                        break;

                    case "Name":
                        var sortedByName = Tasks.OrderBy(t => t.Name).ToList();
                        Tasks.Clear();
                        foreach (var task in sortedByName)
                            Tasks.Add(task);
                        break;
                }
            }
        }

    }
}
