using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_List.ViewModels
{
    class EditTaskVM
    {
        public Models.Task Task { get; set; }

        public EditTaskVM(Models.Task task)
        {
            Task = task;
        }
    }
}
