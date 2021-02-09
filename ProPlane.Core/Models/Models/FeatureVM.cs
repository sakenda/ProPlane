using ProPlane.Core.Database.Entity;
using ProPlane.Core.Models.Datatypes;
using System.ComponentModel;

namespace ProPlane.Core.Models
{
    public class FeatureVM : ViewModelBase
    {
        private Feature _feature;
        private StringVM _name;
        private StringVM _description;
        private bool _changed;

        public StringVM Name => _name;
        public StringVM Description => _description;
        public bool Changed
        {
            get => _changed;
            set => SetProperty(ref _changed, value);
        }

        public FeatureVM(Feature feature)
        {
            if (feature != null)
            {
                _feature = feature;
                InitializeFields();
            }
            else
            {
                _feature = new Feature();
                InitializeFields();
                _name.HasChanged = true;
                _description.HasChanged = true;
            }

            _name.PropertyChanged += Feature_PropertyChanged;
            _description.PropertyChanged += Feature_PropertyChanged;
        }

        public void AcceptChanges()
        {
            _name.AcceptChanges();
            _description.AcceptChanges();
        }

        public void UndoChanges()
        {
            _name.UndoChanges();
            _description.UndoChanges();
        }

        private void Feature_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (_name.HasChanged || _description.HasChanged)
                Changed = true;
            else
                Changed = false;
        }

        private void InitializeFields()
        {
            _name = new StringVM(_feature.Name);
            _description = new StringVM(_feature.Description);
        }
    }
}