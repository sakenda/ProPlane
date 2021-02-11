using Microsoft.EntityFrameworkCore;
using ProPlane.Core.Database.Entity;
using ProPlane.Core.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProPlane.Core.Database
{
    public class DatabaseService
    {
        public ObservableCollection<ProjectVM> GetProjects()
        {
            List<Project> projects;
            ObservableCollection<ProjectVM> projectsVM = new ObservableCollection<ProjectVM>();

            using (var context = new ProjectContext())
            {
                DatabaseSeed.Seed(context);
                var query = context.Projects.Include(p => p.Features).ToList();

                projects = new List<Project>(query);
            }

            foreach (Project project in projects)
            {
                projectsVM.Add(new ProjectVM(project));
            }

            return projectsVM;
        }

        public void DeleteProject(ProjectVM project)
        {
            using (var context = new ProjectContext())
            {
                context.Projects.Remove(project.Project);
                context.SaveChanges();
            }
        }

        public ProjectVM InsertProject(ProjectVM project)
        {
            using (var context = new ProjectContext())
            {
                project.AcceptChanges();
                context.Add(project.Project);
                context.SaveChanges();
            }

            return new ProjectVM(project.Project);
        }

        public void UpdateProjects(ObservableCollection<ProjectVM> projects)
        {
            using (var context = new ProjectContext())
            {
                foreach (ProjectVM project in projects)
                {
                    if (project.Changed)
                    {
                        project.AcceptChanges();
                        context.Add(project.Project);
                    }
                    else continue;
                }

                context.SaveChanges();
            }
        }
    }
}