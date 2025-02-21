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

namespace ProtectionProjectManagement.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEmployeePage.xaml
    /// </summary>
    public partial class AddEmployeePage : Page
    {
        private EmployeeViewModel _viewModel;
        private Employees _employee;

        public AddEmployeePage(EmployeeViewModel viewModel, Employees employee = null)
        {
            InitializeComponent();
            _viewModel = viewModel;
            _employee = employee ?? new Employees();

            if (_employee != null)
            {
                FirstNameTextBox.Text = _employee.FirstName;
                LastNameTextBox.Text = _employee.LastName;
                MiddleNameTextBox.Text = _employee.MiddleName;
                EmailTextBox.Text = _employee.Email;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _employee.FirstName = FirstNameTextBox.Text;
            _employee.LastName = LastNameTextBox.Text;
            _employee.MiddleName = MiddleNameTextBox.Text;
            _employee.Email = EmailTextBox.Text;

            if (_employee.EmployeeID == 0) // Assuming 0 is for a new employee
            {
                _viewModel.Employees.Add(_employee);
                _viewModel._employeeService.AddEmployee(_employee);
            }
            else
            {
                _viewModel._employeeService.EditEmployee(_employee);
            }

            NavigationService.GoBack();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }

}
