using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToDo_List.Models;

namespace ToDo_List.ViewModels
{
    internal class MainWindowVM
    {
        public ObservableCollection<Models.Task> Tasks { get; set; }

        public string DateTimeNow
        {
            get
            {
                return DateTime.Now.ToString("D");
            }
        }

        public MainWindowVM()
        {
            Tasks = new ObservableCollection<Models.Task>
            {
                new Models.Task { Id = 1, Title = "Доделать программу", Description = "...", StartTime = "01.04.2023", EndTime = "15.03.2023", IsCompleted = false },
                new Models.Task { Id = 2, Title = "Доделать программу", Description = "...", StartTime = "01.04.2023", EndTime = "15.03.2023", IsCompleted = true },
                new Models.Task { Id = 3, Title = "Доделать программу", Description = "...", StartTime = "01.04.2023", EndTime = "15.03.2023", IsCompleted = true }
            };
        }
    }
}
