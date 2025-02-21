using ProtectionProjectManagement.DB;
using ProtectionProjectManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectionProjectManagement.ViewModels
{
    internal class LoginViewModel : BaseViewModel
    {
        private LoginService _loginService;
        public string Login1 { get; set; }
        public string Password { get; set; }
        public Login AuthenticatedLogin { get; private set; }
        public string UserRole { get; private set; } // Это временная переменная для должности

        public LoginViewModel()
        {
            _loginService = new LoginService();
        }

        public bool Authenticate()
        {
            // Аутентификация возвращает логин и должность
            string post = string.Empty;
            AuthenticatedLogin = _loginService.Authenticate(Login1, Password, out post);

            if (AuthenticatedLogin != null)
            {
                // Сохраняем должность, если логин был найден
                UserRole = post;
            }

            return AuthenticatedLogin != null;
        }
    }





}
