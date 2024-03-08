using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToDoList_DatabaseTest.Model;
using ToDoList_DatabaseTest.Model.Database;

namespace ToDoList.Models.Validators
{
    static class ToDoTaskValidator
    {
        public static bool CheckValidity(ToDoTask task)
        {
            if (string.IsNullOrEmpty(task.Name))
            {
                return false;
            }

            return true;
        }
    }
}
