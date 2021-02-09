using ProPlane.Core.Database.Entity;
using ProPlane.Core.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
                projects = new List<Project>(context.Projects);
            }

            foreach (Project project in projects)
            {
                projectsVM.Add(new ProjectVM(project));
            }

            return projectsVM;
        }
    }
}