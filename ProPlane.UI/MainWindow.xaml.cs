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
            ProjectWindow projectWindow = new ProjectWindow(dgList.SelectedItem as ProjectVM);
            projectWindow.Show();
        }

        private void NewProject_Click(object sender, RoutedEventArgs e)
        {
        }

        private void DeleteProject_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}