using ProtectionProjectManagement.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectionProjectManagement.Services
{
    public class TaskService
    {
        public List<Tasks> GetTasks()
        {
            using (var context = new ProtectionProjectManagementEntities())
            {
                return context.Tasks.ToList();
            }
        }

        public void AddTask(Tasks task)
        {
            using (var context = new ProtectionProjectManagementEntities())
            {
                context.Tasks.Add(task);
                context.SaveChanges();
            }
        }

        public void EditTask(Tasks task)
        {
            using (var context = new ProtectionProjectManagementEntities())
            {
                var existingTask = context.Tasks.Find(task.TaskID);
                if (existingTask != null)
                {
                    existingTask.TaskName = task.TaskName;
                    existingTask.AuthorID = task.AuthorID;
                    existingTask.PerformerID = task.PerformerID;
                    existingTask.ProjectID = task.ProjectID;
                    existingTask.Status = task.Status;
                    existingTask.Comment = task.Comment;
                    existingTask.Priority = task.Priority;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteTask(int taskId)
        {
            using (var context = new ProtectionProjectManagementEntities())
            {
                var task = context.Tasks.Find(taskId);
                if (task != null)
                {
                    context.Tasks.Remove(task);
                    context.SaveChanges();
                }
            }
        }
    }

}
