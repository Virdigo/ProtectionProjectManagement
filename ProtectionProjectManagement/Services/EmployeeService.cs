using ProtectionProjectManagement.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectionProjectManagement.Services
{
    public class EmployeeService
    {
        public List<Employees> GetEmployees()
        {
            using (var context = new ProtectionProjectManagementEntities())
            {
                return context.Employees.ToList();
            }
        }

        public void AddEmployee(Employees employee)
        {
            using (var context = new ProtectionProjectManagementEntities())
            {
                context.Employees.Add(employee);
                context.SaveChanges();
            }
        }

        public void EditEmployee(Employees employee)
        {
            using (var context = new ProtectionProjectManagementEntities())
            {
                var existingEmployee = context.Employees.Find(employee.EmployeeID);
                if (existingEmployee != null)
                {
                    existingEmployee.FirstName = employee.FirstName;
                    existingEmployee.LastName = employee.LastName;
                    existingEmployee.MiddleName = employee.MiddleName;
                    existingEmployee.Email = employee.Email;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteEmployee(int employeeId)
        {
            using (var context = new ProtectionProjectManagementEntities())
            {
                var employee = context.Employees.Find(employeeId);
                if (employee != null)
                {
                    context.Employees.Remove(employee);
                    context.SaveChanges();
                }
            }
        }
    }
}
