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
    public class TaskViewModel : BaseViewModel
    {
        public TaskService _taskService;
        public ObservableCollection<Tasks> Tasks { get; set; }

        public TaskViewModel()
        {
            _taskService = new TaskService();
            Tasks = new ObservableCollection<Tasks>();
            LoadTasks();
        }

        public void LoadTasks()
        {
            Tasks.Clear();
            var tasksList = _taskService.GetTasks();
            foreach (var task in tasksList)
            {
                Tasks.Add(task);
            }
        }
    }

}
