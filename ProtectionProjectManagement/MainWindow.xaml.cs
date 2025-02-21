using ProtectionProjectManagement.DB;
using ProtectionProjectManagement.Pages;
using ProtectionProjectManagement.Pages.Admin;
using ProtectionProjectManagement.Pages.Employee;
using ProtectionProjectManagement.Pages.ProjectManager;
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

namespace ProtectionProjectManagement
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new LoginPage());
        }

        public void NavigateToHomePage(Login login, string role)
        {
            if (role == "Руководитель")
            {
                MainFrame.Navigate(new CompaniesPageAdmin());
            }
            else if (role == "Менеджер проекта")
            {
                MainFrame.Navigate(new ProjectsPageProjectManager());
            }
            else if (role == "Сотрудник")
            {
                MainFrame.Navigate(new ProjectsPageEmployee());
            }
        }
    }
}
