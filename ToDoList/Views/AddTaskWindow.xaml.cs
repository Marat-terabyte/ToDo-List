using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ToDoList.ViewModels;
using ToDoList.WindowManagment;
using ToDoList_DatabaseTest.Model;

namespace ToDoList.Views
{
    public partial class AddTaskWindow : Window
    {
        public AddTaskWindow(ObservableCollection<ToDoTask> tasks, IRepository<ToDoTask> db)
        {
            InitializeComponent();
            DataContext = new AddTaskVM(tasks, db, this);
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e) => WindowActions.MoveWindow(this);

        private void CloseWindow(object sender, RoutedEventArgs e) => WindowActions.CloseWindow(this);

        private void MinimizeWindow(object sender, RoutedEventArgs e) => WindowActions.MinimizeWindow(this);
    }
}
