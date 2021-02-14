using ProPlane.Core.Models;
using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Animation;

namespace ProPlane.View
{
    public partial class ProjectWindow : Window
    {
        private ProjectDataContext _main;

        private double _closedWidth = 70;
        private double _openedWidth = 800;
        private DoubleAnimation _closeAnimation;
        private DoubleAnimation _openAnimation;

        private (bool isOpen, ToggleButton button)[] _buttons;

        public ProjectWindow(ProjectVM project)
        {
            InitializeComponent();

            _main = new ProjectDataContext(project);
            DataContext = _main;

            _buttons = new (bool, ToggleButton)[]
            {
                (true, featuresButton),
                (false, issuesButton),
                (false, mediasButton)
            };

            this.Title = _main.Project.Name.Value + " - ProPlane";
            this.SizeChanged += ProjectWindow_SizeChanged;
        }

        private void ProjectWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            _openedWidth = GetActualWidthOpened();

            _closeAnimation = new DoubleAnimation { From = _openedWidth, To = _closedWidth, Duration = TimeSpan.FromSeconds(0.4) };
            _openAnimation = new DoubleAnimation { From = _closedWidth, To = _openedWidth, Duration = TimeSpan.FromSeconds(0.4) };

            foreach (var item in _buttons)
            {
                if (item.isOpen)
                {
                    SetPanelSize(item.button);
                    break;
                }
            }
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is ToggleButton button)
                SetPanelSize(button);
        }

        private void SetPanelSize(ToggleButton button)
        {
            if (button.Name == featuresButton.Name)
                SetFeaturesPanelOpen();
            else if (button.Name == issuesButton.Name)
                SetIssuesPanelOpen();
            else if (button.Name == mediasButton.Name)
                SetMediasPanelOpen();

            SetToggleButtonChecked();
        }

        private void SetFeaturesPanelOpen()
        {
            if (IsOpened(issuesWidth.Width))
                issuesWidth.BeginAnimation(WidthProperty, _closeAnimation);

            if (IsOpened(mediasWidth.Width))
                mediasWidth.BeginAnimation(WidthProperty, _closeAnimation);

            featuresWidth.BeginAnimation(WidthProperty, _openAnimation);

            _buttons[0].isOpen = true;
            _buttons[1].isOpen = false;
            _buttons[2].isOpen = false;
        }

        private void SetIssuesPanelOpen()
        {
            if (IsOpened(featuresWidth.Width))
                featuresWidth.BeginAnimation(WidthProperty, _closeAnimation);

            if (IsOpened(mediasWidth.Width))
                mediasWidth.BeginAnimation(WidthProperty, _closeAnimation);

            issuesWidth.BeginAnimation(WidthProperty, _openAnimation);

            _buttons[0].isOpen = false;
            _buttons[1].isOpen = true;
            _buttons[2].isOpen = false;
        }

        private void SetMediasPanelOpen()
        {
            if (IsOpened(featuresWidth.Width))
                featuresWidth.BeginAnimation(WidthProperty, _closeAnimation);

            if (IsOpened(issuesWidth.Width))
                issuesWidth.BeginAnimation(WidthProperty, _closeAnimation);

            mediasWidth.BeginAnimation(WidthProperty, _openAnimation);
            _buttons[0].isOpen = false;
            _buttons[1].isOpen = false;
            _buttons[2].isOpen = true;
        }

        private void SetToggleButtonChecked()
        {
            featuresButton.IsChecked = _buttons[0].isOpen;
            issuesButton.IsChecked = _buttons[1].isOpen;
            mediasButton.IsChecked = _buttons[2].isOpen;
        }

        private bool IsOpened(double actual) => actual > _closedWidth;

        private double GetActualWidthOpened() => (Home.ActualWidth - leftSidebar.Width) - (2 * _closedWidth);
    }
}