using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ProPlane.Core.Database.Entity;
using ProPlane.Core.Models.Datatypes;

namespace ProPlane.Core.Models
{
    public class ProjectVM : ViewModelBase
    {
        private Project _project;
        private StringVM _name;
        private StringVM _description;
        private DateTime _lastEdit;
        private ObservableCollection<FeatureVM> _features;
        private bool _changed;

        public StringVM Name => _name;
        public StringVM Description => _description;
        public DateTime LastEdit => _lastEdit;
        public DateTime Created => _project.Created;
        public ObservableCollection<FeatureVM> Features => _features;
        public bool Changed
        {
            get => _changed;
            set => SetProperty(ref _changed, value);
        }

        public ProjectVM(Project project)
        {
            if (project != null)
            {
                _project = project;
                InitializeFields();
            }
            else
            {
                _project = new Project();
                InitializeFields();
                _name.HasChanged = true;
                _description.HasChanged = true;

                _name.Value = "Neues Projekt";
                _project.Created = DateTime.Now;
                _lastEdit = DateTime.Now;
            }

            _name.PropertyChanged += Project_PropertyChanged;
        }

        public void AcceptChanges()
        {
            _name.AcceptChanges();
            _lastEdit = DateTime.Now;
        }

        public void UndoChanges()
        {
            _name.UndoChanges();
        }

        private void Project_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (_name.HasChanged || _description.HasChanged)
                Changed = true;
            else
                Changed = false;
        }

        private void InitializeFields()
        {
            _name = new StringVM(_project.Name);
            _description = new StringVM(_project.Description);
            _lastEdit = _project.LastEdit;
        }
    }
}