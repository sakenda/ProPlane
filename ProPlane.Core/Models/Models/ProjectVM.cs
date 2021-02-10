using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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

        public Project Project => _project;
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
                _project.LastEdit = DateTime.Now;
                _lastEdit = DateTime.Now;
            }

            _name.PropertyChanged += Project_PropertyChanged;
            _features.CollectionChanged += Features_CollectionChanged;
        }

        public void AcceptChanges()
        {
            _name.AcceptChanges();
            _description.AcceptChanges();
            foreach (FeatureVM item in _features)
            {
                if (item.Changed)
                    item.AcceptChanges();
            }

            _project.Name = _name.Value;
            _project.Description = _description.Value;
            _lastEdit = DateTime.Now;
        }

        public void UndoChanges()
        {
            _name.UndoChanges();
            _description.UndoChanges();
            foreach (FeatureVM item in _features)
            {
                if (item.Changed)
                    item.UndoChanges();
            }
        }

        private void Project_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (_name.HasChanged || _description.HasChanged)
                Changed = true;
            else
                Changed = false;
        }

        private void Features_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            foreach (FeatureVM item in _features)
                if (item.Changed) Changed = true;
        }

        private void InitializeFields()
        {
            _name = new StringVM(_project.Name);
            _description = new StringVM(_project.Description);
            _lastEdit = _project.LastEdit;
            _features = new ObservableCollection<FeatureVM>();

            if (_project.Features?.Count > 0)
            {
                foreach (Feature item in _project.Features)
                {
                    _features.Add(new FeatureVM(item));
                }
            }
        }
    }
}