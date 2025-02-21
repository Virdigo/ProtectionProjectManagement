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
    /// Логика взаимодействия для EmployeesPageProjectManager.xaml
    /// </summary>
    public partial class EmployeesPageProjectManager : Page
    {
        private EmployeeViewModel _viewModel;

        public EmployeesPageProjectManager()
        {
            InitializeComponent();
            _viewModel = new EmployeeViewModel();
            DataContext = _viewModel;
        }

        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEmployeePage(_viewModel));
        }

        private void EditEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeListView.SelectedItem is Employees selectedEmployee)
            {
                NavigationService.Navigate(new AddEmployeePage(_viewModel, selectedEmployee));
            }
        }

        private void DeleteEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeListView.SelectedItem is Employees selectedEmployee)
            {
                _viewModel.Employees.Remove(selectedEmployee);
                _viewModel._employeeService.DeleteEmployee(selectedEmployee.EmployeeID);
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.LoadEmployees();
        }

        private void ProjectsPageProjectManager_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProjectsPageProjectManager());
        }
    }

}
