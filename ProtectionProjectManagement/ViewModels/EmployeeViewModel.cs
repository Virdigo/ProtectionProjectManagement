using ProtectionProjectManagement.DB;
using ProtectionProjectManagement.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectionProjectManagement.ViewModels
{
    public class EmployeeViewModel : BaseViewModel
    {
        public EmployeeService _employeeService;
        public ObservableCollection<Employees> Employees { get; set; }

        public EmployeeViewModel()
        {
            _employeeService = new EmployeeService();
            Employees = new ObservableCollection<Employees>();
            LoadEmployees();
        }

        public void LoadEmployees()
        {
            Employees.Clear();
            var employeesList = _employeeService.GetEmployees();
            foreach (var employee in employeesList)
            {
                Employees.Add(employee);
            }
        }
    }
}
