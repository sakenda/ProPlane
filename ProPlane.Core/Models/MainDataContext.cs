using ProPlane.Core.Database;
using System.Collections.ObjectModel;

namespace ProPlane.Core.Models
{
    public class MainDataContext : ViewModelBase
    {
        private DatabaseService _database = new DatabaseService();
        private ObservableCollection<ProjectVM> _listCollection;

        public ObservableCollection<ProjectVM> ListCollection => _listCollection;

        public MainDataContext()
        {
            _listCollection = _database.GetProjects();
        }

        public void AddNewProject()
        {
            ProjectVM p = _database.InsertProject(new ProjectVM(null));
            _listCollection.Add(p);
        }

        public void DeleteProject(ProjectVM project)
        {
            _database.DeleteProject(project);
            _listCollection.Remove(project);
        }
    }
}