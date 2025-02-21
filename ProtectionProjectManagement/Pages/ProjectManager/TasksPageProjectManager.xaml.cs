using ProtectionProjectManagement.DB;
using ProtectionProjectManagement.ViewModels;
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

namespace ProtectionProjectManagement.Pages.ProjectManager
{
    /// <summary>
    /// Логика взаимодействия для TasksPageProjectManager.xaml
    /// </summary>
    public partial class TasksPageProjectManager : Page
    {
        private TaskViewModel _viewModel;

        public TasksPageProjectManager()
        {
            InitializeComponent();
            _viewModel = new TaskViewModel();
            DataContext = _viewModel;
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTaskPage(_viewModel));
        }

        private void EditTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (TaskListView.SelectedItem is Tasks selectedTask)
            {
                NavigationService.Navigate(new AddTaskPage(_viewModel, selectedTask));
            }
        }

        private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (TaskListView.SelectedItem is Tasks selectedTask)
            {
                _viewModel.Tasks.Remove(selectedTask);
                _viewModel._taskService.DeleteTask(selectedTask.TaskID);
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.LoadTasks();
        }

        private void EmployeesPageProjectManager_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeesPageProjectManager());
        }
    }

}
