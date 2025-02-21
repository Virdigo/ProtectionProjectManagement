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
    /// Логика взаимодействия для AddTaskPage.xaml
    /// </summary>
    public partial class AddTaskPage : Page
    {
        private TaskViewModel _viewModel;
        private Tasks _task;

        public AddTaskPage(TaskViewModel viewModel, Tasks task = null)
        {
            InitializeComponent();
            _viewModel = viewModel;
            _task = task ?? new Tasks();

            if (_task != null)
            {
                TaskNameTextBox.Text = _task.TaskName;
                AuthorIDTextBox.Text = _task.AuthorID.ToString();
                PerformerIDTextBox.Text = _task.PerformerID.ToString();
                ProjectIDTextBox.Text = _task.ProjectID.ToString();
                StatusTextBox.Text = _task.Status;
                CommentTextBox.Text = _task.Comment;
                PriorityTextBox.Text = _task.Priority.ToString();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _task.TaskName = TaskNameTextBox.Text;
            _task.AuthorID = int.Parse(AuthorIDTextBox.Text);
            _task.PerformerID = int.Parse(PerformerIDTextBox.Text);
            _task.ProjectID = int.Parse(ProjectIDTextBox.Text);
            _task.Status = StatusTextBox.Text;
            _task.Comment = CommentTextBox.Text;
            _task.Priority = int.Parse(PriorityTextBox.Text);

            if (_task.TaskID == 0) // Для новой задачи
            {
                _viewModel.Tasks.Add(_task);
                _viewModel._taskService.AddTask(_task);
            }
            else
            {
                _viewModel._taskService.EditTask(_task);
            }

            NavigationService.GoBack();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }

}
