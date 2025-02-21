using ProtectionProjectManagement.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectionProjectManagement.Services
{
    public class ProjectService
    {
        public List<Projects> GetProjects()
        {
            using (var context = new ProtectionProjectManagementEntities())
            {
                return context.Projects.ToList();
            }
        }

        public void AddProject(Projects project)
        {
            using (var context = new ProtectionProjectManagementEntities())
            {
                context.Projects.Add(project);
                context.SaveChanges();
            }
        }

        public void EditProject(Projects project)
        {
            using (var context = new ProtectionProjectManagementEntities())
            {
                var existingProject = context.Projects.Find(project.ProjectID);
                if (existingProject != null)
                {
                    existingProject.ProjectName = project.ProjectName;
                    existingProject.CustomerCompanyID = project.CustomerCompanyID;
                    existingProject.ContractorCompanyID = project.ContractorCompanyID;
                    existingProject.StartDate = project.StartDate;
                    existingProject.EndDate = project.EndDate;
                    existingProject.Priority = project.Priority;
                    existingProject.ProjectManagerID = project.ProjectManagerID;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteProject(int projectId)
        {
            using (var context = new ProtectionProjectManagementEntities())
            {
                var project = context.Projects.Find(projectId);
                if (project != null)
                {
                    context.Projects.Remove(project);
                    context.SaveChanges();
                }
            }
        }
    }
}
