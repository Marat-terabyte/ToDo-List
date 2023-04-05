﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_List.ViewModels
{
    class AddTaskVM
    {
        public Models.Task Task { get; set; }
        public DateTime DateTimeNow { get; }        

        public AddTaskVM()
        {
            DateTimeNow = DateTime.Now;
        }
    }
}
