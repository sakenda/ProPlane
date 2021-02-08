using ProPlane.Logic.ViewModels;
using ProPlane.Logic.Database;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Data;

namespace ProPlane.Logic
{
    public class MainViewModel : ViewModelBase
    {
        private DatabaseService _database = new DatabaseService();
        private ObservableCollection<ProjectVM> _listCollection;
        private ProjectVM _currentProject;

        public ObservableCollection<ProjectVM> ListCollection => _listCollection;
        public ListCollectionView View;
        public ProjectVM CurrentProject => _currentProject;

        public ICommand NewCommand { get; private set; }
        public ICommand OpenCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public MainViewModel()
        {
            _listCollection = _database.GetProjects();
            View = new ListCollectionView(_listCollection);

            NewCommand = new RelayCommand(NewExecuted);
            DeleteCommand = new RelayCommand(DeleteExecuted, DeleteCanExecute);
            OpenCommand = new RelayCommand(OpenExecuted);
        }

        private void NewExecuted(object obj)
        {
            View.AddNewItem(new ProjectVM(null));
        }

        private void OpenExecuted(object obj)
        {
            _currentProject = View.CurrentItem as ProjectVM;
        }

        private bool DeleteCanExecute(object obj)
        {
            return false;
        }

        private void DeleteExecuted(object obj)
        {
            return;
        }
    }
}