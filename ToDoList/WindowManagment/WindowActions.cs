using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace ToDoList.WindowManagment
{
    internal static class WindowActions
    {
        public static void MoveWindow(Window window) => window.DragMove();

        public static void CloseWindow(Window window) => window.Close();

        public static void MinimizeWindow(Window window) => window.WindowState = WindowState.Minimized;
    }
}
