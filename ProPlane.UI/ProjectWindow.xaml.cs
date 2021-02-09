using ProPlane.Core.Models;
using System;
using System.Windows;

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

            listBox.ItemsSource = _main.Project.Project.Features;
            Console.WriteLine(listBox.Items.Count);
        }
    }
}