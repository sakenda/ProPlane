using ProPlane.Core.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace ProPlane.View
{
    public partial class ProjectWindow : Window
    {
        private ProjectDataContext _main;

        public ProjectWindow(ProjectVM project)
        {
            InitializeComponent();

            _main = new ProjectDataContext(project);
            DataContext = _main;

            this.Title = _main.Project.Name.Value + " - ProPlane";
        }
    }
}