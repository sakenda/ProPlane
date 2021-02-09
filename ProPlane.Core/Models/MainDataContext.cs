using ProPlane.Core.Database;
using System.Collections.ObjectModel;

namespace ProPlane.Core.Models
{
    public class MainDataContext : ViewModelBase
    {
        private DatabaseService _database = new DatabaseService();
        private ObservableCollection<ProjectVM> _listCollection;
        private ProjectVM _currentProject;

        public ObservableCollection<ProjectVM> ListCollection => _listCollection;
        public ProjectVM CurrentProject
        {
            get => _currentProject;
            set => SetProperty(ref _currentProject, value);
        }

        public MainDataContext()
        {
            _listCollection = _database.GetProjects();
        }
    }
}