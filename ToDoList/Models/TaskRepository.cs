using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using ToDoList_DatabaseTest.Model.Database;

namespace ToDoList_DatabaseTest.Model
{
    /// <summary>
    /// <see cref="TaskRepository"/> encapsulates the logic of the <see cref="DatabaseContext"/>
    /// </summary>
    public class TaskRepository : IRepository<ToDoTask>
    {
        private DatabaseContext _db;

        public TaskRepository()
        {
            _db = new DatabaseContext();
        }

        public IEnumerable<ToDoTask> GetAll()
        {
            return _db.Tasks.ToList();
        }

        public void Add(ToDoTask item)
        {
            _db.Tasks.Add(item);
        }

        public void Delete(int id)
        {
            ToDoTask? taskToDelete = _db.Tasks.FirstOrDefault(x => x.Id == id);
            if (taskToDelete != null)
            {
                _db.Tasks.Remove(taskToDelete);
            }
        }

        public ToDoTask? Get(int id)
        {
            return _db.Tasks.FirstOrDefault(x => x.Id == id);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(ToDoTask item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
