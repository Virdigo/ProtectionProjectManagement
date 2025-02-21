using ProtectionProjectManagement.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectionProjectManagement.Services
{
    public class LoginService
    {
        public Login Authenticate(string login1, string password, out string post)
        {
            using (var context = new ProtectionProjectManagementEntities())
            {
                // Находим логин в таблице Login
                var login = context.Login.FirstOrDefault(l => l.Login1 == login1 && l.Password == password);
                post = null;  // Изначально должность равна null
                if (login != null)
                {
                    // Находим должность пользователя по EmployeeID
                    var employeeRole = context.Doljnosti
                        .FirstOrDefault(d => d.id_doljnosti == login.EmployeeID);

                    if (employeeRole != null)
                    {
                        post = employeeRole.Post;  // Сохраняем должность в переменной
                    }
                }
                return login;
            }
        }
    }


}



