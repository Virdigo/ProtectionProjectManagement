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

namespace ProtectionProjectManagement.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для CompaniesPageAdmin.xaml
    /// </summary>
    public partial class CompaniesPageAdmin : Page
    {
        private CompanyViewModel _viewModel;
        public CompaniesPageAdmin()
        {
            InitializeComponent();
            _viewModel = new CompanyViewModel();
            DataContext = _viewModel;
        }

        private void AddCompanyButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddCompanyPage(_viewModel));
        }

        private void EditCompanyButton_Click(object sender, RoutedEventArgs e)
        {
            if (CompanyListView.SelectedItem is Companies selectedCompany)
            {
                NavigationService.Navigate(new AddCompanyPage(_viewModel, selectedCompany));
            }
        }

        private void DeleteCompanyButton_Click(object sender, RoutedEventArgs e)
        {
            if (CompanyListView.SelectedItem is Companies selectedCompany)
            {
                _viewModel.Companies.Remove(selectedCompany);
                _viewModel._companyService.DeleteCompany(selectedCompany.CompanyID);
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.LoadCompanies();
        }

        private void EmployeesPageAdmin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeesPageAdmin());
        }
    }
}
