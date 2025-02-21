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
    /// Логика взаимодействия для AddProjectPage.xaml
    /// </summary>
    public partial class AddProjectPage : Page
    {
        private ProjectViewModel _viewModel;
        private Projects _project;

        public AddProjectPage(ProjectViewModel viewModel, Projects project = null)
        {
            InitializeComponent();
            _viewModel = viewModel;
            _project = project ?? new Projects(); // Если проект не выбран, создаем новый

            if (_project != null)
            {
                ProjectNameTextBox.Text = _project.ProjectName;
                StartDatePicker.SelectedDate = _project.StartDate;
                EndDatePicker.SelectedDate = _project.EndDate;
                PriorityTextBox.Text = _project.Priority.ToString();
                CustomerCompanyIDTextBox.Text = _project.CustomerCompanyID.ToString();
                ContractorCompanyIDTextBox.Text = _project.ContractorCompanyID.ToString();
                ProjectManagerIDTextBox.Text = _project.ProjectManagerID.ToString();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _project.ProjectName = ProjectNameTextBox.Text;
            _project.StartDate = StartDatePicker.SelectedDate ?? DateTime.MinValue;
            _project.EndDate = EndDatePicker.SelectedDate ?? DateTime.MinValue;
            _project.Priority = int.Parse(PriorityTextBox.Text);
            _project.CustomerCompanyID = int.Parse(CustomerCompanyIDTextBox.Text);
            _project.ContractorCompanyID = int.Parse(ContractorCompanyIDTextBox.Text);
            _project.ProjectManagerID = int.Parse(ProjectManagerIDTextBox.Text);

            if (_project.ProjectID == 0) // Если проект новый
            {
                _viewModel.AddProject(_project);
            }
            else
            {
                _viewModel.EditProject(_project);
            }

            NavigationService.GoBack();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
