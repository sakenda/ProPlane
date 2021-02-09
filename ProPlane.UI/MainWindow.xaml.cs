using System.Windows;
using ProPlane.Core.Models;

namespace ProPlane.View
{
    public partial class MainWindow : Window
    {
        private MainDataContext _main = new MainDataContext();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _main;
        }

        private void OpenProject_Click(object sender, RoutedEventArgs e)
        {
            var currentItem = dgList.SelectedItem as ProjectVM;
            if (currentItem != null)
            {
                ProjectWindow projectWindow = new ProjectWindow(currentItem);
                projectWindow.Show();
            }
        }

        private void NewProject_Click(object sender, RoutedEventArgs e)
        {
            _main.AddNewProject();
        }

        private void DeleteProject_Click(object sender, RoutedEventArgs e)
        {
            var currentItem = dgList.SelectedItem as ProjectVM;
            if (currentItem != null)
                _main.DeleteProject(currentItem);
        }
    }
}