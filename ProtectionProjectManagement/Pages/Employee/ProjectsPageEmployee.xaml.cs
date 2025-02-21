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

namespace ProtectionProjectManagement.Pages.Employee
{
    /// <summary>
    /// Логика взаимодействия для ProjectsPageEmployee.xaml
    /// </summary>
    public partial class ProjectsPageEmployee : Page
    {
        private ProjectViewModel _viewModel;

        public ProjectsPageEmployee()
        {
            InitializeComponent();
            _viewModel = new ProjectViewModel();
            DataContext = _viewModel;
        }

        private void AddProjectButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddProjectPage(_viewModel));
        }

        private void EditProjectButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectListView.SelectedItem is Projects selectedProject)
            {
                NavigationService.Navigate(new AddProjectPage(_viewModel, selectedProject));
            }
        }

        private void DeleteProjectButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectListView.SelectedItem is Projects selectedProject)
            {
                _viewModel.DeleteProject(selectedProject.ProjectID);
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Projects.Clear();
            foreach (var project in _viewModel._projectService.GetProjects())
            {
                _viewModel.Projects.Add(project);
            }
        }

        private void TasksPageEmployee_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TasksPageEmployee());
        }
    }

}

