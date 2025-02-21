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
    /// Логика взаимодействия для AddCompanyPage.xaml
    /// </summary>
    public partial class AddCompanyPage : Page
    {
        private CompanyViewModel _viewModel;
        private Companies _company;

        public AddCompanyPage(CompanyViewModel viewModel, Companies company = null)
        {
            InitializeComponent();
            _viewModel = viewModel;
            _company = company ?? new Companies();

            if (_company != null)
            {
                CompanyNameTextBox.Text = _company.CompanyName;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _company.CompanyName = CompanyNameTextBox.Text;

            if (_company.CompanyID == 0) // Assuming 0 is for a new company
            {
                _viewModel.Companies.Add(_company);
                _viewModel._companyService.AddCompany(_company);
            }
            else
            {
                _viewModel._companyService.EditCompany(_company);
            }

            NavigationService.GoBack();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
