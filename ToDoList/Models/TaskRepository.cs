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
            ToDoTask? taskToDelete = Get(id);
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

        public async Task<IEnumerable<ToDoTask>> GetAllAsync()
        {
            return await _db.Tasks.ToListAsync();
        }

        public async Task<ToDoTask?> GetAsync(int id)
        {
            return await _db.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async void AddAsync(ToDoTask item)
        {
            await _db.Tasks.AddAsync(item);
        }

        public async void DeleteAsync(int id)
        {
            ToDoTask? taskToDelete = await GetAsync(id);
            if (taskToDelete != null)
            {
                _db.Tasks.Remove(taskToDelete);
            }
        }

        public async void SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
