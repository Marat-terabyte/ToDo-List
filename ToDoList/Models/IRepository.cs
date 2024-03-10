using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_DatabaseTest.Model
{
    /// <summary>
    /// <see cref="IRepository{T}"/> represents the Repository pattern
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T? Get(int id);
        void Add(T item);
        void Update(T item);
        void Delete(int id);
        void Save();

        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetAsync(int id);
        void AddAsync(T item);
        void DeleteAsync(int id);
        void SaveAsync();
    }
}
