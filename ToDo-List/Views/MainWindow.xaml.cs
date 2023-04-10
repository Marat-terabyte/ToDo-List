using System.Windows;
using System.Windows.Input;

namespace ToDo_List
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            try { DragMove(); }
            catch { }
        }

        private void CloseWindow(object sender, RoutedEventArgs e) => Close();

        private void MinimizeWindow(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
    }
}
