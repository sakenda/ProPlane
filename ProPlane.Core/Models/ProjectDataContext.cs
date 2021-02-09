using System;
using System.Collections.Generic;
using System.Text;

namespace ProPlane.Core.Models
{
    public class ProjectDataContext : ViewModelBase
    {
        private ProjectVM _project;

        public ProjectVM Project
        {
            get { return _project; }
            set => SetProperty(ref _project, value);
        }

        public ProjectDataContext(ProjectVM project)
        {
            _project = project;
        }
    }
}