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
    public class ProjectViewModel : BaseViewModel
    {
        public ProjectService _projectService;

        public ObservableCollection<Projects> Projects { get; set; }

        public ProjectViewModel()
        {
            _projectService = new ProjectService();
            Projects = new ObservableCollection<Projects>(_projectService.GetProjects());
        }

        public void AddProject(Projects project)
        {
            _projectService.AddProject(project);
            Projects.Add(project);
        }

        public void EditProject(Projects project)
        {
            _projectService.EditProject(project);
            var existingProject = Projects.FirstOrDefault(p => p.ProjectID == project.ProjectID);
            if (existingProject != null)
            {
                existingProject.ProjectName = project.ProjectName;
                existingProject.CustomerCompanyID = project.CustomerCompanyID;
                existingProject.ContractorCompanyID = project.ContractorCompanyID;
                existingProject.StartDate = project.StartDate;
                existingProject.EndDate = project.EndDate;
                existingProject.Priority = project.Priority;
                existingProject.ProjectManagerID = project.ProjectManagerID;
            }
        }

        public void DeleteProject(int projectId)
        {
            _projectService.DeleteProject(projectId);
            var project = Projects.FirstOrDefault(p => p.ProjectID == projectId);
            if (project != null)
            {
                Projects.Remove(project);
            }
        }
    }

}
