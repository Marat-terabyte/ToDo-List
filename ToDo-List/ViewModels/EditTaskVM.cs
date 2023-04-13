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
